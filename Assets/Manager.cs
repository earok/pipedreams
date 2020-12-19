using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class ImportData
{
	public int ID;
	public string JSON;
}



public class Manager : MonoBehaviour
{

	public static Manager Instance;

	public bool IsBlinking
	{
		get
		{
			return _isBlinking;
		}
		set
		{
			_isBlinking = value;
			BlinkImage.color = _isBlinking ? SelectedRotationColor : Color.white;
		}
	}
	bool _isBlinking;


	public Pipe SelectedPipe
	{
		get
		{
			return _selectedPipe;
		}
		set
		{
			_selectedPipe = value;
			foreach (var pipe in FindObjectsOfType<Pipe>())
			{
				pipe.RefreshColor(true);
			}
		}
	}

	Pipe _selectedPipe;

	[Header("Data")]
	public List<ImportData> Data;

	[Header("Statistics")]
	public Image SaveImage;
	public Image BlinkImage;
	public Text Statistics_All;
	public Text Statistics_Short;
	public Text Statistics_Long;
	public Text Statistics_Bend;
	public Text Statistics_Corner;
	public Text Statistics_CornerShort;
	public TextMeshProUGUI RecipeText;

	[Header("Confirm Panel")]
	public GameObject ConfirmPanel;
	public Text ConfirmPanelText;
	public string ConfirmPanelText_Restart;
	public string ConfirmPanelText_RestartAll;
	public string ConfirmPanelText_DeleteAllPrevious;
	public string ConfirmPanelText_DeleteAllNext;

	[Header("Camera Movement Panel")]
	public Text CameraMovementAmountButton_Text;

	[Header("Camera Rotation Panel")]
	public Text CameraRotationAmountButton_Text;
	public int[] CameraRotationAmounts;

	[Header("Raw Data")]
	public GameObject RawData;
	public InputField RawDataText;

	[Header("Other")]
	public InputField DreamName;
	public Text SelectedDream;
	public Color SelectedRotationColor;
	public Transform PipeRoot;
	public Pipe ShortPipePrefab;
	public Pipe LongPipePrefab;
	public Pipe BendPipePrefab;
	public Pipe CornerPipePrefab;
	public Pipe CornerShortPipePrefab;
	public Slider ThicknessSlider;
	public Text ThicknessText;

	public Transform CameraPivot;

	public Image[] RotationAmountButtons;
	public int[] RotationAmounts;
	public Color[] BackgroundColor;

	public int RotateAmount = 90;
	public float RotateX;
	public float RotateY;
	public float PipeRotateX;
	int BackgroundColorOffset = 0;
	Pipe StartPipe;
	bool IsDirty;
	UnityAction ConfirmAction;

	internal float Thickness = 1;

	public void SetThickness(float value)
	{
		Thickness = value / 10f;
		ThicknessText.text = string.Format("Thickness: {0:F1}", Thickness);
	}

	int CameraRotationAmount
	{
		get
		{
			return _cameraRotationAmount;
		}
		set
		{
			_cameraRotationAmount = value;
			CameraRotationAmountButton_Text.text = value.ToString();
		}
	}
	int _cameraRotationAmount = 15;

	int CameraMovementAmount
	{
		get
		{
			return _cameraMovementAmount;
		}
		set
		{
			_cameraMovementAmount = value;
			CameraMovementAmountButton_Text.text = value.ToString();
		}
	}
	int _cameraMovementAmount = 15;

	public int SaveIndex
	{
		get
		{
			return _saveIndex;
		}
		set
		{
			value = Mathf.Clamp(value, 1, 99);



			_saveIndex = value;
			SelectedDream.text = String.Format("Dream {0:D2}/{1:D2}", _saveIndex, 99);
			Restore(SaveData.LoadPipe(SaveIndex));
			IsDirty = false;
		}
	}

	public SaveData Clipboard { get; private set; }

	public Vector3 PipeRootPos
	{
		get
		{
			return PipeRoot.transform.localPosition;
		}
		set
		{
			PipeRoot.transform.localPosition = value;
			IsDirty = true;
		}
	}

	public Vector3 PipeRootPos_Global
	{
		get
		{
			return PipeRoot.transform.position;
		}
		set
		{
			PipeRoot.transform.position = value;
			IsDirty = true;
		}
	}


	int _saveIndex = 1;

	public void ChangeBackgroundColor()
	{
		BackgroundColorOffset++;
		if (BackgroundColorOffset >= BackgroundColor.Length) BackgroundColorOffset = 0;
		Camera.main.backgroundColor = BackgroundColor[BackgroundColorOffset];
	}

	void OnEnable()
	{
		CameraRotationAmount = CameraRotationAmount; //Reset rotation amount text
		CameraMovementAmount = CameraMovementAmount;

		IsBlinking = true;
		Instance = this;
		SaveIndex = 1;
		SelectedPipe = StartPipe;
		SetRotationAmount(RotateAmount);
	}

	public void CycleRotationIncrement()
	{
		var index = Array.IndexOf(CameraRotationAmounts, CameraRotationAmount) + 1;
		if (index >= CameraRotationAmounts.Length) index = 0;
		CameraRotationAmount = CameraRotationAmounts[index];
	}

	public void CycleMovementAmount()
	{
		var index = Array.IndexOf(CameraRotationAmounts, CameraMovementAmount) + 1;
		if (index >= CameraRotationAmounts.Length) index = 0;
		CameraMovementAmount = CameraRotationAmounts[index];
	}

	public void ToggleBlink()
	{
		IsBlinking = !IsBlinking;
	}

	public void RestartAction()
	{
		SaveData.DeletePipe(SaveIndex);
		Restore(SaveData.LoadPipe(SaveIndex));
	}

	public void RestartAllAction()
	{
		PlayerPrefs.DeleteAll();
		PlayerPrefs.Save();
		RestartAction();
	}

	public void Restart()
	{
		ConfirmAction = RestartAction;
		ConfirmPanelText.text = ConfirmPanelText_Restart;
		ConfirmPanel.SetActive(true);
	}

	public void RestartAll()
	{
		ConfirmAction = RestartAllAction;
		ConfirmPanelText.text = ConfirmPanelText_RestartAll;
		ConfirmPanel.SetActive(true);
	}

	public void SetRotationAmount(int v)
	{
		for (var i = 0; i < RotationAmounts.Length; i++)
		{
			RotationAmountButtons[i].color = (v == RotationAmounts[i]) ? SelectedRotationColor : Color.white;
		}
		RotateAmount = v;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.LeftControl))
		{
			Camera.main.backgroundColor = new Color32(49, 77, 121, 255);
			var thisPipe = StartPipe;
			while (thisPipe)
			{
				thisPipe.Color = new Color32(128, 128, 128, 255);
				thisPipe = thisPipe.NextPipe;
			}
		}

		if (Input.GetMouseButtonDown(0))
		{
			var index = (TMP_TextUtilities.FindIntersectingCharacter(RecipeText, Input.mousePosition, null, true));
			if (index > -1)
			{
				var row = index / 6;
				var characterOffset = row * 5 + Mathf.Clamp(index % 6, 0, 5);

				SelectedPipe = StartPipe;
				while (characterOffset > 0 && SelectedPipe.NextPipe)
				{
					SelectedPipe = SelectedPipe.NextPipe;
					characterOffset--;
				}
			}
		}

		var blinktime = Time.time % 1;
		if (blinktime >= 0.5f && IsDirty)
		{
			SaveImage.color = SelectedRotationColor;
		}
		else
		{
			SaveImage.color = Color.white;
		}


		//Statistics refresh. Could be separated out into own method
		int shortCount = 0;
		int longCount = 0;
		int bendCount = 0;
		int cornerCount = 0;
		int allCount = 0;
		int cornerShortCount = 0;
		int offset = 0;

		RecipeText.text = "";
		var pipe = StartPipe;
		while (pipe)
		{
			if (pipe == SelectedPipe)
			{
				RecipeText.text += "<color=#ffdf7d>";
			}

			RecipeText.text += pipe.PipeType.ToString()[0];
			if (allCount % 5 == 4)
			{
				RecipeText.text += " ";
			}

			switch (pipe.PipeType)
			{
				case Pipe.PipeTypes.Bend:
					bendCount++;
					break;

				case Pipe.PipeTypes.Corner:
					cornerCount++;
					break;

				case Pipe.PipeTypes.Short:
					shortCount++;
					break;

				case Pipe.PipeTypes.Long:
					longCount++;
					break;

				case Pipe.PipeTypes.Torus:
					cornerShortCount++;
					break;
			}

			allCount++;
			if (pipe == SelectedPipe)
			{
				offset = allCount;
				RecipeText.text += "</color>";
			}

			pipe = pipe.NextPipe;
		}

		//Fill in the rest with blanks
		var recipeCount = allCount;
		while (recipeCount < 30)
		{
			RecipeText.text += "_";
			if (recipeCount % 5 == 4)
			{
				RecipeText.text += " ";
			}
			recipeCount++;
		}


		Statistics_Short.text = string.Format("{0:d2}", shortCount);
		Statistics_Long.text = string.Format("{0:d2}", longCount);
		Statistics_Bend.text = string.Format("{0:d2}", bendCount);
		Statistics_Corner.text = string.Format("{0:d2}", cornerCount);
		Statistics_CornerShort.text = string.Format("{0:d2}", cornerShortCount);
		Statistics_All.text = string.Format("{0:d2}/{1:d2}", offset, allCount);
	}

	public void PreviousPipe(int Offset)
	{
		while (Offset > 0 && SelectedPipe.PreviousPipe)
		{
			SelectedPipe = SelectedPipe.PreviousPipe;
			Offset -= 1;
		}
	}

	public void SetSaveIndex(int offset)
	{
		SaveIndex += offset;
	}

	public void NextPipe(int Offset)
	{
		while (Offset > 0 && SelectedPipe.NextPipe)
		{
			SelectedPipe = SelectedPipe.NextPipe;
			Offset -= 1;
		}
	}

	public void FirstPipe()
	{
		SelectedPipe = StartPipe;
	}

	public void LastPipe()
	{
		while (SelectedPipe.NextPipe)
		{
			SelectedPipe = SelectedPipe.NextPipe;
		}
	}

	internal void SetColor(Color color)
	{
		IsDirty = true;

		if (SelectedPipe.Color == color)
		{
			//Set the entire length of pipe to this color
			var pipe = StartPipe;
			while (pipe)
			{
				pipe.Color = color;
				pipe = pipe.NextPipe;
			}
		}
		else
		{
			SelectedPipe.Color = color;
		}

	}

	public void CyclePipeType()
	{
		IsDirty = true;
		var newPipeType = SelectedPipe.PipeType + 1;
		if (newPipeType > Pipe.PipeTypes.Torus)
		{
			newPipeType = Pipe.PipeTypes.Short;
		}

		ChangeCurrentPipe(newPipeType);
	}

	public void ChangeCurrentPipe(string letter)
	{
		switch (letter.ToLower())
		{
			case "s":
				ChangeCurrentPipe(Pipe.PipeTypes.Short);
				break;

			case "b":
				ChangeCurrentPipe(Pipe.PipeTypes.Bend);
				break;

			case "c":
				ChangeCurrentPipe(Pipe.PipeTypes.Corner);
				break;

			case "l":
				ChangeCurrentPipe(Pipe.PipeTypes.Long);
				break;

			case "t":
				ChangeCurrentPipe(Pipe.PipeTypes.Torus);
				break;
		}
	}

	private void ChangeCurrentPipe(Pipe.PipeTypes newPipeType)
	{
		var oldPipe = SelectedPipe;
		var previousPipe = SelectedPipe.PreviousPipe;
		var nextPipe = SelectedPipe.NextPipe;

		switch (newPipeType)
		{
			case Pipe.PipeTypes.Bend:
				SelectedPipe = Instantiate(BendPipePrefab);
				break;

			case Pipe.PipeTypes.Corner:
				SelectedPipe = Instantiate(CornerPipePrefab);
				break;

			case Pipe.PipeTypes.Short:
				SelectedPipe = Instantiate(ShortPipePrefab);
				break;

			case Pipe.PipeTypes.Long:
				SelectedPipe = Instantiate(LongPipePrefab);
				break;

			case Pipe.PipeTypes.Torus:
				SelectedPipe = Instantiate(CornerShortPipePrefab);
				break;
		}


		if (nextPipe)
		{
			SelectedPipe.NextPipe = nextPipe;
			nextPipe.PreviousPipe = SelectedPipe;
			nextPipe.transform.parent = SelectedPipe.EndPivot;
			nextPipe.transform.localPosition = Vector3.zero;
			nextPipe.transform.localRotation = Quaternion.identity;
		}

		if (previousPipe)
		{
			SelectedPipe.PreviousPipe = previousPipe;
			previousPipe.NextPipe = SelectedPipe;

			SelectedPipe.transform.parent = previousPipe.EndPivot;
			SelectedPipe.transform.localPosition = Vector3.zero;
			SelectedPipe.transform.localRotation = Quaternion.identity;
		}
		else
		{
			//If is first pipe
			SelectedPipe.transform.position = oldPipe.transform.position;
			SelectedPipe.transform.rotation = oldPipe.transform.rotation;
			SelectedPipe.transform.parent = PipeRoot.transform;
		}

		if (StartPipe == oldPipe)
		{
			StartPipe = SelectedPipe;
		}

		Destroy(oldPipe.gameObject);
	}

	public void NewShort()
	{
		NewPipe(ShortPipePrefab);
	}

	public void NewLong()
	{
		NewPipe(LongPipePrefab);
	}

	public void NewBend()
	{
		NewPipe(BendPipePrefab);
	}

	public void NewCorner()
	{
		NewPipe(CornerPipePrefab);
	}

	public void NewCornerShort()
	{
		NewPipe(CornerShortPipePrefab);
	}

	public void NewPipe(Pipe PipePrefab)
	{
		IsDirty = true;
		if (SelectedPipe)
		{
			while (SelectedPipe.NextPipe)
			{
				SelectedPipe = SelectedPipe.NextPipe;
			}
		}

		var newPipe = Instantiate(PipePrefab);

		if (SelectedPipe)
		{
			newPipe.transform.parent = SelectedPipe.EndPivot;
			SelectedPipe.NextPipe = newPipe;
			newPipe.PreviousPipe = SelectedPipe;
		}

		newPipe.transform.localPosition = Vector3.zero;
		newPipe.transform.localRotation = Quaternion.identity;
		SelectedPipe = newPipe;
	}

	public void SetRotateX(int value)
	{
		RotateX = value;
	}

	public void SetRotateY(int value)
	{
		RotateY = value;
	}

	public void RotateXAbsolute(int value)
	{
		PipeRoot.transform.Rotate(new Vector3(value * CameraRotationAmount, 0, 0), Space.World);
		IsDirty = true;
	}

	public void RotateYAbsolute(int value)
	{

		PipeRoot.transform.Rotate(new Vector3(0, value * CameraRotationAmount, 0), Space.World);
		IsDirty = true;
	}

	public void RotateZAbsolute(int value)
	{

		PipeRoot.transform.Rotate(new Vector3(0, 0, value * CameraRotationAmount), Space.World);
		IsDirty = true;
	}

	public void MoveX(int value)
	{
		PipeRootPos_Global += new Vector3(value * CameraMovementAmount / 15f, 0, 0); ;
	}

	public void MoveY(int value)
	{
		PipeRootPos_Global += new Vector3(0, value * CameraMovementAmount / 15f, 0);
	}

	public void MoveZ(int value)
	{
		PipeRootPos_Global += new Vector3(0, 0, value * CameraMovementAmount / 15);
	}



	public void SetPipeRotateX(int value)
	{
		SelectedPipe.Rotation += value * RotateAmount;
	}

	public void DeleteSelectedPipe()
	{
		var targetPipe = SelectedPipe;
		if (targetPipe.NextPipe)
		{
			SelectedPipe = targetPipe.NextPipe;
			DeletePipe(targetPipe);
		}
		else if (targetPipe.PreviousPipe)
		{
			SelectedPipe = targetPipe.PreviousPipe;
			DeletePipe(targetPipe);
		}
	}

	public void DeletePreviousPipe()
	{
		if (SelectedPipe.PreviousPipe)
		{
			DeletePipe(SelectedPipe.PreviousPipe);
		}
	}

	public void DeleteNextPipe()
	{
		if (SelectedPipe.NextPipe)
		{
			DeletePipe(SelectedPipe.NextPipe);
		}
	}

	public void DeletePreviousAll()
	{
		if (!SelectedPipe.PreviousPipe) return;
		ConfirmAction = DeletePreviousAllAction;
		ConfirmPanelText.text = ConfirmPanelText_DeleteAllPrevious;
		ConfirmPanel.SetActive(true);
	}

	public void DeletePreviousAllAction()
	{
		while (SelectedPipe.PreviousPipe)
		{
			DeletePipe(SelectedPipe.PreviousPipe);
		}
	}

	public void DeleteNextAll()
	{
		if (!SelectedPipe.NextPipe) return;
		ConfirmAction = DeleteNextAllAction;
		ConfirmPanelText.text = ConfirmPanelText_DeleteAllNext;
		ConfirmPanel.SetActive(true);
	}

	public void DeleteNextAllAction()
	{
		while (SelectedPipe.NextPipe)
		{
			DeletePipe(SelectedPipe.NextPipe);
		}
	}


	public void DeletePipe(Pipe TargetPipe)
	{
		//A middle piece
		if (TargetPipe.PreviousPipe && TargetPipe.NextPipe)
		{
			//Middle section, so join the two joining bits together
			var nextPipe = TargetPipe.NextPipe;
			var previousPipe = TargetPipe.PreviousPipe;
			Destroy(TargetPipe.gameObject);

			nextPipe.PreviousPipe = previousPipe;
			previousPipe.NextPipe = nextPipe;

			nextPipe.transform.parent = previousPipe.EndPivot;
			nextPipe.transform.localPosition = Vector3.zero;
			nextPipe.transform.localRotation = Quaternion.identity;
			IsDirty = true;
		}
		//Last piece, just cut off the ending
		else if (TargetPipe.PreviousPipe)
		{
			TargetPipe.PreviousPipe.NextPipe = null;
			Destroy(TargetPipe.gameObject);
			IsDirty = true;
		}
		//First piece, just cut off the start
		else if (TargetPipe.NextPipe)
		{
			TargetPipe.NextPipe.PreviousPipe = null;
			StartPipe = TargetPipe.NextPipe;
			StartPipe.transform.parent = PipeRoot.transform;
			PipeRoot.transform.position = StartPipe.transform.position;
			PipeRoot.transform.rotation = StartPipe.transform.rotation;
			StartPipe.transform.localPosition = Vector3.zero;
			StartPipe.transform.localRotation = Quaternion.identity;
			Destroy(TargetPipe.gameObject);
			IsDirty = true;
		}
	}

	public SaveData GetSaveData()
	{
		var saveData = new SaveData()
		{
			DreamName = DreamName.text,
			BackgroundColor = Camera.main.backgroundColor,
			Thickness = Thickness.ToString("F1"),
			PipeRootPos = PipeRootPos,
			PipeRootRot = PipeRoot.transform.localEulerAngles,
			PipeRootParentScale = PipeRoot.transform.parent.localScale,
			Recipe = "",
		};

		var pipe = StartPipe;
		var pieces = 0;
		int S = 0, L = 0, B = 0, C = 0, T = 0;

		while (pipe)
		{
			saveData.Pipes.Add(new PipeSaveData()
			{
				Rotation = pipe.Rotation,
				PipeType = pipe.PipeType.ToString()[0].ToString(),
				Color = pipe.Color
			});

			switch (pipe.PipeType)
			{
				case Pipe.PipeTypes.Short:
					S++;
					break;
				case Pipe.PipeTypes.Long:
					L++;
					break;
				case Pipe.PipeTypes.Bend:
					B++;
					break;
				case Pipe.PipeTypes.Corner:
					C++;
					break;
				case Pipe.PipeTypes.Torus:
					C++;
					break;
			}

			saveData.Recipe += pipe.PipeType.ToString()[0];
			if (pieces % 5 == 4)
			{
				saveData.Recipe += " ";
			}
			pieces++;

			pipe = pipe.NextPipe;
		}

		saveData.Spectrum_SLBCT = string.Format("{0},{1},{2},{3},{4}", S, L, B, C, T);
		saveData.Pieces = pieces;
		saveData.Store = SaveIndex;
		return saveData;
	}

	public void OnConfirm()
	{
		if (ConfirmAction != null)
		{
			ConfirmAction();
			ConfirmAction = null;
		}
		ConfirmPanel.SetActive(false);
	}

	public void Copy()
	{
		Clipboard = GetSaveData();
	}

	public void Paste()
	{
		if (Clipboard != null)
		{
			Restore(Clipboard);
		}
	}

	public void Save()
	{
		GetSaveData().Save(SaveIndex);
		IsDirty = false;
	}

	public void Reverse(int axis)
	{
		var scale = PipeRoot.parent.localScale;
		switch (axis)
		{
			case 0:
				scale.x *= -1;
				break;
			case 1:
				scale.y *= -1;
				break;
			case 2:
				scale.z *= -1;
				break;
		}
		PipeRoot.parent.localScale = scale;
		IsDirty = true;
	}

	public void OpenRawData()
	{
		RawDataText.text = JsonUtility.ToJson(GetSaveData(), true);
		RawData.gameObject.SetActive(true);
	}

	public void CloseRawData()
	{
		Restore(JsonUtility.FromJson<SaveData>(RawDataText.text));
		RawData.gameObject.SetActive(false);
	}

	/* come back to reversing
	public void ReverseDream()
	{
		//Get last pipe
		var pipe = StartPipe;
		while(pipe.NextPipe)
		{
			pipe = pipe.NextPipe;
		}

		//Go through pipes backwards
		var newStart = ClonePipe(pipe);
		pipe = pipe.PreviousPipe;

		while(pipe.PreviousPipe)
		{
			ClonePipe(pipe);
			pipe = pipe.PreviousPipe;
		}


		//StartPipe = NewPipe();

	}*/

	private object ClonePipe(Pipe pipe)
	{
		throw new NotImplementedException();
	}

	public void Restore(SaveData restoreData, bool reverse = false)
	{
		if (restoreData == null || restoreData.Pipes.Count == 0)
		{
			//Default setup
			restoreData = new SaveData();
			restoreData.Pipes.Add(new PipeSaveData() { Color = new Color(0.5f, 0.5f, 0.5f, 1), PipeType = "C", Rotation = 0 });
		}

		PipeRoot.transform.parent.localScale = restoreData.PipeRootParentScale;
		PipeRootPos = restoreData.PipeRootPos;
		PipeRoot.transform.localEulerAngles = restoreData.PipeRootRot;
		DreamName.text = restoreData.DreamName;
		ThicknessSlider.value = float.Parse(restoreData.Thickness) * 10;
		Camera.main.backgroundColor = restoreData.BackgroundColor;

		DeleteAllPipes();

		var pipes = restoreData.Pipes;
		if (reverse)
		{
			pipes.Reverse();
		}

		StartPipe = SelectedPipe = null;
		foreach (var pipeData in restoreData.Pipes)
		{
			if (int.TryParse(pipeData.PipeType, out int value))
			{
				pipeData.PipeType = ((Pipe.PipeTypes)value).ToString()[0].ToString();
			}

			switch (pipeData.PipeType)
			{
				case "B":
					NewBend();
					break;

				case "C":
					NewCorner();
					break;

				case "T":
					NewCornerShort();
					break;

				case "S":
					NewShort();
					break;

				case "L":
					NewLong();
					break;
			}

			if (!StartPipe)
			{
				StartPipe = SelectedPipe;
				StartPipe.transform.parent = PipeRoot;
				StartPipe.transform.localEulerAngles = StartPipe.transform.localPosition = Vector3.zero;
			}
			SelectedPipe.Color = pipeData.Color;
			SelectedPipe.Rotation = pipeData.Rotation;

		}
	}

	private void DeleteAllPipes()
	{
		//Delete all pipes and start from scratch
		var pipe = StartPipe;
		while (pipe)
		{
			var deletePipe = pipe;
			pipe = pipe.NextPipe;
			Destroy(deletePipe.gameObject);
		}
	}

	public void SetDirty()
	{
		IsDirty = true;
	}
}

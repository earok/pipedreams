using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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


	[Header("Statistics")]
	public Image SaveImage;
	public Image BlinkImage;
	public Text Statistics_All;
	public Text Statistics_Short;
	public Text Statistics_Long;
	public Text Statistics_Bend;
	public Text Statistics_Corner;
	public Text Statistics_CornerShort;

	[Header("Confirm Panel")]
	public GameObject ConfirmPanel;
	public Text ConfirmPanelText;
	public string ConfirmPanelText_Restart;
	public string ConfirmPanelText_RestartAll;

	[Header("Camera Movement Panel")]
	public Text CameraMovementAmountButton_Text;

	[Header("Camera Rotation Panel")]
	public Text CameraRotationAmountButton_Text;
	public int[] CameraRotationAmounts;

	[Header("Other")]
	public Text SelectedDream;
	public Color SelectedRotationColor;
	public Transform PipeRoot;
	public Pipe ShortPipePrefab;
	public Pipe LongPipePrefab;
	public Pipe BendPipePrefab;
	public Pipe CornerPipePrefab;
	public Pipe CornerShortPipePrefab;

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
		foreach (var pipe in FindObjectsOfType<Pipe>())
		{
			Destroy(pipe.gameObject);
		}

		SelectedPipe = StartPipe = null;
		CameraPivot.transform.position = CameraPivot.transform.eulerAngles = Vector3.zero;
		NewCorner();
		StartPipe = SelectedPipe;
		StartPipe.transform.parent = PipeRoot;
		StartPipe.transform.localPosition = StartPipe.transform.localEulerAngles = Vector3.zero;

		PipeRoot.transform.localPosition = new Vector3(0, 0, 10);
		PipeRoot.transform.localEulerAngles = new Vector3(90, 0, 180);
		Save();
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

		var pipe = StartPipe;
		while (pipe)
		{
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
			}

			pipe = pipe.NextPipe;
		}

		Statistics_Short.text = string.Format("{0:d2}", shortCount);
		Statistics_Long.text = string.Format("{0:d2}", longCount);
		Statistics_Bend.text = string.Format("{0:d2}", bendCount);
		Statistics_Corner.text = string.Format("{0:d2}", cornerCount);
		Statistics_CornerShort.text = string.Format("{0:d2}", cornerShortCount);
		Statistics_All.text = string.Format("{0:d2} / {1:d2}", offset, allCount);
	}

	public void PreviousPipe()
	{
		if (!SelectedPipe.PreviousPipe) return;
		SelectedPipe = SelectedPipe.PreviousPipe;
	}

	public void SetSaveIndex(int offset)
	{
		SaveIndex += offset;
	}

	public void NextPipe()
	{
		if (!SelectedPipe.NextPipe) return;
		SelectedPipe = SelectedPipe.NextPipe;
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

		if(SelectedPipe.Color == color)
		{
			//Set the entire length of pipe to this color
			var pipe = StartPipe;
			while(pipe)
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
		if(newPipeType > Pipe.PipeTypes.Torus)
		{
			newPipeType = Pipe.PipeTypes.Short;
		}

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
			SelectedPipe.transform.position = oldPipe.transform.position;
			SelectedPipe.transform.rotation = oldPipe.transform.rotation;
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
				NextPipe();
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
		//PipeRoot.transform.localEulerAngles += (new Vector3(0, value * 10, 0));
		PipeRoot.transform.Rotate(new Vector3(0, value * CameraRotationAmount, 0), Space.World);
	}

	public void RotateYAbsolute(int value)
	{

		PipeRoot.transform.Rotate(new Vector3(value * CameraRotationAmount, 0, 0), Space.World);
	}

	public void MoveX(int value)
	{
		PipeRoot.transform.position += new Vector3(value * CameraMovementAmount / 15f, 0, 0);
	}

	public void MoveY(int value)
	{
		PipeRoot.transform.position += new Vector3(0, value * CameraMovementAmount / 15f, 0);
	}

	public void MoveZ(int value)
	{
		PipeRoot.transform.position += new Vector3(0, 0, value * CameraMovementAmount / 15);
	}




	public void SetPipeRotateX(int value)
	{
		SelectedPipe.Rotation += value * RotateAmount;
	}

	public void DeletePipeLast()
	{
		//Don't allow deletion of the very last remaining pipe piece
		if (!SelectedPipe.PreviousPipe && !SelectedPipe.NextPipe) return;

		var lastPipe = SelectedPipe;
		while (lastPipe.NextPipe) lastPipe = lastPipe.NextPipe;

		if (lastPipe == SelectedPipe)
		{
			SelectedPipe = lastPipe.PreviousPipe;
		}
		Destroy(lastPipe.gameObject);
	}


	public void DeletePipe()
	{
		//A middle piece
		if (SelectedPipe.PreviousPipe && SelectedPipe.NextPipe)
		{
			//Middle section, so join the two joining bits together
			var nextPipe = SelectedPipe.NextPipe;
			var previousPipe = SelectedPipe.PreviousPipe;
			Destroy(SelectedPipe.gameObject);

			nextPipe.PreviousPipe = previousPipe;
			previousPipe.NextPipe = nextPipe;

			SelectedPipe = previousPipe;
			nextPipe.transform.parent = SelectedPipe.EndPivot;
			nextPipe.transform.localPosition = Vector3.zero;
			nextPipe.transform.localRotation = Quaternion.identity;
			SelectedPipe = nextPipe;
		}
		//Last piece, just cut off the ending
		else if (SelectedPipe.PreviousPipe)
		{
			SelectedPipe = SelectedPipe.PreviousPipe;
			Destroy(SelectedPipe.NextPipe.gameObject);
		}
		//First piece, just cut off the start
		else if (SelectedPipe.NextPipe)
		{
			StartPipe = SelectedPipe = SelectedPipe.NextPipe;
			Destroy(SelectedPipe.PreviousPipe.gameObject);
		}
	}

	public SaveData GetSaveData()
	{
		var saveData = new SaveData() { BackgroundColor = Camera.main.backgroundColor };
		var pipe = StartPipe;
		while (pipe)
		{
			saveData.Pipes.Add(new PipeSaveData()
			{
				Rotation = pipe.Rotation,
				PipeType = pipe.PipeType,
				Color = pipe.Color
			});
			pipe = pipe.NextPipe;
		}
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

	public void Restore(SaveData restoreData)
	{
		if (restoreData == null || restoreData.Pipes.Count == 0)
		{
			//Default setup
			restoreData = new SaveData();
			restoreData.Pipes.Add(new PipeSaveData() { Color = new Color(0.5f, 0.5f, 0.5f, 1), PipeType = Pipe.PipeTypes.Corner, Rotation = 0 });
		}

		Camera.main.backgroundColor = restoreData.BackgroundColor;

		//Delete all pipes and start from scratch
		var pipe = StartPipe;
		while (pipe)
		{
			var deletePipe = pipe;
			pipe = pipe.NextPipe;
			Destroy(deletePipe.gameObject);
		}

		StartPipe = SelectedPipe = null;
		foreach (var pipeData in restoreData.Pipes)
		{
			switch (pipeData.PipeType)
			{
				case Pipe.PipeTypes.Bend:
					NewBend();
					break;

				case Pipe.PipeTypes.Corner:
					NewCorner();
					break;

				case Pipe.PipeTypes.Torus:
					NewCornerShort();
					break;

				case Pipe.PipeTypes.Short:
					NewShort();
					break;

				case Pipe.PipeTypes.Long:
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

}

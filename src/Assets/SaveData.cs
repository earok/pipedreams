using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;


[Serializable]
public class SaveData
{
	public string DreamName = "Dream name";
	public string Recipe;
	public string Spectrum_SLBCT;
	public int Pieces;
	public int Store;
	public string Thickness = "1";
	public Color32 BackgroundColor = new Color32(49, 77, 121, 255);

	public List<PipeSaveData> Pipes = new List<PipeSaveData>();
	public Vector3 PipeRootPos;
	public Vector3 PipeRootRot;
	public Vector3 PipeRootParentScale = Vector3.one;

	public static void DeletePipe(int index)
	{
		PlayerPrefs.DeleteKey(index.ToString());
		PlayerPrefs.Save();
	}

	public static SaveData LoadPipe(int index)
	{
		var result = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(index.ToString()));
		if (result == null)
		{
			if (Manager.Instance.Data.Any(p => p.ID == index))
			{
				result = JsonUtility.FromJson<SaveData>(Manager.Instance.Data.First(p => p.ID == index).JSON);
			}

			if (result == null)
			{
				result = new SaveData();
			}
		}
		return result;
	}

	public void Save(int index)
	{
		PlayerPrefs.SetString(index.ToString(), JsonUtility.ToJson(this));
		PlayerPrefs.Save();
	}
}

[Serializable]
public class PipeSaveData
{
	public string PipeType;
	public int Rotation;
	public Color32 Color;
}


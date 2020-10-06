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
	public Color BackgroundColor = new Color(49 / 255f, 77 / 255f, 121 / 255f);
	public List<PipeSaveData> Pipes = new List<PipeSaveData>();
	public Vector3 PipeRootPos;
	public Vector3 PipeRootRot;

	public static SaveData LoadPipe(int index)
	{
		var result = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(index.ToString()));
		if (result == null) return new SaveData();
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
	public Pipe.PipeTypes PipeType;
	public int Rotation;
	public Color Color;
}


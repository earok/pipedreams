using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PipeJoiner
{
	public Transform Pipe;
	public Transform PipeConnector;
}

[Serializable]
public class ScaleRoot
{
	public Transform Transform;
	public Vector3 Modifier;
}

public class Pipe : MonoBehaviour
{
	public enum PipeTypes { Short, Long, Bend, Corner, Torus }
	public PipeTypes PipeType;

	public PipeJoiner[] PipeJoiners;
	public MeshRenderer[] MeshRenderers;
	public ScaleRoot[] ScaleRoots;
	public Transform EndPivot;
	public Transform EndPivotReal;

	public Pipe PreviousPipe;
	public Pipe NextPipe;

	Color _color = Color.gray;
	float refreshTime;
	bool blinkOn;

	public int Rotation
	{
		get
		{
			return _rotation;
		}
		set
		{
			_rotation = value;
			transform.localEulerAngles = (new Vector3(0, 0, value));
		}
	}
	int _rotation;

	public Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			_color = value;
			RefreshColor();
		}
	}

	public void RefreshColor(bool force = false)
	{
		if (force)
		{
			blinkOn = true;
		}

		var value = Color;
		if (this == Manager.Instance.SelectedPipe && blinkOn && Manager.Instance.IsBlinking)
		{
			Color.RGBToHSV(value, out float H, out float S, out float V);
			value = Color.HSVToRGB(H, S / 3, .9f);
		}
		blinkOn = !blinkOn;

		foreach (var meshRenderer in MeshRenderers)
		{
			meshRenderer.material.color = value;
		}

		refreshTime = Mathf.Clamp(refreshTime + .5f, 0, .5f);
	}

	public void Update()
	{
		refreshTime -= Time.deltaTime;
		if (refreshTime < 0)
		{
			RefreshColor();
		}

		if (EndPivotReal)
		{
			EndPivot.transform.position = EndPivotReal.transform.position;
		}

		foreach (var pipeJoiner in PipeJoiners)
		{
			pipeJoiner.Pipe.transform.position = pipeJoiner.PipeConnector.transform.position;
		}


		foreach (var sr in ScaleRoots)
		{
			sr.Transform.localScale = new Vector3(
				1 - (1 - Manager.Instance.Thickness) * sr.Modifier.x,
				1 - (1 - Manager.Instance.Thickness) * sr.Modifier.y,
				1 - (1 - Manager.Instance.Thickness) * sr.Modifier.z
				);
		}

	}
}

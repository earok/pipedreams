using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
	public enum PipeTypes { Short, Long, Bend, Corner, Torus }
	public PipeTypes PipeType;

	public MeshRenderer[] MeshRenderers;
	public Transform EndPivot;

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
	}
}

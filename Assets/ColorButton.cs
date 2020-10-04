using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
	public void OnEnable()
	{
		var button = GetComponent<Button>();
		var image = GetComponent<Image>();

		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(() =>
		{
			Manager.Instance.SetColor(image.color);
		});
	}
}

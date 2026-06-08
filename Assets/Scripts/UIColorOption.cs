using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
//using EditorUtility;

public class UIColorOption : MonoBehaviour , UnityEngine.EventSystems.IPointerClickHandler
{
    public ColorOption uiColorOption;
    public ColorPicker colorPicker;
    public TMP_Text colorOptionText;

    public AudioSource menuSound;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click.");
        colorPicker.activeColorOption = uiColorOption;
		//EditorUtility.SetDirty(colorPicker);
        menuSound.Play();
	}

    public void SetRef(ColorOption colorOptionParameter, ColorPicker colorPickerParameter)
    {
        uiColorOption = colorOptionParameter;
        colorPicker = colorPickerParameter;
        colorOptionText.text = colorOptionParameter.name;
    }
}

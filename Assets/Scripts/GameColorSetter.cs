using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameColorSetter : MonoBehaviour
{
    public MeshRenderer playerColor;

    public ColorPicker ColorPicker;

    void Start()
    {
        var colorOption = ColorPicker.activeColorOption;

        if (colorOption == null)
        {
            colorOption = ColorPicker.options[0];
        }

        RenderSettings.skybox = colorOption.skyboxColor;
        playerColor.material = colorOption.playerColor;
    }
}

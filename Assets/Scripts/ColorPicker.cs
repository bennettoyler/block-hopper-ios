using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ColorPicker : ScriptableObject
{
    public ColorOption[] options;
    public ColorOption activeColorOption;
}

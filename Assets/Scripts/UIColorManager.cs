using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIColorManager : MonoBehaviour
{
    public GameObject uiColorOptionPrefab;
    public ColorPicker colorPicker;

    private void OnEnable()
    {
        var colorChoices = colorPicker.options;

        Debug.Log("Enable");

        for (int i = 0; i < colorChoices.Length; i++)
        {
            var element = colorChoices[i];
            var prefab = Instantiate(uiColorOptionPrefab, transform);
            var result = prefab.GetComponent<UIColorOption>();
            result.SetRef(element, colorPicker);
            Debug.Log(i);
        }
    }

    private void OnDisable()
    {
        var children = transform.childCount;

        for (var i = 0; i < children; i++)
        {
            var child = transform.GetChild(i);

            Destroy(child.gameObject);
        }
    }
}

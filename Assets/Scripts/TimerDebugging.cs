using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TimerDebugging : MonoBehaviour, UnityEngine.EventSystems.IPointerClickHandler
{
    public TMP_Text timerDebug;
    
    public void Activate(string message)
    {
      gameObject.SetActive(true);
      timerDebug.text = (message);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      gameObject.SetActive(false);  
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressing;
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressing = true;
        Debug.Log("isPressing");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;
        Debug.Log("hasStoppedPressing");
    }
}

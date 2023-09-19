using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Image VJoystickBase;
    private Image VJoystickAnalog;
    public float offset;
    Vector2 pos = Vector2.zero;

    public Vector2 InputDir { set; get; }

    private void Start()
    {
        VJoystickBase = GetComponent<Image>();
        VJoystickAnalog = transform.GetChild(0).GetComponent<Image>();
        Debug.Log(VJoystickBase);
        Debug.Log(VJoystickAnalog);
        InputDir = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        float VJoystickBaseSizeX = VJoystickBase.rectTransform.sizeDelta.x;
        float VJoystickBaseSizeY = VJoystickBase.rectTransform.sizeDelta.y;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(VJoystickBase.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x /= VJoystickBaseSizeX;
            pos.y /= VJoystickBaseSizeY;
            InputDir = new Vector2(pos.x, pos.y);
            InputDir = InputDir.magnitude > 1 ? InputDir.normalized : InputDir;

            VJoystickAnalog.rectTransform.anchoredPosition = new Vector2(InputDir.x * (VJoystickBaseSizeX / offset), InputDir.y * (VJoystickBaseSizeY / offset));
            Debug.Log(InputDir);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputDir = Vector2.zero;
        VJoystickAnalog.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float inputHorizontal()
    {
        if (pos.x != 0)
        {
            return pos.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }
    public float inputVertical()
    {
        if (pos.y != 0)
        {
            return pos.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
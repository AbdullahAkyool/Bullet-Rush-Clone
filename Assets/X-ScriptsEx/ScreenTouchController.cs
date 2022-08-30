using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenTouchController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    private Vector2 touchPos;
    public Vector2 direction;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        touchPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        touchPos = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var delta = eventData.position - touchPos;
        direction = delta.normalized;
    }
}
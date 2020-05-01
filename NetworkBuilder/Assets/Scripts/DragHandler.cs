using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private GameObject dropZone;
    private bool isOverDrop = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDrop = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDrop = false;
        dropZone = null;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (isOverDrop)
        {
            transform.SetParent(dropZone.transform, false);
            Debug.Log(transform.gameObject.name);
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
    }
}

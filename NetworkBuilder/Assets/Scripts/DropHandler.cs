using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform inventory = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(inventory, Input.mousePosition))
        {
            Debug.Log("Dropped");
            //GameObject hallway = GameObject.Find("ItemLayoutHW");
            //Image[] cps = hallway.GetComponentsInChildren<Image>();

            //foreach (Image cp in cps)
            //{
            //    print(cp.name);
            //}
        }
    }
}

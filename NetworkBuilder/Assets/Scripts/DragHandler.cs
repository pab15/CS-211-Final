using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            foreach (Location location in GameManager.allLocations)
            {
                if (location.getLocationName() == transform.parent.gameObject.name)
                {
                    NetworkNode newNode = new NetworkNode(transform.gameObject.name, location);
                    GameManager.graph.addNode(newNode);
                    GameManager.graph.setGraph(GameManager.graph.findFinalGraph().getGraph());
                    foreach (NetworkNode key in GameManager.graph.getGraph().Keys.ToList())
                    {
                        foreach (NodeConnections connection in GameManager.graph.getGraph()[key])
                        {
                            GameManager.exposeLine(GameManager.connectionLines, connection);
                        }
                    }
                    break;
                }
            }
            Debug.Log(transform.gameObject.name);
            Debug.Log(transform.parent.gameObject.name);
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
    }
}

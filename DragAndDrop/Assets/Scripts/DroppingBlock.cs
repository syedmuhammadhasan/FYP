using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppingBlock : MonoBehaviour, IDropHandler
{
    //FindObjectOfType<DragingBlocks>().oldPosition;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if(eventData.pointerDrag!=null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().transform.position = FindObjectOfType<InstaiatedObjectScript>().oldPosition;
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = FindObjectOfType<DragingBlocks>().oldPosition;
            Debug.Log(transform.position);
        }
        
    }
}

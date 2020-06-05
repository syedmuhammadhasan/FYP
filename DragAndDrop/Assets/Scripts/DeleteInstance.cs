using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteInstance : MonoBehaviour, IDropHandler
{
    //FindObjectOfType<DragingBlocks>().oldPosition;
    //GameObject destroyObject
   
    public void OnDrop(PointerEventData eventData)
    {
        // Debug.Log(destroyObject);
        //Debug.Log("OnDropDelet");
        if(eventData.pointerDrag.tag != "ErrorDialogueCanvas")
        {
            Debug.Log(eventData.pointerDrag.tag);
            Destroy(eventData.pointerDrag);
        }
        

        //if (eventData.pointerDrag != null)
        //{
            
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = FindObjectOfType<DragingBlocks>().oldPosition;
           // Debug.Log("Destroyed");
        //}

    }
}

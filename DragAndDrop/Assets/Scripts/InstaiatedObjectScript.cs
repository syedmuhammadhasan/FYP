using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InstaiatedObjectScript : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    GameObject canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    //[SerializeField]  public  Canvas deleteCanvas;
    //CanvasGroup deleteInstancecanvasGroup;
    public Vector3 oldPosition;

    // public GameObject prefabgameObject;

    private void Awake()
    {
        //var obj = FindObjectOfType<Instant>().obj;
        canvas = GameObject.FindGameObjectWithTag("LevelScreenCanvas");
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        

    }
    void Start()
    {
        //deleteCanvas = GameObject.FindGameObjectWithTag("ImageDeleteCanvas");
        //deleteCanvas = FindObjectOfType(typeof(GameObject));
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
        canvasGroup.alpha = 0.7f;
        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.GetComponent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EngDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        oldPosition = transform.position;
        //deleteCanvas.
        //Debug.Log(deleteinstanceImage);
      //  deleteInstancecanvasGroup = deleteCanvas.GetComponent<CanvasGroup>();
        //deleteInstancecanvasGroup.alpha = 0.5f;
        //   Instantiate(prefabgameObject, oldPosition, transform.rotation);
        //  Debug.Log("Copy Created");
    }

}


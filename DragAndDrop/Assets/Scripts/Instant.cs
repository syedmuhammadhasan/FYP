using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*public class Instant : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    GameObject canvas;
    //[SerializeField] Canvas canvas2;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    //public GameObject prefabgameObject;
    public bool isInWorkspace = false;
    private Vector3 oldPosition;
    private void Awake()
    {
        //rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        oldPosition = transform.position;

    }
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("LevelScreenCanvas");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isInWorkspace)
        {
            var obj = Instantiate(this, transform.position, transform.rotation);
            obj.GetComponent<Instant>().isInWorkspace = true;
            obj.transform.SetParent(canvas.transform, false);
            Debug.Log("Intantiated");
            //rectTransform = obj.GetComponent<RectTransform>();
        }


    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isInWorkspace)
        {
            Debug.Log("BeginDrag");
            canvasGroup.alpha = 0.7f;
            canvasGroup.blocksRaycasts = false;
            rectTransform = GetComponent<RectTransform>();
        }
    }
        public void OnDrag(PointerEventData eventData)
    {
        if (isInWorkspace)
        {
            Debug.Log("OnDrag");

            rectTransform.anchoredPosition += eventData.delta; // canvas.GetComponent<Canvas>().scaleFactor;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (isInWorkspace)
        {
            Debug.Log("EngDrag");
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
    }
 }
*/
public class Instant : MonoBehaviour, IPointerDownHandler
{
    GameObject canvas;
    public GameObject prefab;
    public Vector3 pos;
    public GameObject obj;
    //bool instance;
    //GameObject CheckPrefabinCanvas;
    //bool firstInstanceCreated = false;
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("LevelScreenCanvas");
        pos = gameObject.transform.localPosition;
        //pos = new Vector3(-200,270, 0);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //pos = new Vector3(-200, 270, 0);
        if (GameObject.FindObjectOfType<instanceChecker>().InstanceCreated)
        {
            //pos = new Vector3(0, 0, 0);
        }
        ///var pos = transform.position;
         obj = Instantiate(prefab, pos, transform.rotation);
        GameObject.FindObjectOfType<instanceChecker>().InstanceCreated = true;
        // obj.GetComponent<Instant>().isInWorkspace = true;
        obj.transform.SetParent(canvas.transform, false);
        Debug.Log("Intantiated");
      //  firstInstanceCreated = true;
    }
}
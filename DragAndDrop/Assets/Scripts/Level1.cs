using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 12f;
    public float fastSpeed = 60f;
    public float freeLook = 2.5f;
    public float zoomScene = 10f;
    public float fastZoomScene = 50f;
    private bool looking = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var fastMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        var movementSpeed = fastMode ? this.fastSpeed : this.movementSpeed;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + (-transform.right * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + (transform.right * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + (transform.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + (-transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.position = transform.position + (-transform.up * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = transform.position + (transform.up * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.PageUp))
        {
            transform.position = transform.position + (Vector3.up * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.PageDown))
        {
            transform.position = transform.position + (-Vector3.up * movementSpeed * Time.deltaTime);
        }

        if (looking)
        {
            float nRotX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") + freeLook;
            float nRotY = transform.localEulerAngles.x + Input.GetAxis("Mouse Y") + freeLook;
            transform.localEulerAngles = new Vector3(nRotY, nRotX, 0f);
        }
        float axis = Input.GetAxis("Mouse ScrollWheel");
        if (axis!= 0)
        {
            var ZoomSceneL = fastMode ? this.fastZoomScene : this.zoomScene;
            transform.position = transform.position + transform.forward * axis * ZoomSceneL;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartLooking();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StopLooking();
        }
    }
    public void StartLooking()
    {
        looking = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void StopLooking()
    {
        looking = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }
    private void OnDisable()
    {
        StopLooking();
    }
}

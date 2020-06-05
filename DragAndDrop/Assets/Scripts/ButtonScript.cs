using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] public Canvas canvas;
    //GameObject canvas;
    private void Start()
    {
      //  canvas = GameObject.FindGameObjectWithTag ( "ErrorDialogueCanvas" );
    }


    public void CloseErrorBox()
    {
        canvas.enabled = false;
    }
}

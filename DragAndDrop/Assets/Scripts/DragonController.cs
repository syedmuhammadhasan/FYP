using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DragonController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Dragon;
    public float moveSpeed = 0.5F;
    bool routineRunning;
    Node rootNode;
    //SphereCollider bodyCollider;
    
    public TextMeshProUGUI text;
    public GameObject canvas;
    //bool firstCardAppeared = false;


    
    public void activateCanvas()
    {
        if (canvas.activeSelf)
        {
            canvas.SetActive(false);
        }
        else
        {
            canvas.SetActive(true);
        }
    }
    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        while (routineRunning)
        {
            yield return new WaitForSeconds(0.1f);
        }
        routineRunning = true;
        var fromAngle = Dragon.transform.rotation;
        var toAngle = Quaternion.Euler(Dragon.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            Dragon.transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        Dragon.transform.rotation = toAngle;
        routineRunning = false;
    }
    IEnumerator MoveMe(float inTime)
    {
        
        while (routineRunning)
        {
            yield return new WaitForSeconds(0.1f);
        }
        routineRunning = true;
        for (var t = 0f; t < 0.0899; t += Time.deltaTime / inTime)
        {
            Debug.Log("SAD");
            Dragon.transform.Translate(Vector3.forward * Mathf.Clamp(1 * 6, -1, 1) * moveSpeed * Time.deltaTime);
            yield return null;
        }
        routineRunning = false;
    }

    IEnumerator FlyMe(float inTime)
    {

        while (routineRunning)
        {
            yield return new WaitForSeconds(0.1f);
        }
        routineRunning = true;
        for (var t = 0f; t < 0.0899; t += Time.deltaTime / inTime)
        {
            //Debug.Log("SAD");
            Dragon.transform.Translate(Vector3.up * Mathf.Clamp(1 * 6, -1, 1) * moveSpeed * Time.deltaTime);
            yield return null;
        }
        routineRunning = false;
    }
    void Update()
    {
        
        if (Input.GetKeyDown("e"))
        { 
            StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));
        }
        if (Input.GetKeyDown("q"))
        {
            StartCoroutine(RotateMe(Vector3.up * -90, 0.8f));
        }
        if (Input.GetKeyDown("w"))
        {
            Fly();
        }
        if (Input.GetKeyDown("z"))
            MoveForward();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            run();
        }
        CollisionDetection[] CollisionDetections = FindObjectsOfType<CollisionDetection>();
        if (CollisionDetections.Length > 0)
        {
            rootNode = CollisionDetections[CollisionDetections.Length - 1].node;
            if (canvas.activeSelf)
                text.text = processNodeText(rootNode, 10);
        }

    }

    void MoveForward()
    {
        StartCoroutine(MoveMe(0.8f));
    }

    void Fly()
    {
        StartCoroutine(FlyMe(0.8f));
    }

    void RotateRight()
    {
        StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));

    }

    void RotateLeft()
    {
        StartCoroutine(RotateMe(Vector3.up * -90, 0.8f));
    }

    Node a;

    void Start()
    {
        moveSpeed = 0.8f;
        routineRunning = false;
        /*a = new Node("moveForward()");
        a.down = new Node("moveForward()");
        a.down.down = new Node("rotateLeft()");
        a.down.down.down = new Node("moveForward()");
        a.down.down.down.down = new Node("moveForward()");
        a.down.down.down.down.down = new Node("rotateLeft()");
        a.down.down.down.down.down.down = new Node("moveForward()");
        a.down.down.down.down.down.down.down = new Node("moveForward()");
        a.down.down.down.down.down.down.down.down = new Node("rotateLeft()");
        a.down.down.down.down.down.down.down.down.down = new Node("moveForward()");
        a.down.down.down.down.down.down.down.down.down.down = new Node("moveForward()");
        a.down.down.down.down.down.down.down.down.down.down.down = new Node("rotateLeft()");*/

        a = new Node("LOOP");
        a.right = new Node("4");
        a.right.down = new Node("LOOP");
        a.right.down.right = new Node("4");
        a.right.down.right.down = new Node("moveForward()");
        a.right.down.down = new Node("rotateRight()");
        Debug.Log(processNodeText(a, 10));


    }

    

    
    public void processNode(Node input_node)
    {
        Debug.Log("processss");
        Node temp = input_node;
        while (temp != null)
        {
            if (temp.code == "LOOP")
            {
                //count--;
                processLoop(temp);
            }

            else if (temp.code == "moveForward()")
            {
                MoveForward();
            }

            else if (temp.code == "moveBackward()")
            {
                
            }

            else if (temp.code == "rotateLeft()")
            {
                RotateLeft();
            }

            else if (temp.code == "rotateRight()")
            {
                RotateRight();
            }
            temp = temp.down;
        }
        
    }
    public string processNodeText(Node input_node, int count)
    {
        string code = "";
        Node temp = input_node;
        while (temp != null)
        {
            if (temp.code == "LOOP")
            {
                
                code += processLoopText(temp, --count) + "\n";
            }
            else
                code += temp.code + "\n";

            temp = temp.down;
        }
        return code;
        
        
    }

    private string processLoopText(Node temp, int count1)
    {
        if (count1 == 0)
            return null;
        string code = "";
        if (temp.right != null)
        {
            int count = 0;
            try
            {
                count = Int32.Parse(temp.right.code);
            }

            catch
            {
                Debug.Log("");
            }
             
            code = "for (int i = 0; i <" + count + "; i++) \n {";
            code = code + processNodeText(temp.right.down, --count1) + "}";
        }
        return code;
    }

    public void run()
    {
        if (rootNode != null)
        {
            Debug.Log(rootNode.code);

            processNode(rootNode);
        }
        
    }
    public void processLoop(Node input_node)
    {
        int count = Int32.Parse(input_node.right.code);
        for (int i = 0; i < count; i++)
        {
            processNode(input_node.right.down);
        }
    }

    


    // Update is called once per frame
    


}
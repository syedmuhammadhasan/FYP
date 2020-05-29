using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    Vector3 pos;
    GameObject canvas;
    void Start()
    {
        pos = FindObjectOfType<Instant>().pos;
        canvas = GameObject.FindGameObjectWithTag("LevelScreenCanvas");
        pos = gameObject.transform.localPosition;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collider Enter");
        //var connectingNode = collision.gameObject.GetComponent<detect>().node;
        // if (!this.node.connected || !connectingNode.connected)
        //{
        if (collision.GetType() == typeof(PolygonCollider2D))
        {

            //Debug.Log(collision.gameObject.GetComponent<detect>().node.code);
            // this.node.connected = true;
            // connectingNode.connected = true;
            // node.down = connectingNode;
            // Node connection
            Debug.Log("connected to down");
            //collision.transform.SetParent(canvas.transform, false);
            Debug.Log(pos);
            //pos = transform.position;

            collision.transform.localPosition = new Vector3(pos.x, pos.y - 210, 0);
            
            //collision.transform.localPosition = new Vector3(a.x, a.y - 160, 0);
            // .transform.position = pos;
            Debug.Log(collision.transform.position);
            //collision.transform.position = new Vector3 (pos.x + 200,pos.y - 100, 0);
            //collision.transform.position = new Vector3(pos.x , pos.y -120, 0);
            //pos = collision.transform.position;

            //Debug.Log(collision.gameObject.tag);
        }



        else if (collision.GetType() == typeof(CapsuleCollider2D))
        {

            //this.node.connected = true;
            //connectingNode.connected = true;
            //node.right = connectingNode;
            Debug.Log("connected to right");
            collision.transform.localPosition = new Vector3(pos.x + 210, pos.y, 0);
            // do stuff only for the circle collider
        }
    }
        
    //}


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Collided Stayed");
        //var connectingNode = collision.gameObject.GetComponent<detect>().node;
        //if (!this.node.connected || !connectingNode.connected)
        //{
        if (collision.GetType() == typeof(PolygonCollider2D))
        {

            //Debug.Log(collision.gameObject.GetComponent<detect>().node.code);
            //this.node.connected = true;
            //connectingNode.connected = true;
            //node.down = connectingNode;
            // Node connection
            collision.transform.localPosition = new Vector3(pos.x, pos.y - 210, 0);
            Debug.Log("connected to down");
        }



         else if (collision.GetType() == typeof(CapsuleCollider2D))
         {
               // this.node.connected = true;
               // connectingNode.connected = true;
               // node.right = connectingNode;
                Debug.Log("connected to right");
            collision.transform.localPosition = new Vector3(pos.x + 210, pos.y, 0);
            // do stuff only for the circle collider
         }
         pos = collision.transform.localPosition;
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Collided Exit");
        //var connectingNode = collision.gameObject.GetComponent<detect>().node;

        if (collision.GetType() == typeof(PolygonCollider2D))
        {
            Debug.Log("exited down");
           // pos = new Vector3(0, 0, 0);
            //node.down = null;
        }

        else if (collision.GetType() == typeof(CapsuleCollider2D))
        {
            Debug.Log("exited right");
            //pos = new Vector3(0, 0, 0);
            //node.right = null;
        }

        //node.connected = false;
        //connectingNode.connected = false;

    }


    void Update()
    {
        pos = gameObject.transform.localPosition;
    }

}

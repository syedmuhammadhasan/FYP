using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public Node node;
    Vector3 pos;
    GameObject canvas;
    GameObject ErrorBoxPrefab;
    //GameObject errorBox;
    //GameObject countcanvas;
    [SerializeField] public string text;
    
    float colliderHeight;
    
    void Start()
    {
        ErrorBoxPrefab = GameObject.FindGameObjectWithTag("ErrorDialogueCanvas");
       // countcanvas = GameObject.FindGameObjectWithTag("CountCanvas");
        //pos = FindObjectOfType<Instant>().pos;
        canvas = GameObject.FindGameObjectWithTag("LevelScreenCanvas");
        pos = gameObject.transform.localPosition;
        node = new Node(text);
        colliderHeight = GetComponent<BoxCollider2D >().size.y;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        pos = gameObject.transform.localPosition;
        Debug.Log("Collider Enter");
        var connectingNode = collision.gameObject.GetComponent<CollisionDetection>().node;
        // if (!this.node.connected || !connectingNode.connected)
        //{
        if (collision.GetType() == typeof(PolygonCollider2D))
        {
            if (collision.tag == "Obstacle" || collision.tag == "count")
            {
                var errorBox = Instantiate(ErrorBoxPrefab, collision.transform.localPosition, collision.transform.localRotation);
                errorBox.transform.SetParent(collision.transform, true);
            }
            else
            {
                if (node.code == "LOOP")
                {
                    var collider = GetComponent<BoxCollider2D>();
                    float top = collider.offset.y + (collider.size.y / 2f);
                    float btm = collider.offset.y - (collider.size.y / 2f);
                    collision.transform.localPosition = new Vector3(pos.x, pos.y - (top - btm), 0);
                }

                else
                    collision.transform.localPosition = new Vector3(pos.x, pos.y - 180, 0);


                collision.GetComponent<CapsuleCollider2D>().enabled = false;
                node.down = connectingNode;
                // Node connection
                Debug.Log("connected to down");
                
                Debug.Log(pos);
                Debug.Log(collision.transform.position);
               
            }


        }



        else if (collision.GetType() == typeof(CapsuleCollider2D))
        {
           
            collision.GetComponent<PolygonCollider2D>().enabled = false;
            //this.node.connected = true;
            //connectingNode.connected = true;
            node.right = connectingNode;
            Debug.Log("connected to right");
            collision.transform.localPosition = new Vector3(pos.x + 180, pos.y, 0);
          
            // do stuff only for the circle collider
        }
    }
        
    //}


    private void OnTriggerStay2D(Collider2D collision)
    {
        pos = gameObject.transform.localPosition;
        Debug.Log("Collided Stayed");
        
        var connectingNode = collision.gameObject.GetComponent<CollisionDetection>().node;
        //if (!this.node.connected || !connectingNode.connected)
        //{
        if (collision.GetType() == typeof(PolygonCollider2D))
        {
            if (node.code == "LOOP")
            {
                var collider = GetComponent<BoxCollider2D>();
                float top = collider.offset.y + (collider.size.y / 2f);
                float btm = collider.offset.y - (collider.size.y / 2f);
                collision.transform.localPosition = new Vector3(pos.x, pos.y - (top - btm), 0);
            }
            else
                collision.transform.localPosition = new Vector3(pos.x, pos.y - 180, 0);
            collision.GetComponent<CapsuleCollider2D>().enabled = false;
            
            //Debug.Log(collision.gameObject.GetComponent<detect>().node.code);
            //this.node.connected = true;
            //connectingNode.connected = true;
            node.down = connectingNode;
            // Node connection
            //collision.transform.localPosition = new Vector3(pos.x, pos.y - 180, 0);
            Debug.Log("connected to down");
        }



         else if (collision.GetType() == typeof(CapsuleCollider2D))
         {
            collision.GetComponent<PolygonCollider2D>().enabled = false;
            // this.node.connected = true;
            // connectingNode.connected = true;
             node.right = connectingNode;
            Debug.Log("connected to right");
            collision.transform.localPosition = new Vector3(pos.x + 180, pos.y, 0);
            // do stuff only for the circle collider
         }
        // pos = collision.transform.localPosition;
    }

   
    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Collided Exit");
        var connectingNode = collision.gameObject.GetComponent<CollisionDetection>().node;

        if (collision.GetType() == typeof(PolygonCollider2D))
        {
           
            collision.GetComponent<CapsuleCollider2D>().enabled = true;
            Debug.Log("exited down");
           // pos = new Vector3(0, 0, 0);
            node.down = null;
           // errorBox.GetComponent<Canvas>().enabled = false;
            
        }

        else if (collision.GetType() == typeof(CapsuleCollider2D))
        {
            
            collision.GetComponent<PolygonCollider2D>().enabled = true;
            Debug.Log("exited right");
            //pos = new Vector3(0, 0, 0);
            node.right = null;
        }

        //node.connected = false;
        //connectingNode.connected = false;

    }

    public float processNodeDistance(Node input_node)
    {
        Node temp = input_node;
        Node prev = null;
        while (temp != null)
        {
            if (temp.code == "LOOP" && temp.right != null && temp.right.down!=null)
            {

                return processNodeDistance(temp.right.down);
            }

            prev = temp;
            temp = temp.down;
        }
        return prev.distance;

    }

   /* void ColliderToMesh()
    {
        var collider = gameObject.GetComponent<BoxCollider2D>();
        float top = collider.offset.y + (collider.size.y / 2f);
        float btm = collider.offset.y - (collider.size.y / 2f);
        float left = collider.offset.x - (collider.size.x / 2f);
        float right = collider.offset.x + (collider.size.x / 2f);

        Vector3 topLeft = transform.TransformPoint(new Vector3(left, top, 0f));
        Vector3 topRight = transform.TransformPoint(new Vector3(right, top, 0f));
        Vector3 btmLeft = transform.TransformPoint(new Vector3(left, btm, 0f));
        Vector3 btmRight = transform.TransformPoint(new Vector3(right, btm, 0f));

        var pc2 = gameObject.GetComponent<BoxCollider2D>();
        //Render thing
        int pointCount = 0;
        pointCount = 4;
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        Vector2[] points = { topLeft, topRight, btmLeft, btmRight };
        Vector3[] vertices = new Vector3[pointCount];
        Vector2[] uv = new Vector2[pointCount];
        for (int j = 0; j < pointCount; j++)
        {
            Vector2 actual = points[j];
            vertices[j] = new Vector3(actual.x, actual.y, 0);
            uv[j] = actual;
        }
        var Triangulator tr = new Triangulator(points);
        int[] triangles = tr.Triangulate();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mf.mesh = mesh;
    }
    */
    void Update()
    {
        node.distance = gameObject.transform.localPosition.y;
        if (node.code == "LOOP" && node.right != null && node.right.down != null)
        {
            var distance = processNodeDistance(node) - gameObject.transform.localPosition.y;
            var colliderbox = GetComponent<BoxCollider2D>();
            var multiplier = Mathf.Abs(distance / 180) + 1.4f;
            Debug.Log(multiplier);
            colliderbox.size = new Vector2(colliderbox.size.x,colliderHeight * multiplier);
            //collider.offset = new Vector2(collider.offset.x, (distance - transform.localPosition.y) / 2);
            colliderbox.offset = new Vector2(colliderbox.offset.x, distance/2);
            //colliderbox.Cast()
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public float distance;
    public Node right;
    public Node down;
    public string code;
    //public bool connected;
    public Node(string code)
    {
        this.distance = 0;
        this.code = code;
        this.right = null;
        this.down = null;
        //this.connected = false;
    }


}
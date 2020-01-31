using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class PlayerActions : MonoBehaviour
{
    public void ParseData(JToken action, JToken info) 
    {
        Debug.Log("Action: " + action + ", Info: " + info);
    }

    public void Left()
    {

    }
}

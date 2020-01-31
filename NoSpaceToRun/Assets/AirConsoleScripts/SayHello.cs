using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class SayHello : MonoBehaviour
{
    void Start()
    {
        AirConsole.instance.onMessage += OnMessage;
    }

    void OnMessage(int from, JToken data)
    {
        string action = (string)data["action"];
        int amount = (int)data["info"]["amount"];
        float torque = (float)data["info"]["torque"];
        Debug.Log("Got data: " + action);
    }
}

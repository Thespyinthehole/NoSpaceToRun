using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class PlayerActions : MonoBehaviour
{
    [System.Serializable]
    public class Team
    {
        public Transform holder;
        public Vector2 position;
    }

    public List<Team> teams;

    public void ParseData(JToken action, JToken info) 
    {
        switch (action.ToString())
        {
            case "joinTeam":
                JoinTeam((int)info["team"]);
                break;
            default:
                Debug.Log("Unknown: " + action);
                break;
        }
    }

    public void Left()
    {

    }

    void JoinTeam(int team)
    {
        Team currentTeam = teams[team - 1];
        CharacterResizer cr = GetComponent<CharacterResizer>();
        AdjustShipToBox box = currentTeam.holder.GetComponent<AdjustShipToBox>();
        transform.SetParent(currentTeam.holder);
        transform.localPosition = currentTeam.position * box.autoScale;
        cr.scaledTo = box;
        Debug.Log("Joining team " + team);
    }
}

using UnityEngine;
using System.Collections;

public class PlayerCoordinates : MonoBehaviour
{
    public void OnGUI()
    {
        GUI.Label (new Rect (10,Screen.height-20,200,80), "X = " + Mathf.Round((transform.position.x + 24)/2) + " Y= " + Mathf.Round((transform.position.z + 24)/2));

    }
}

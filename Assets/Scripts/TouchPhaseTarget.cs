//Attach this script to an empty GameObject
//Create some UI Text by going to Create>UI>Text.
//Drag this GameObject into the Text field to the Inspector window of your GameObject.

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchPhaseTarget : MonoBehaviour
{
    bool begunTouch = false;
    bool targetIsTouched = false;

    public GameObject target;


    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    
}

//Attach this script to an empty GameObject
//Create some UI Text by going to Create>UI>Text.
//Drag this GameObject into the Text field to the Inspector window of your GameObject.

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchPhaseSample : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;

    public Text m_Text;
    string message;

    bool begunTouch = false;
    bool sphereIsTouched = false;
    public float scaleSize = 0.05f;

    void Update()
    {
        //Update the Text on the screen depending on current TouchPhase, and the current direction vector
        m_Text.text = "Touch : " + message + "in direction" + direction;

        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider != null)
                {
                    GameObject touchedObject = hit.transform.gameObject;
                    if(touchedObject.transform.name == this.transform.name)
                    {
                        sphereIsTouched = true;
                    }

                    Debug.Log("Touched " + touchedObject.transform.name);

                }
            }
            
            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    if (sphereIsTouched)
                    {
                        begunTouch = true;
                    }
                    startPos = touch.position;
                    message = "Begun ";
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    direction = touch.position - startPos;
                    message = "Moving ";
                    break;

                case TouchPhase.Ended:
                    begunTouch = false;
                    // Report that the touch has ended when it ends
                    message = "Ending ";
                    break;
            }
        }

        if (begunTouch)
        {
            if (transform.localScale.x <= 6f) {
                transform.localScale += new Vector3(scaleSize, scaleSize, scaleSize);
            }
        } else
        {
            if (transform.localScale.x > 3f)
            {
                transform.localScale -= new Vector3(scaleSize, scaleSize, scaleSize);
            }

        }

    }
}

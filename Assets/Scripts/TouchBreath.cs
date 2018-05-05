using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchBreath : MonoBehaviour {

    public float maxSize;
    public float growFactor;
    public float waitTime;

    private float timer = 0;

    public Text uiText;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //StopCoroutine(ScaleDown());
                uiText.text = "TOUCH AND HOLD";
                StartCoroutine(ScaleUp());

            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                uiText.text = "RELEASE TOUCH";
                //StopCoroutine(ScaleUp());
                while (true) // this could also be a condition indicating "alive or dead"
                {
                    // yield return new WaitForSeconds(waitTime);

                    //timer = 0;
                    while (1 < transform.localScale.x)
                    {
                        //timer += Time.deltaTime;
                        transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                      //  yield return null;
                    }

                    //timer = 0;
                    //yield return new WaitForSeconds(waitTime);
                }
            }
        } else if (Input.GetTouch(0).phase == TouchPhase.Ended) {
            StartCoroutine(ScaleDown());
        }

    }

    /*
    void Start()
    {
        StartCoroutine(Scale());
    }
    */

    IEnumerator ScaleUp()
    {
        while (true) // this could also be a condition indicating "alive or dead"
        {
            // we scale all axis, so they will have the same value, 
            // so we can work with a float instead of comparing vectors
            while (maxSize > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }
            // reset the timer
            
        }
    }

    IEnumerator ScaleDown()
    {
        while (true) // this could also be a condition indicating "alive or dead"
        {
           // yield return new WaitForSeconds(waitTime);

            //timer = 0;
            while (1 < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }

            //timer = 0;
            //yield return new WaitForSeconds(waitTime);
        }
    }


    IEnumerator Scale()
    {
        float timer = 0;

        while (true) // this could also be a condition indicating "alive or dead"
        {
            // we scale all axis, so they will have the same value, 
            // so we can work with a float instead of comparing vectors
            while (maxSize > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }
            // reset the timer

            yield return new WaitForSeconds(waitTime);

            timer = 0;
            while (1 < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }

            timer = 0;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
   



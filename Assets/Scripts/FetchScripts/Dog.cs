using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    private bool nearBall = false;
    private bool isBallRight = true;
    

    // Update is called once per frame
    void Update()
    {
        Debug.Log(nearBall);
        if(nearBall==false)
        {
            MoveDog();
        }
    }

    private void MoveDog()
    {
        if(isBallRight==true)
        {
            transform.Translate(new Vector2(2, 0) * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector2(-2, 0) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            nearBall = true;
            Debug.Log("Dog has entered ball range.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            nearBall = false;
            if(collision.transform.position.x<gameObject.transform.position.x)
            {
                isBallRight = false;
            }
            else
            {
                isBallRight = true;
            }
            Debug.Log("Player has entered ball range.");
        }
    }
}

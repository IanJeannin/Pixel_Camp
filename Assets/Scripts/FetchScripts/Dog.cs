using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField]
    private GameObject ballObject;

    private bool nearBall = false;
    private bool isBallRight = true;
    private bool nearHuman = false;
    private bool isHumanRight = false;
    private bool hasBall = false;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(nearBall);
        if(nearBall==false)
        {
            if (ballObject.transform.position.x < gameObject.transform.position.x)
            {
                isBallRight = false;
            }
            else
            {
                isBallRight = true;
            }
            MoveDog();
        }
        if(nearHuman==false&&hasBall==true)
        {
            ReturnToHuman();
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

    private void ReturnToHuman()
    {
        if(isHumanRight==true)
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
            hasBall = true;
        }
        else if (collision.gameObject.tag =="Player")
        {
            nearHuman = true;
            Debug.Log("Dog has entered humans pat range.");
            hasBall = false;
        }
        else if(collision.gameObject.tag =="Boundary")
        {
            hasBall = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            nearBall = false;
            Debug.Log("Player has entered ball range.");
        }
        else if(collision.gameObject.tag == "Player")
        {
            nearHuman = false;
            if(collision.transform.position.x<gameObject.transform.position.x)
            {
                isHumanRight = false;
            }
            else
            {
                isHumanRight = true;
            }
        }
    }
}

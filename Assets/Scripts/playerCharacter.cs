using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCharacter : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private float accelerationForce = 20;

    [SerializeField]
    private float maxSpeed = 3;

    [SerializeField]
    private Rigidbody2D rb2d;

    private float horizontalInput;
    private bool isFacingRight = true;
    private bool isFishing=false;

    public GameObject currentInterObj = null;
    public InteractiveObject currentInterObjScript = null;
    public Inventory inventory;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("interObject"))
        {
            Debug.Log(collision.name);
            currentInterObj = collision.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractiveObject>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("interObject"))
        {
            if (collision.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
    }
    
    private void FixedUpdate()
    {
        if (isFishing != true)
        {
            Move();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        PickUpStick();

    }

    private void PickUpStick()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            if (currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);
                currentInterObj.SetActive(false);
            }

        }
    }

    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0 && isFacingRight != true)
        {
            isFacingRight = true;
            Flip();
        }
        else if (horizontalInput < 0 && isFacingRight != false)
        {
            isFacingRight = false;
            Flip();
        }

        rb2d.AddForce(Vector2.right * horizontalInput * accelerationForce);
        Vector2 clampedVelocity = rb2d.velocity;
        clampedVelocity.x = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = clampedVelocity;
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("isWalking 0", true);

        }
        else
        {
            animator.SetBool("isWalking 0", false);
        }
    }


    private void Flip()
    {
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
    }

    public void CheckFishing()
    {
        isFishing = !isFishing;
    }
}

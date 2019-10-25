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
    private bool isFacingRight;
    // Start is called before the first frame update


    public GameObject currentInterObj = null;
    public InteractiveObject currentInterObjScript = null;
    public Inventory inventory;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); 
        if(horizontalInput>0)
        {
            isFacingRight = true;
        }
        else if(horizontalInput<0)
        {
            isFacingRight = false;
        }
        if (Input.GetButtonDown ("Interact") && currentInterObj)
        {
            if (currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);
                currentInterObj.SetActive(false);
            }
            
        }
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
        rb2d.AddForce(Vector2.right * horizontalInput * accelerationForce);
        Vector2 clampedVelocity = rb2d.velocity;
        clampedVelocity.x = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = clampedVelocity;
        Flip();
        if(Input.GetAxis("Horizontal")!=0)
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
        if(horizontalInput>0&&isFacingRight!=true||horizontalInput<0&&isFacingRight!=false)
        {
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}

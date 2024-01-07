using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{


    public Rigidbody2D rigidbody2D;
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        HandleMovementInput();

        /*
                if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Jump")==0)
                {

                    rigidbody2D.velocity = new Vector2(speed, 0f);

                }
                else if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Jump") == 0)
                {
                    rigidbody2D.velocity = new Vector2(-speed, 0f);

                }
                else if(Input.GetAxis("Vertical")> 0 && Input.GetAxis("Jump") == 0)
                {
                    rigidbody2D.velocity = new Vector2( 0f, speed);

                }
                else if(Input.GetAxis("Vertical") < 0 && Input.GetAxis("Jump") == 0)
                {
                    rigidbody2D.velocity = new Vector2(0f ,- speed);
                }
                else if(Input.GetAxis("Horizontal")==0 & Input.GetAxis("Horizontal")==0)
                {

                    rigidbody2D.velocity = new Vector2(0f, 0f);
                }

                */
     

    }


    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 inputVector = new Vector2(horizontalInput, verticalInput).normalized;

        if (inputVector != Vector2.zero && Input.GetAxis("Jump") == 0)
        {
            transform.Translate(inputVector * speed * Time.deltaTime);
        }
      
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="door")
            Debug.Log("you won");
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 10;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        rb.velocity = movement * speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = 5;
        }
        else
        {
            speed = 10;
        }

        
    }
}

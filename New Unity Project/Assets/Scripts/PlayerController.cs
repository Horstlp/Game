using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 10;
    private bool isFacingRight = true;
    private bool InvOn = false;
    public GameObject Inventory;
    public Rigidbody2D rb;
    public Animator animator;
    
    public int gold_Coins;
    public int silver_Coins;

    public void AddGold(int amount)
    {
        gold_Coins += amount;
    }
    public void AddSilver(int amount)
    {
        silver_Coins += amount;
    }

    //PlayerController.AddGold(goldmenge)     Wenn ihr im anderem script gold hinzufügen oder entfernen wollt
    //PlayerController.AddSilver(silbermenge)     Wenn ihr im anderem script Silber hinzufügen oder entfernen wollt

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !InvOn)
        {
            Inventory.SetActive(true);
            InvOn = true;
            return;
        }
        else if (Inventory.activeSelf == false)
        {
            InvOn = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && InvOn)
        {
            Inventory.SetActive(false);
            InvOn = false;
            return;
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", horizontalInput);
        float verticalInput = Input.GetAxis("Vertical");
        animator.SetFloat("Vertical", verticalInput);


        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        rb.velocity = movement * speed;

        if (horizontalInput > 0 && !isFacingRight || horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }
        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = 5;
            animator.SetBool("Sneak", true);
        }
        else
        {
            speed = 10;
            animator.SetBool("Sneak", false);
        }

        
    }

    public void CloseInv()
    {
        Inventory.SetActive(false);
        return;
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}

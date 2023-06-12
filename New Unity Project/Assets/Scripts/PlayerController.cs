using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //Player Stats///////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public int speed = 10;
    public int attackSpeed = 10;
    public int attackDMG = 10;
    public int maxHealth = 10;
    public int maxStamina = 10;

    //Others/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public int gold_Coins;
    public int silver_Coins;

    private bool isFacingRight = true;
    private bool InvOn = false;
    private bool normInvOn = true;

    public GameObject Inventory;
    public GameObject normInv;
    public GameObject statsInv;
    public Rigidbody2D rb;
    public Animator animator;
    public Slider speedSlider;   
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
        speedSlider.value = speed;
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
        if (Input.GetKeyDown(KeyCode.F) && !normInvOn)
        {
            normInv.SetActive(true);
            statsInv.SetActive(false);
            normInvOn = true;
            return;
        }
        else if (Input.GetKeyDown(KeyCode.F) && normInvOn)
        {
            normInv.SetActive(false);
            statsInv.SetActive(true);
            normInvOn = false;
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

    public void IncreaseStat(int Stat)
    {
        if(Stat == 1) 
        {
            speed += 1;
            speedSlider.value = speed;
        }
        if (Stat == 2)
        {
            attackDMG += 1;
        }
        if (Stat == 3)
        {
            maxHealth += 1;
        }
        if (Stat == 4)
        {
            maxStamina += 1;
        }
    }

    public void DecreaseStat(int Stat)
    {
        if (Stat == 1)
        {
            speed -= 1;
            speedSlider.value = speed;
        }
        if (Stat == 2)
        {
            attackDMG += 1;
        }
        if (Stat == 3)
        {
            maxHealth += 1;
        }
        if (Stat == 4)
        {
            maxStamina += 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
       




    }
}

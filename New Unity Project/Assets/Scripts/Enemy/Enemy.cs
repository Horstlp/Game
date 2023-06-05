using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    GameObject target;

    public float speed;
    public int health = 2;
    public float cooldowntime;
    private float lastHitTime;
    void Start()
    {
        target = GameObject.FindWithTag("Hero");
    }

    void Update()
    {

        if (lastHitTime < cooldowntime)
        {
            lastHitTime += Time.deltaTime;
        }
        else if (lastHitTime > cooldowntime)
        {
                if (Vector2.Distance(transform.position, target.transform.position) < 15)
                {
                     transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
                }
        }

        
    }

    public void hit(int x)
    {
            health -= x;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            
        }
        lastHitTime = 0;
    }
}

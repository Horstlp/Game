using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    public GameObject target;
    public GameObject prefab_Fireball;

    public float fireballSpeed;
    public int health = 30;
    public float cooldowntime;
    float lastShootTime;
    void Start()
    {

    }

    void Update()
    {
        if (lastShootTime < cooldowntime)
        {
            lastShootTime += Time.deltaTime;
        }
        else if (lastShootTime > cooldowntime)
        {
            lastShootTime = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector2 direction = target.transform.localPosition - transform.localPosition;
        direction.Normalize();
        GameObject arrow = Instantiate(prefab_Fireball, transform.position, Quaternion.identity);
        arrow.GetComponent<Rigidbody2D>().velocity = direction * fireballSpeed;
    }

    public void hit(int x)
    {
        health -= x;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

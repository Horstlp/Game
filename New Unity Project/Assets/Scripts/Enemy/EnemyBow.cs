using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBow : MonoBehaviour
{
    private GameObject target;
    public GameObject prefab_arrow;

    public float arrowSpeed;
    public int health;
    public float cooldowntime;
    float lastShootTime;
    void Start()
    {
        target = GameObject.FindWithTag("Player");
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
        GameObject arrow = Instantiate(prefab_arrow, transform.position, Quaternion.identity);
        arrow.GetComponent<Rigidbody2D>().velocity = direction * arrowSpeed;
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

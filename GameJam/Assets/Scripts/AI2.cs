using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI2 : MonoBehaviour
{
    //Shooting AI
    public bool Inrange;
    public GameObject player;
    private float speed = 5f;
    private float stop = 10f;
    public float health = 100f;

    public GameObject AI;
    public RangeDetect range;

    public bool hasCollided;


    private void Start()
    {
        range = AI.GetComponent<RangeDetect>();
        hasCollided = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            hasCollided = true;
            //hasCollided = false;
            health -= 10;
        }
        if (collision.CompareTag("Sword") && !hasCollided)
        {
            hasCollided = true;
            //hasCollided = false;
            health -= 40;
        }
        hasCollided = false;
    }
    private void OnTriggerExit(Collider collision)
    {
        hasCollided = false;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (range.Inrange == true)
        {
            if (distanceToPlayer > stop)
            {
                Vector3 direction = (player.transform.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
            }
            if (distanceToPlayer < stop)
            {
                //shoot player here
            }
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

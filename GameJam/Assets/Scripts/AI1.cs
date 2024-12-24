using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI1 : MonoBehaviour
{
    //Melee AI!!!!

    public bool Inrange;
    public GameObject player;
    private float speed = 7.5f;
    public float health = 100f;
    private float stop = 1f;


    public GameObject AI2;
    public RangeDetect range;

    public bool hasCollided;

    public PlayerHealth healthp;

    private bool isDamagingPlayer = false;

    private void Start()
    {
        healthp = player.GetComponent<PlayerHealth>(); 
        range = AI2.GetComponent<RangeDetect>();
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

    // Update is called once per frame
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
            if (distanceToPlayer < stop && !isDamagingPlayer)
            {
                StartCoroutine(DamagePlayer());
                //healthp.HealthPlayer -= 10;
                //damage player here
            }
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator DamagePlayer()
    {
        isDamagingPlayer = true; // Prevents multiple coroutines from running

        while (Vector3.Distance(transform.position, player.transform.position) < stop)
        {
            healthp.HealthPlayer -= 10; // Subtract player's health
            yield return new WaitForSeconds(1f); // Wait for 1 second before repeating
        }

        isDamagingPlayer = false; // Allows the coroutine to restart if the player is still in range
    }
    //make it so what happens when he collides, probably using ontrigger stay for damage and to stop moving
}

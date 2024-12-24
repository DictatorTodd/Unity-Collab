using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI2 : MonoBehaviour
{
    //Shooting AI
    public bool Inrange;
    public GameObject player;
    private float speed = 5f;
    private float stop = 15f;
    public float health = 100f;

    public GameObject AI;
    public RangeDetect range;

    public bool hasCollided;

    public PlayerHealth healthp;

    private bool isDamagingPlayer = false;

    public GameObject bullet;
    public Transform bulletSpawnPoint; // Spawn point for the bullet
    private float bulletSpeed = 200f; // Speed of the bullet


    private void Start()
    {
        healthp = player.GetComponent<PlayerHealth>();
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
            if (distanceToPlayer < stop && !isDamagingPlayer)
            {
                StartCoroutine(DamagePlayer());
                //shoot player here
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
            //shoot at player
            ShootAtPlayer();
            yield return new WaitForSeconds(1f); // Wait for 1 second before repeating
        }

        isDamagingPlayer = false; // Allows the coroutine to restart if the player is still in range
    }
    private void ShootAtPlayer()
    {
        if (bullet != null && bulletSpawnPoint != null)
        {
            // Instantiate the bullet at the spawn point
            GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);

            // Calculate the direction from the spawn point to the player
            Vector3 directionToPlayer = (player.transform.position - bulletSpawnPoint.position).normalized;

            // Set the bullet's velocity to move toward the player
            Rigidbody bulletRigidbody = spawnedBullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = directionToPlayer * bulletSpeed;
            }
        }
    }
}

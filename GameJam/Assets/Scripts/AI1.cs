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


    public GameObject AI2;
    public RangeDetect range;

    public bool hasCollided;


    private void Start()
    {
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
        if (range.Inrange == true)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    //make it so what happens when he collides, probably using ontrigger stay for damage and to stop moving
}

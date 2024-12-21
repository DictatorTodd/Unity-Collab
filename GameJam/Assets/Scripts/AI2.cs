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


    private void Awake()
    {
        Inrange = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inrange = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (Inrange == true)
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

    }
}

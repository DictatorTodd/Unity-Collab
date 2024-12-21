using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI1 : MonoBehaviour
{
    //Melee AI!!!!

    public bool Inrange;
    public GameObject player;
    private float speed = 7.5f;


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
        if (Inrange == true)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
    //make it so what happens when he collides, probably using ontrigger stay for damage and to stop moving
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float HealthPlayer = 100f;
    public GameObject GameOver;
    public bool GameSet;

    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
        GameSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthPlayer <= 0 && !GameSet)
        {
            GameOverfunc();
        }
        if (!GameSet)
        {
            GameOver.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            HealthPlayer -= 10f;
        }
    }
    private void GameOverfunc()
    {
        GameOver.SetActive(true);
        GameSet = true;
    }
}

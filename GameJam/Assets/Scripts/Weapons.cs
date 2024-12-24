using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject MeleeHitbox, MeleeSprite, GunSprite;
    public bool MeleeInitial, Gun, Attacking, MeleeActive, GunActive;
    public float attackDuration = .5f;
    // Start is called before the first frame update
    void Start()
    {
        MeleeInitial = true;
        MeleeHitbox.SetActive(false);
        GunSprite.SetActive(false);
        Gun = false;
        Attacking = false;
        MeleeActive = true;
        GunActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && MeleeInitial == true && !Attacking && !Gun)
        {
            StartCoroutine(Melee());
        }
        if (Gun == true)
        {
            Gooning();
        }
    }
    private IEnumerator Melee()
    {
        Attacking = true;
        MeleeHitbox.SetActive(true);

        yield return new WaitForSeconds(attackDuration);
        MeleeHitbox.SetActive(false);
        Attacking = false;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Gun"))
        {
            Gun = true;
        }
    }
    private void Gooning()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MeleeActive = true;
            GunActive = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MeleeActive = false;
            GunActive = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !Attacking && MeleeActive == true && !GunActive)
        {
            StartCoroutine(Melee());
        }
        if (MeleeActive == true)
        {
            MeleeSprite.SetActive(true);
            GunSprite.SetActive(false);
        }
        if (GunActive == true)
        {
            MeleeSprite.SetActive(false);
            GunSprite.SetActive(true);
        }
    }
}

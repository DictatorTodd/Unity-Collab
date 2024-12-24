using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject Game;
    public PlayerHealth healthp;

    //weapons
    public GameObject Weaponsp;
    public Weapons weaponvar;

    //RangeDetect
    public GameObject Rangep, Rangep2;
    public RangeDetect rangevar;
    public RangeDetect rangevar2;

    // Start is called before the first frame update
    void Start()
    {
        healthp = Game.GetComponent<PlayerHealth>();
        weaponvar = Weaponsp.GetComponent<Weapons>();
        rangevar = Rangep.GetComponent<RangeDetect>();
        rangevar2 = Rangep2.GetComponent<RangeDetect>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && healthp.GameSet == true)
        {
            healthp.GameSet = false;
            healthp.HealthPlayer = 100;
            print("test");
            rangevar.Inrange = false;
            rangevar2.Inrange = false;
            weaponvar.MeleeInitial = true;
            weaponvar.MeleeHitbox.SetActive(false);
            weaponvar.GunSprite.SetActive(false);
            weaponvar.MeleeSprite.SetActive(true);
            weaponvar.Gun = false;
            weaponvar.Attacking = false;
            weaponvar.MeleeActive = true;
            weaponvar.GunActive = false;

        }
    }
}

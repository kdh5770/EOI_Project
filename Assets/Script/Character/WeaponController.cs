using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponTable myWeapon;

    // Start is called before the first frame update
    void Start()
    {
        myWeapon.Initsetting();
    }

    // Update is called once per frame
    void Update()
    {
        myWeapon.Using();
    }
}

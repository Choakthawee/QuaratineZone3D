using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Fire Rate")]
    [SerializeField] float fireRate;
    float fireRateTimer;
    [SerializeField] bool semiAuto;

    [Header("Bullet Properties")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrelPos;
    [SerializeField] float bulletVelocity;
    [SerializeField] int bulletsPerShot;
    AimStateManager aim;


    void Start()
    {
        aim = GetComponentInChildren<AimStateManager>();
        fireRateTimer = fireRate;    
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldFire()) Fire();
    }

    bool ShouldFire()
    {
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer < fireRate) return false;
        if (semiAuto && Input.GetKeyDown(KeyCode.Mouse0)) return true;
        if (!semiAuto && Input.GetKey(KeyCode.Mouse0)) return true;
        return false;
    }

    void Fire()
    {
        if (barrelPos == null)
        {
            Debug.LogError("barrelPos is not assigned!");
            return; // Exit the method to prevent further errors
        }
        else if (aim != null && aim.actualAimPos != Vector3.zero) // Check if aim and actualAimPos are valid
        {
            barrelPos.LookAt(aim.actualAimPos);
            Debug.Log("Aiming at: " + aim.actualAimPos);
            // Add bullet instantiation logic here
        }
        else
        {
            Debug.LogError("AimStateManager or actualAimPos is not set.");
        }
    }


}

using UnityEngine;
using System.Collections;

public class WeaponLauncher : BarnBehaviour
{

    public Transform Projectile;

    public Vector3 SpawnOffset;

    public float ReloadTime = 1f;

    public bool DontConsumeAmmo = false;
    public int  Ammo = 10;

    private float LastShotTime;
    
    public int Shots { get; set; }

    public KeyCode LaunchKeyCode1;
    public KeyCode LaunchKeyCode2;
    public KeyCode LaunchKeyCode3;

    //##################################################################################################
    // METHODS

    // Use this for initialization
    void Start()
    {
        LastShotTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(LaunchKeyCode1) || LaunchKeyCode1 == 0) &&
           (Input.GetKey(LaunchKeyCode2) || LaunchKeyCode2 == 0) &&
           (Input.GetKey(LaunchKeyCode3) || LaunchKeyCode3 == 0))
        {
            Fire();
        }
    }

    public void Fire()
    {
        // fire projectiles

        
        if( LastShotTime + ReloadTime < Time.time &&
            (Ammo > 0 || DontConsumeAmmo))
        {
            Transform newProjectile = Instantiate(Projectile) as Transform;

            SpawnOffset.x = -SpawnOffset.x;

            newProjectile.position = transform.position + SpawnOffset;
            newProjectile.forward = transform.forward;

            Weapon weaponScript = newProjectile.GetComponent<Weapon>();
            if (weaponScript != null)
            {
                weaponScript.Creator = gameObject;
            }

            LastShotTime = Time.time;

            Shots++;

            if (!DontConsumeAmmo)
                Ammo--;
        }
    }
}

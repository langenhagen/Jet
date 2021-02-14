using UnityEngine;
using System.Collections;

public class Gun : BarnBehaviour {


    public Transform _bullet;

    public Vector3   _bulletSpawnOffset;

    public float     _bulletReloadTime = 0.02f;


    public int Ammo = 100000;

    private float    _lastBulletTime;

    public int Shots { get; set; }

    //##################################################################################################
    // METHODS

	// Use this for initialization
	void Start () {

        _lastBulletTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        // fire bullets

        if (Input.GetKey(KeyCode.Space) && _lastBulletTime + _bulletReloadTime < Time.time && (Ammo > 0 || Ammo == -1))
        {
            Transform bullet = Instantiate(_bullet) as Transform;

            Projectile projectileScript = bullet.GetComponent<Projectile>();
            if (projectileScript != null)
            {
                projectileScript.Creator = gameObject;
            }

            bullet.position = transform.position + _bulletSpawnOffset;
            bullet.forward = transform.forward;

            _lastBulletTime = Time.time;

            Shots++;
            Ammo--;


        }

	}
}

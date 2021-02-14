using UnityEngine;
using System.Collections;

public class EnemyJet : Enemy
{

    public Transform Rocket;

    //##################################################################################################
    // METHODS

	// Use this for initialization
	void Start ()
    {
        GameManager.Enemies.Add(transform);
	}
	
	// Update is called once per frame
    void Update()
    {
        // die if necessary

        if (HealthPoints <= 0)
        {
            GameManager.Instance.Kills++;
            Die();
        }

        // shoot gun

        Ray ray = new Ray(transform.position, transform.forward);
        WeaponLauncher weaponLauncher = GetComponent<WeaponLauncher>();

        if (weaponLauncher != null &&
            GameManager.Instance.Jet != null && 
            GameManager.Instance.JetBigBoxCollider.collider.bounds.IntersectRay(ray))
        {
            weaponLauncher.Fire();
        }



        // shoot rockets
        const float rocketProbability = 0.00001f;

        if (Random.value < rocketProbability && GameManager.Instance.Jet != null)
        {    

            Transform newProjectile = Instantiate(Rocket) as Transform;


            newProjectile.position = transform.position;
            newProjectile.forward = transform.forward;

            Rocket weaponScript = newProjectile.GetComponent<Rocket>();
            if (weaponScript != null)
            {
                weaponScript.Creator = gameObject;
                weaponScript.Target = GameManager.Instance.Jet.transform;
            }

        }
	}

    void OnCollisionEnter(Collision collision)
    {
        PlayerJet jet = collision.collider.gameObject.GetComponent<PlayerJet>();

        if (jet != null)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDeath.Die();
    }

    void OnDestroy()
    {
        GameManager.Enemies.Remove(transform);
    }

}

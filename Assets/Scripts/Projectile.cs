using UnityEngine;
using System.Collections;

public class Projectile : Weapon
{

    public float Speed = 500;

    //##################################################################################################
    // METHODS

	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
	
	}

    void OnCollisionEnter(Collision collision)
    {
        Entity entity = collision.collider.gameObject.GetComponent<Entity>();

        if (entity != null && entity.gameObject != Creator)
        {
            entity.HealthPoints -= AttackPoints;
        
            Destroy(gameObject);
        }

    }
}

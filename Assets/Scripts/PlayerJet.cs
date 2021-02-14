using UnityEngine;
using System.Collections;

public class PlayerJet : Entity
{

    //##################################################################################################
    // METHODS


    public void OnCollisionEnter(Collision collision)
    {
        EnemyJet enemy = collision.collider.gameObject.GetComponent<EnemyJet>();

        if (    enemy != null || 
                HealthPoints <= 0)
        {
            OnDeath.Die();
        }

    }


}

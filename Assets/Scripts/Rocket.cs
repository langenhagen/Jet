using UnityEngine;
using System.Collections;

public class Rocket : Weapon {

    public float        Speed               = 100;
    public float        MaxRotationAngle    = 0.5f;


    public GameObject   DetonatorFail;
    public GameObject   DetonatorSuccess;
    private bool        Success             = false;

    public Transform    Target              = null;

    //##################################################################################################
    // METHODS

    void Start()
    {
        Destroy(gameObject, LifeTime);

        if (Target == null && GameManager.Enemies.Count > 0)
        {
            AssignNewTarget();
        }
        
    }

	
	// Update is called once per frame
	void Update ()
    {

        if (Target == null && GameManager.Enemies.Count > 0)
        {
            AssignNewTarget();
        }

        if (Target != null)
        {
            Vector3 newForward =
                Vector3.RotateTowards(transform.forward, Target.position - transform.position, Mathf.Deg2Rad * MaxRotationAngle, 0);
            transform.forward = newForward;

            Vector3 newPos = transform.position;
            newPos += newForward * Time.deltaTime * Speed;
            transform.position = newPos;
        }

	}


    void OnCollisionEnter(Collision collision)
    {
        Entity entity = collision.collider.gameObject.GetComponent<Entity>();
        

        if (entity != null && entity.gameObject != Creator)
        {
            entity.HealthPoints -= AttackPoints;

            if (entity == Target)
                Success = true;

            Destroy(gameObject);
        }

        
    }


    void OnDestroy()
    {
        GameObject detonator;

        if (Success)
            detonator = DetonatorSuccess;
        else
            detonator = DetonatorFail;

        Instantiate(detonator, transform.position, new Quaternion());
    }


    private void AssignNewTarget()
    {
        // find new target closest to the x/y distance of the rocket position

        float minSqrDist = 99999999;

        foreach (var enemy in GameManager.Enemies)
        {
            var distVector = new Vector2(enemy.position.x - transform.position.x, enemy.position.y - transform.position.y);
            var sqrDist = distVector.sqrMagnitude;

            if (sqrDist < minSqrDist)
            {
                minSqrDist = sqrDist;
                Target = enemy;
            }
        }
    }
}

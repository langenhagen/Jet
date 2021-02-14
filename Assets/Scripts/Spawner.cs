using UnityEngine;
using System.Collections;

using TypePair = Pair<GameManager.UnitType, UnityEngine.Transform>;

public class Spawner : MonoBehaviour {

    public Transform Prototype;

    public float     SpawnProbability = 0.1f;

    //##################################################################################################
    // METHODS
	
	// Update is called once per frame
	void Update ()
    {

        float val = Random.value;


        if (val < SpawnProbability)
        {
            float numOfSpawns = Mathf.Max( Mathf.Repeat( val, SpawnProbability), 1);

            for (int i = 0; i < numOfSpawns; i++)
            {
                Vector3 position = new Vector3(Random.Range(-90, 90), Random.Range(-40, 40), 1000f);

                var inactiveEnemies = GameManager.InactiveEnemies;

                if (inactiveEnemies.Count > 0)
                {
                    //Spawn(position, Vector3.back);
                    var enemy = inactiveEnemies.Pop();

                    enemy.position = position;
                    enemy.GetComponent<EnemyJet>().HealthPoints = 20; // TODO: automatize numbers
                    enemy.GetComponent<WeaponLauncher>().Ammo = 1000;
                    enemy.gameObject.SetActive(true);
                    GameManager.Enemies.Add(enemy.transform);
                }
                else
                {
                    Spawn(position, Vector3.back);
                }
                
            }
        }

        SpawnProbability += Time.deltaTime/128;
	}


    public void Spawn( Vector3 position, Vector3 forward)
    {
        Transform entity = Instantiate(Prototype) as Transform;
        entity.position = position;
        entity.forward = forward;
    }
}

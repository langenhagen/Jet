using UnityEngine;
using System.Collections;

public class VectorRotation : BarnBehaviour
{
    public Vector3 AnchorVector = new Vector3(0,1,0);

    public Vector3 Vector;

    public float RollDirectionAndFrequency = 0.75f;

    public float MultiplierAngle = 5;

    public float EnableDuration = 5;


    private float RollingSinceSeconds = 0;

    private float InternalTimeAngle;

	// Use this for initialization
	void Start ()
    {
        InternalTimeAngle = Time.time;
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float deltaTime = Time.deltaTime;

        // camera roll
        if (IsRolling())
        {
            float curve = RollingSinceSeconds < EnableDuration / 2 ? RollingSinceSeconds : EnableDuration - RollingSinceSeconds;

            InternalTimeAngle   += deltaTime * curve * RollDirectionAndFrequency;
            RollingSinceSeconds += deltaTime;

            Vector = Quaternion.Euler(0, 0, (Mathf.Sin(InternalTimeAngle)) * MultiplierAngle) * AnchorVector; 
        }
        else
        {
            RollingSinceSeconds = 0;
            RollDirectionAndFrequency *= Mathf.Sign(Random.Range(-1, 1));
        }
	
	}



    public bool IsRolling()
    {
        return RollingSinceSeconds < EnableDuration;
    }
}

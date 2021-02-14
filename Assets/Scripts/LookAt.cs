using UnityEngine;
using System.Collections;

public class LookAt : BarnBehaviour
{
    public Transform Target;
    public Vector3 Offset;


    public VectorRotation UpVectorScript = null;

    public Vector3 UpVector = new Vector3( 0,1,0);


    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            if (UpVectorScript != null)
            {
                UpVector = UpVectorScript.Vector; 
            }

            transform.LookAt(Target.transform.position + Offset, UpVector);
        }
    }
}
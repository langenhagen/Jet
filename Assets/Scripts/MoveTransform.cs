using UnityEngine;
using System.Collections;

public class MoveTransform : BarnBehaviour {

    // since movesprite orientates its speed on the ground plane, connect it here
    public GameObject GroundPlane;

    public float Speed = 0;

    public float DeactivateBehind = -20;

    private float _planeSpeed;


    //##################################################################################################
    // METHODS

	// Use this for initialization
	void Start () 
    {

        GroundPlane = GameManager.Instance.GroundPlane;
        _planeSpeed =
            GroundPlane.GetComponent<ScrollTexture>().Speed *
            GroundPlane.transform.localScale.y / GroundPlane.renderer.material.mainTextureScale.y;
	}
	
	// Update is called once per frame
	void Update ()
    {

        float speed = (ScrollTexture.GlobalSpeed * _planeSpeed + Speed) * Time.deltaTime ;

        // move sprite
        transform.Translate(Vector3.back  * Mathf.Cos(ScrollTexture.GlobalAngle) * speed, Space.World);
        transform.Translate(Vector3.right * Mathf.Sin(ScrollTexture.GlobalAngle) * speed, Space.World);

        if (transform.position.z < DeactivateBehind)
        {
            gameObject.SetActive(false);
            GameManager.Enemies.Remove(transform);
            GameManager.InactiveEnemies.Push(transform);   
        }
	}

    //##################################################################################################
    // GETTERS & SETTERS
}

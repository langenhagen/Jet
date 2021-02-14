using UnityEngine;
using System.Collections;

public class PlaneControl : BarnBehaviour {

    public float _leftSpeed  = 1;
    public float _rightSpeed = 1;
    public float _upSpeed    = 1;
    public float _downSpeed  = 1;

    public float _xForceFactor = 0.92f;
    public float _yForceFactor = 0.92f;

    private Vector2 _force = new Vector2();

    //##################################################################################################
    // METHODS


	
	// Update is called once per frame
	void Update () {


        // position
        Vector3 newPosition = transform.position;

       // Vector3 force = new Vector3();

        if ( Input.GetKey(KeyCode.UpArrow) && transform.position.y < 40 )
        {
            //newPosition.y+= _upSpeed;
            _force.y += _upSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -40)
        {
            //newPosition.y-= _downSpeed;
            _force.y -= _downSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 90)
        {
            //newPosition.x+= _rightSpeed;
            _force.x += _rightSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -90)
        {
            //newPosition.x = -_leftSpeed;
            _force.x -= _leftSpeed * Time.deltaTime;
        }

        newPosition.x += _force.x;
        newPosition.y += _force.y;

        _force.x *= _xForceFactor;
        _force.y *= _yForceFactor;


        if (newPosition.x < 100 && newPosition.x > -100 &&
            newPosition.y < 45 && newPosition.y > -45)
        {
            transform.position = newPosition;
        }
        else
        {
            _force.x = 0f;
            _force.y = 0f;
        }

	}
}

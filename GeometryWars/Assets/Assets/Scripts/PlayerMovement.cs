using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    
    public float fMoveSpeed = 4.5f;
    private float fDeadzone = 0.25f;
    Vector3 latestRotation;

    void Start ()
    {
    
	}
	
	
	void Update ()
    {
        float fLeftMoveX = Input.GetAxis("LeftJoystickX");
        float fLeftMoveY = Input.GetAxis("LeftJoystickY");
        float fRightMoveX = Input.GetAxis("RightJoystickX");
        float fRightMoveY = Input.GetAxis("RightJoystickY");

        transform.position += (Vector3.right* fLeftMoveX + -1*(Vector3.up* fLeftMoveY)).normalized*fMoveSpeed*Time.deltaTime;
        Vector2 v = new Vector2(Input.GetAxis("RightJoystickX"), Input.GetAxis("RightJoystickY"));
        if (v.magnitude < fDeadzone)
        {
            latestRotation = transform.eulerAngles;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-1 * (Input.GetAxis("RightJoystickY")), Input.GetAxis("RightJoystickX")) * 180 / Mathf.PI);
            latestRotation = transform.eulerAngles;
        }
        
    }
   
}

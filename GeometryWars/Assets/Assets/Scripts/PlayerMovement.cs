using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D _playerRigidbody;
    public float fMoveSpeed = 5.0f;
	void Start ()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
	}
	
	
	void FixedUpdate ()
    {
        float fMoveX = Input.GetAxis("LeftJoystickX");
        float fMoveY = Input.GetAxis("LeftJoystickY");

        if (fMoveX > 0.5f || fMoveX < -0.5f || fMoveY > 0.5f || fMoveY < -0.5f)
        {
            _playerRigidbody.(new Vector2(fMoveX + fMoveSpeed * Time.deltaTime, -1 * (fMoveY + fMoveSpeed * Time.deltaTime)));
        }
        else _playerRigidbody.velocity = _playerRigidbody.velocity = new Vector2(0.0f, 0.0f);
        
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour {

    private PlayerWeapon _playerWeapon;
    private float fTimeSinceLastShot = 0.0f;
	
	void Start ()
    {
        _playerWeapon = GetComponent<PlayerWeapon>();	
	}
	
	void Update ()
    {
        if (_playerWeapon.bShot)
        {
            if (fTimeSinceLastShot < _playerWeapon.fShootSpeed)
            {
                fTimeSinceLastShot += Time.deltaTime;
            }
            else
            {
                _playerWeapon.bShot = false;
                fTimeSinceLastShot = 0.0f;
            }
        }

        if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            if (fTimeSinceLastShot == 0.0f)
            {
                Debug.Log("SHOOT");
                _playerWeapon.Shoot();
                _playerWeapon.bShot = true;
            }
        }


	}
}

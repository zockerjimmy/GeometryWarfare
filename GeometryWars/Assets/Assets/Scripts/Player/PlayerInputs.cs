using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{

    private PlayerWeapon _playerWeapon;
    private PlayerMovement _playerMovement;
    private float fTimeSinceLastShot = 0.0f;
    private bool bShot = false;

    private float fLeftJoystickX;
    private float fLeftJoystickY;
    private float fRightJoystickX;
    private float fRightJoystickY;
    private Vector2 leftJoystickInput;
    private Vector2 rightJoystickInput;
    private float fDeadzone = 0.25f;

    void Start()
    {
        _playerWeapon = GetComponent<PlayerWeapon>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        #region Movement and Rotation

        fLeftJoystickX = Input.GetAxis("LeftJoystickX");
        fLeftJoystickY = Input.GetAxis("LeftJoystickY");
        fRightJoystickX = Input.GetAxis("RightJoystickX");
        fRightJoystickY = Input.GetAxis("RightJoystickY");

        leftJoystickInput = new Vector2(fLeftJoystickX, fLeftJoystickY);
        rightJoystickInput = new Vector2(fRightJoystickX, fRightJoystickY);

        if (leftJoystickInput.magnitude >= fDeadzone)
        {
            _playerMovement.MovePlayer(fLeftJoystickX, fLeftJoystickY);
        }

        if (rightJoystickInput.magnitude >= fDeadzone)
        {
            _playerMovement.RotatePlayer(fRightJoystickX, fRightJoystickY);
        }

        #endregion
        #region shooting

        if (rightJoystickInput.magnitude >= fDeadzone)
        {
            if (fTimeSinceLastShot == 0.0f)
            {
                _playerWeapon.Shoot();
                bShot = true;
            }
        }

        if (bShot)
        {
            if (fTimeSinceLastShot < _playerWeapon.fShootSpeed)
            {
                fTimeSinceLastShot += Time.deltaTime;
            }
            else
            {
                bShot = false;
                fTimeSinceLastShot = 0.0f;
            }
        }

        #endregion
    }
}

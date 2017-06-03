using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    //references
    private PlayerWeapon _playerWeapon;
    private PlayerMovement _playerMovement;
    private Player _player;

    //shot variables
    private float fTimeSinceLastShot = 0.0f;
    private bool bShot = false;

    //joystick variables
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
        _player = GetComponent<Player>();
    }

    void Update()
    {
        #region Movement and Rotation
        //input to move and rotate player
        fLeftJoystickX = Input.GetAxis("LeftJoystickX");
        fLeftJoystickY = Input.GetAxis("LeftJoystickY");
        fRightJoystickX = Input.GetAxis("RightJoystickX");
        fRightJoystickY = Input.GetAxis("RightJoystickY");

        leftJoystickInput = new Vector2(fLeftJoystickX, fLeftJoystickY);
        rightJoystickInput = new Vector2(fRightJoystickX, fRightJoystickY);

        //only detect joystick input out of deadzone
        //move
        if (leftJoystickInput.magnitude >= fDeadzone)
        {
            _playerMovement.MovePlayer(fLeftJoystickX, fLeftJoystickY);
        }
        //rotate
        if (rightJoystickInput.magnitude >= fDeadzone)
        {
            _playerWeapon.RotateGun(fRightJoystickX, fRightJoystickY);
        }
        else if (rightJoystickInput.magnitude < fDeadzone)
        {
            _playerWeapon.RotateGun(0.0f, 0.0f);
        }

        #endregion
        #region shooting
        //shoot
        if (rightJoystickInput.magnitude >= fDeadzone)
        {
            if (fTimeSinceLastShot == 0.0f)
            {
                _playerWeapon.Shoot();
                bShot = true;
            }
        }
        //time between shots
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
        #region GUI Input
        //can activate object
        if (_player.bCanActivate && !_player.bIsInMenus)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                _player.bIsInMenus = true;
                _player.gActivatableObject.GetComponent<Activatable>().Activate();
            }
        }
        //activated object and is in GUI interaction
        else if (_player.bCanActivate && _player.bIsInMenus)
        {
            //close GUI
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                _player.bIsInMenus = false;
                _player.gActivatableObject.GetComponent<Activatable>().Deactivate();
            }
            //if interact with mainbase
            //add scrap from player to mainbase
            if (_player.gActivatableObject.tag == "Mainbase")
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button2))
                {
                    if (_player.fScrapInCargo > 0.0f)
                    {
                        _player.gActivatableObject.SendMessage("AddScrap", _player.fScrapInCargo);
                        _player.fScrapInCargo -= _player.fScrapInCargo;
                    }
                }
            }
        }
        #endregion
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGUI : MonoBehaviour
{
    private Player _player;

    private float fScreenX = Screen.width / 90.0f;
    private float fScreenY = Screen.height / 90.0f;

    void Start()
    {
        _player = GetComponent<Player>();
    }

    void Update()
    {

    }

    private void OnGUI()
    {
        //show "activate gui"
        if (_player.bCanActivate && !_player.bIsInMenus)
        {
            GUI.Box(new Rect(fScreenX * 40.0f, fScreenY * 80.0f, fScreenX * 10.0f, fScreenY * 10.0f), "ACTIVATE");
        }
    }
}

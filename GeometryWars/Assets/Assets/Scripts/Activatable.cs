using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour
{
    public Player _player;
    public bool bIsActivated = false;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Activate()
    {
        bIsActivated = true;
    }

    public void Deactivate()
    {
        bIsActivated = false;
    }

    public void GetPlayer(Player player)
    {
        _player = player;
    }

    public void OutOfRange()
    {
        Deactivate();
        _player = null;
    }
    
}

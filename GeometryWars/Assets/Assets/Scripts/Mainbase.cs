using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainbase : MonoBehaviour
{
    public Player _player;
    public bool bIsActivated = false;
    public float fStoredScrap = 0.0f;
    private float fScreenX = Screen.width / 90.0f;
    private float fScreenY = Screen.height / 90.0f;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnGUI()
    {
        if (bIsActivated)
        {
            GUI.Box(new Rect(fScreenX * 30.0f, fScreenY * 30.0f, fScreenX * 30.0f, fScreenY * 30.0f), "MENU");
            GUI.Box(new Rect(fScreenX * 35.0f, fScreenY * 35.0f, fScreenX * 5.0f, fScreenY * 5.0f), fStoredScrap.ToString());
        }
    }

    public void GetPlayer(Player _p)
    {
        _player = _p;
    }

    public void LosePlayer()
    {
        _player = null;
    }

    public void Activate(int set)
    {
        if (set == 1)
        {
            bIsActivated = false;
        }
        else if (set == 2)
        {
            bIsActivated = true;
        }
    }

    public void AddScrap(float scrap)
    {
        fStoredScrap += scrap;
    }
}

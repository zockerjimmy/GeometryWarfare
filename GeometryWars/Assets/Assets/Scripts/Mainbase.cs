using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Activatable))]
public class Mainbase : MonoBehaviour
{
    private Activatable _activatable;

    public float fStoredScrap = 0.0f;
    private float fScreenX = Screen.width / 90.0f;
    private float fScreenY = Screen.height / 90.0f;

    void Start()
    {
        _activatable = GetComponent<Activatable>();
    }

    private void OnGUI()
    {
        if (_activatable.bIsActivated)
        {
            GUI.Box(new Rect(fScreenX * 30.0f, fScreenY * 30.0f, fScreenX * 30.0f, fScreenY * 30.0f), "MENU");
            GUI.Box(new Rect(fScreenX * 35.0f, fScreenY * 35.0f, fScreenX * 5.0f, fScreenY * 5.0f), fStoredScrap.ToString());
        }
    }

    public void AddScrap(float scrap)
    {
        fStoredScrap += scrap;
    }
}

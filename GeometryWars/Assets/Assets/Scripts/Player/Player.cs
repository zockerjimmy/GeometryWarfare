using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float fLife = 100.0f;
    public float fScrapInCargo = 0.0f;

    public GameObject gActivatableObject;
    public bool bCanActivate = false;
    public bool bIsInMenus = false;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player1MainBase")
        {
            gActivatableObject = collision.gameObject;
            gActivatableObject.SendMessage("GetPlayer", GetComponent<Player>());
            bCanActivate = true;
        }
        if (collision.gameObject.tag == "Scrap")
        {
            collect("Scrap");
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player1MainBase")
        {
            gActivatableObject.SendMessage("LosePlayer", GetComponent<Player>());
            gActivatableObject.SendMessage("Activate", 1);
            gActivatableObject = null;
            bCanActivate = false;
            bIsInMenus = false;
        }
    }

    void collect(string obj)
    {
        if (obj == "Scrap")
        {
            fScrapInCargo += 10.0f;
        }
    }
}

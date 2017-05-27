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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collide with mainbase
        //prepare interaction between player and mainbase
        if (collision.gameObject.name == "Player1MainBase")
        {
            gActivatableObject = collision.gameObject;
            gActivatableObject.GetComponent<Activatable>().GetPlayer(GetComponent<Player>());
            bCanActivate = true;
        }
        //if collide with scrap
        //collect and destroy scrap
        if (collision.gameObject.tag == "Scrap")
        {
            collect("Scrap");
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if exit mainbase trigger
        if (collision.gameObject.name == "Player1MainBase")
        {
            //set all links between player and mainbase to default
            gActivatableObject.GetComponent<Activatable>().OutOfRange();
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

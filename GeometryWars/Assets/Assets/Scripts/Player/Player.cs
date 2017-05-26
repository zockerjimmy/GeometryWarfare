using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
            bCanActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gActivatableObject = null;
        bCanActivate = false;
        bIsInMenus = false;
    }

}

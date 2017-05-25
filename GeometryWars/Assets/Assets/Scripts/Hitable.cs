using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
    private Enemy _parentEnemy;

    private void Start()
    {
        _parentEnemy = GetComponent<Enemy>();
    }
    public void GetHit(float dmg)
    {
        _parentEnemy.fLife -= dmg;
    }
}

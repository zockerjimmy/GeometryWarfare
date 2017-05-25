using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hitable))]
public class Enemy : MonoBehaviour
{
    public float fLife = 100.0f;

    void Start()
    {

    }

    void Update()
    {
        if (fLife <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}

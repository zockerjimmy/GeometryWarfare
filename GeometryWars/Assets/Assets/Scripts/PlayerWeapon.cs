using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    private Transform bulletSpawn;
    public float fShootSpeed = 0.25f;
    public bool bShot = false;

	void Start ()
    {
        bulletSpawn = GameObject.Find("BulletSpawn").transform;
	}
	
	void Update ()
    {

	}

    public void Shoot()
    {

    }
}

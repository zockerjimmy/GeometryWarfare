using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {

    private Transform bulletSpawn;
    public float fShootSpeed = 0.25f;
    public bool bShot = false;
    public GameObject _normalBullet;

	void Start ()
    {
        bulletSpawn = GameObject.Find("BulletSpawn").transform;
        _normalBullet = Resources.Load("Prefabs/NormalBullet") as GameObject;
	}
	
	void Update ()
    {

	}

    public void Shoot()
    {
        GameObject dummy = Instantiate(_normalBullet, bulletSpawn) as GameObject;
    }
}

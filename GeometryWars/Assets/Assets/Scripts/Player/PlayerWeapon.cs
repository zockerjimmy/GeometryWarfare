using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private Transform bulletSpawn;
    public float fShootSpeed = 0.2f;
    public GameObject _normalBullet;

    void Start()
    {
        bulletSpawn = GameObject.Find("BulletSpawn").transform;
        _normalBullet = Resources.Load("Prefabs/NormalBullet") as GameObject;
    }

    void Update()
    {

    }

    public void RotateGun(float rightX, float rightY)
    {
      //Debug.Log("X" + rightX + "Y" + rightY);
        bulletSpawn.transform.localPosition = new Vector3(rightX, -1*rightY, 0);
        bulletSpawn.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-1 * (rightY), rightX) * 180 / Mathf.PI);
    }

    public void Shoot()
    {
        Instantiate(_normalBullet, bulletSpawn.position, bulletSpawn.rotation);
    }
}

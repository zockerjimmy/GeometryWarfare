using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float fLifetime = 2.0f;
    private float fBulletSpeed = 2.0f;
    private float fBulletDamage = 10.0f;
    private Rigidbody2D _bullet;

    void Start()
    {
        _bullet = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (fLifetime >= 0.0f)
        {
            fLifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }

        _bullet.AddForce(_bullet.transform.right * fBulletSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Hitable>().GetHit(fBulletDamage);
            Destroy(this.gameObject);
        }
    }
}

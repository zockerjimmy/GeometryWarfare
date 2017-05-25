using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float fLifetime = 2.0f;
    private float fMovespeed = 50.0f;
    private Rigidbody2D _bullet;

	void Start ()
    {
        _bullet = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        if (fLifetime >= 0.0f)
        {
            fLifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }

        // _bullet.velocity += new Vector2(_bullet.position.x*fMovespeed * Time.deltaTime, _bullet.position.y*fMovespeed * Time.deltaTime);
        _bullet.AddForce(_bullet.transform.right * fMovespeed);
    }
}

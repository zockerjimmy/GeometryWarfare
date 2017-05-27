using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hitable))]
public class Enemy : MonoBehaviour
{
    public float fLife = 100.0f;
    private Vector2 lastPosition;

    void Start()
    {

    }

    void Update()
    {
        if (fLife <= 0.0f)
        {
            Die();
        }
    }

    void Die()
    {
        lastPosition = transform.position;
        Instantiate(Resources.Load("Prefabs/Scrap") as GameObject, GetRandomScrapSpawnPosition(), Quaternion.identity);
        Instantiate(Resources.Load("Prefabs/Scrap") as GameObject, GetRandomScrapSpawnPosition(), Quaternion.identity);
        Instantiate(Resources.Load("Prefabs/Scrap") as GameObject, GetRandomScrapSpawnPosition(), Quaternion.identity);
        Instantiate(Resources.Load("Prefabs/Scrap") as GameObject, GetRandomScrapSpawnPosition(), Quaternion.identity);
        Destroy(this.gameObject);
    }

    Vector3 GetRandomScrapSpawnPosition()
    {
        Vector3 position = new Vector2(Random.Range(lastPosition.x*0.9f, lastPosition.x*1.2f), Random.Range(lastPosition.y*0.9f, lastPosition.y*1.2f));
        return position;
    }
}

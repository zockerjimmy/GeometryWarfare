using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform _playerPosition;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_playerPosition.position.x, _playerPosition.position.y, -10);
    }
}

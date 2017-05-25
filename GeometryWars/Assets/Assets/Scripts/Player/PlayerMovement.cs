using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float fMoveSpeed = 4.5f;

    public void MovePlayer(float leftX, float leftY)
    {
        transform.position += (Vector3.right * leftX + -1 * (Vector3.up * leftY)).normalized * fMoveSpeed * Time.deltaTime;
    }

    public void RotatePlayer(float rightX, float rightY)
    {
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-1 * (rightY), rightX) * 180 / Mathf.PI);
    }

}

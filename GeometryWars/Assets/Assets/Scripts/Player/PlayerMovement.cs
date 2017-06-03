using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float fMoveSpeed = 4.5f;

    //move  and rotate player with left joystick
    public void MovePlayer(float leftX, float leftY)
    {
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-1 * (leftY), leftX) * 180 / Mathf.PI);
        transform.parent.position += (Vector3.right * leftX + -1 * (Vector3.up * leftY)).normalized * fMoveSpeed * Time.deltaTime;
        if (transform.localPosition != Vector3.zero)
        {
            transform.parent.position = transform.position;
            transform.localPosition = Vector3.zero;
        }
        // transform.position += (Vector3.right * leftX + -1 * (Vector3.up * leftY)).normalized * fMoveSpeed * Time.deltaTime;
    }
    //rotate guns with right joystick
  /*  public void RotatePlayer(float rightX, float rightY)
    {
        
      //  transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-1 * (rightY), rightX) * 180 / Mathf.PI);
    }*/
}

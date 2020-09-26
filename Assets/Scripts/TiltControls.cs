using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControls : MonoBehaviour
{
    public float speed;
    public VariableJoystick joystick;

    public float boardRotX, boardRotZ;

    public Vector3 currentRot;

    //public Quaternion boardRotation;

    public void Start()
    {
        speed = 10f;
        //boardRotation = transform.rotation;
    }

    public void Update()
    {
        boardRotX = joystick.Vertical * speed;
        boardRotZ = -joystick.Horizontal * speed;

        currentRot += new Vector3(boardRotX, 0f, boardRotZ) * Time.deltaTime * speed;

        currentRot.x = Mathf.Clamp(currentRot.x, -22.5f, 22.5f);
        currentRot.z = Mathf.Clamp(currentRot.z, -22.5f, 22.5f);

        transform.eulerAngles = currentRot;
        

    }
}

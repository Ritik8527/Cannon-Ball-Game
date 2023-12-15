using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    Vector3 pivotAxis;
    public Transform planeAxis;
    public CharacterController cc;
    public float v;
    public Vector3 dir;
    public float force;
    public Rigidbody rb;
    private void Start()
    {

    }
    private void Update()
    {
        //transform.RotateAround(pivotAxis, Vector3.up, 30 * Time.deltaTime);
        cc.Move(dir * v);

    }
}

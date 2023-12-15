using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonControl : MonoBehaviour
{

    public Transform canonT;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            canonT.Rotate(Vector3.left * 1);

        }
    }
}

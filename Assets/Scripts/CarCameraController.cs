using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCameraController : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0f, 5f, -10f); 

    private void Update()
    {
        float desiredAngle = target.eulerAngles.y;

        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.position + rotation * offset;
        transform.LookAt(target.position);
    }
}

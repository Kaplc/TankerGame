using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMap : MonoBehaviour
{
    public Transform target;
    public float H;
    
    private Vector3 pos;

    // Update is called once per frame
    void LateUpdate()
    {
        pos.x = target.position.x;
        pos.z = target.position.z;
        pos.y = H;
        
        transform.position = pos;
    }
}

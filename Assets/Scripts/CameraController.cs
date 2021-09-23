using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;

    void Start()
    {
        
    }

    void Update()
    {
        var x = playerTransform.position.x + 7;
        var y = playerTransform.position.y + 2;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}

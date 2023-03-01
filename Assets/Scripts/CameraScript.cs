using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = player.transform;   
    }

    void LateUpdate()
    {
        Vector3 movement = transform.position;
        movement.x = playerTransform.position.x;
        movement.y = playerTransform.position.y;
        movement.z = -5;

        transform.position = movement;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMove : MonoBehaviour
{
    [SerializeField] private float rotatingSpeed = 45f;
    void FixedUpdate()
    {
        transform.Rotate(Vector3.left, rotatingSpeed * Time.fixedDeltaTime);
    }
}

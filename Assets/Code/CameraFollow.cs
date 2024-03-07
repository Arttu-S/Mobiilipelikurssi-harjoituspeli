using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harjoituspeli
{
    public class Camera : MonoBehaviour
    {
[SerializeField] public Transform target;
    public float smoothTime = 0.2F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, 0));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
    }
}

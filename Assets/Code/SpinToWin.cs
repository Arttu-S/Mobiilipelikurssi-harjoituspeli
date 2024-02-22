using UnityEngine;

namespace Harjoituspeli {
public class SawbladeRotation : MonoBehaviour
{
    public float rotationSpeed = 360f; // Degrees per second

    private void Start()
    {
        // Set initial angular velocity to start spinning
        GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
    }
    private void Update()
    {
        GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
    }
}
}
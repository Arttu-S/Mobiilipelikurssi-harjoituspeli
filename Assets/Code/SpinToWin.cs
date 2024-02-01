using UnityEngine;

public class SawbladeRotation : MonoBehaviour
{
    public float rotationSpeed = 360f; // Degrees per second

    private void Start()
    {
        // Set initial angular velocity to start spinning
        GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
    }
}

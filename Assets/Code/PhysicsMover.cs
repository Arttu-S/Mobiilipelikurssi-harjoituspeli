using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harjoituspeli
{
    public class PhysicsMover : MonoBehaviour
    {
        [SerializeField]
        private float _jumpThrust = 10.0f;
        [SerializeField] private float _thrust = 1.0f;
        [SerializeField] private float _maxVelocity = 65.0f;
        private Rigidbody2D rb;

        void Awake()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        void Start()
        {   
        }

        void FixedUpdate()
        {
            // Limit the velocity to _maxVelocity
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, _maxVelocity);
        }


        public void Move(UnityEngine.Vector2 direction)
        {
            // Only allow movement to the left, right, and down
            Vector2 allowedDirection = new Vector2(direction.x, Mathf.Min(direction.y, 0.0f));
            rb.AddForce(allowedDirection * _thrust);
        }

        public void Jump()
        {
            Debug.Log("Jumping/PhysicsMover.cs");
            rb.AddForce(UnityEngine.Vector2.up * _jumpThrust, ForceMode2D.Impulse);
        }
    }
}

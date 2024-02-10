using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harjoituspeli
{
    public class PhysicsMover : MonoBehaviour
    {
        [SerializeField]
        private float _jumpThrust = 10.0f;
        [SerializeField]
        private float _thrust = 1.0f;
        [SerializeField]
        private float _maxVelocity = 5.0f;
        private Rigidbody2D rb;
        // Start is called before the first frame update
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        public void Move(UnityEngine.Vector2 direction)
        {
            rb.AddForce(direction * _thrust);
        }

        public void Jump()
        {
            Debug.Log("Jumping");
            rb.AddForce(UnityEngine.Vector2.up * _jumpThrust, ForceMode2D.Impulse);
        }
    }
}

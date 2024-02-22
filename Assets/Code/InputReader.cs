using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harjoituspeli
{
    public class InputReader : MonoBehaviour
    {
        private Inputs _inputs = null;
        private Vector2 _movementInput = Vector2.zero;
        private PhysicsMover _physicsMover = null;

        public Vector2 Movement
        {
            get { return _movementInput; }
            private set { _movementInput = value; }
        }

        void Awake()
        {
            _inputs = new Inputs();
            _physicsMover = GetComponent<PhysicsMover>(); // Assuming PhysicsMover is on the same GameObject
        }

        private void OnEnable()
        {
            _inputs.Game.Enable();
        }

        private void OnDisable()
        {
            _inputs.Game.Disable();
        }

        // Update is called once per frame
        void Update()
        {
            _movementInput = _inputs.Game.Move.ReadValue<Vector2>();
            
            // Check if the jump button is pressed (for example, space key or button)
            if (_inputs.Game.Jump.triggered)
            {
                _physicsMover.Jump();
                Debug.Log("Jumping");
            }
        }
    }
}

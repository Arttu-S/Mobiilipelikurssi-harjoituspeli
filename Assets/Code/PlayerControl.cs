using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harjoituspeli
{
    [RequireComponent(typeof(InputReader))]
    public class PlayerControl : MonoBehaviour
    {

        private InputReader _inputReader = null;
        private PhysicsMover _physicsMover = null;

        private void Awake()
        {
            _inputReader = GetComponent<InputReader>();
            _physicsMover = GetComponent<PhysicsMover>();
        }
        // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {
            Vector2 movement = _inputReader.Movement;
            _physicsMover.Move(movement);
        }
    }
}

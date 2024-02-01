using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harjoituspeli
{
    [RequireComponent(typeof(InputReader), typeof(Mover))]
    public class PlayerControl : MonoBehaviour
    {

        private InputReader _inputReader = null;
        private Mover _mover = null;

        private void Awake()
        {
            _inputReader = GetComponent<InputReader>();
            _mover = GetComponent<Mover>();
        }
        // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {
            Vector2 movement = _inputReader.Movement;
            _mover.Move(movement);
        }
    }
}

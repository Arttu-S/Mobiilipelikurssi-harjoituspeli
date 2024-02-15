using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Mobiiliesimerkki
{
	public class Mover : MonoBehaviour
	{
		[SerializeField]
		private float _speed = 1.0f;
		private Rigidbody2D _rb;
		private InputReader _inputReader;
		public float _jumpForce = 15f;

	void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
		_inputReader = GetComponent<InputReader>();
    }
		private Vector2 _direction = Vector2.zero;
	private void Update()
		{
			if(_inputReader.Jump)
            {
                Jump();
            }
			_direction = _inputReader.Movement;
		}

		public void Jump()
        {
			Debug.Log("pitäs pompata ny");
			_rb.AddForce(new Vector2(0f, _jumpForce));
		}
		public void Move(Vector2 direction)
		{
			// transform on oikotie tämän GameObjectin Transform-komponenttiin.
			// transform.position kuvaa peliobjektin sijaintia pelimaailmassa.
			// Sijainnin ovat aina kolmeuloitteisia, vaikka peli olisi
			// kaksiulotteinen.
			Vector3 position = transform.position;
			position += new Vector3(direction.x, direction.y, 0) * _speed * Time.deltaTime;
			//transform.position = position;
			_rb.MovePosition(position);
		}
		
	}

}


using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Mobiiliesimerkki
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class Mover : MonoBehaviour
	{
		[SerializeField]
		private float _speed = 15.0f;
		private Rigidbody2D _rb;
		private InputReader _inputReader;
		public float _jumpForce = 20.0f;
		private bool _isJumping;
		private float _holdForce;

	void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
		_inputReader = GetComponent<InputReader>();
    }
		private Vector2 _direction = Vector2.zero;
	private void Update()
		{
			if(_inputReader.Jump && _isJumping)
            {
				_holdForce += Time.deltaTime * _jumpForce;
				if(_holdForce > _jumpForce)
				{
					_holdForce = _jumpForce;
				}
            }
			else if(_holdForce > _jumpForce / 4 )
			{
				Jump();
				_isJumping = false;
				_holdForce = _jumpForce / 4;
			}
			_direction = _inputReader.Movement;
		}

		public void Jump()
        {
			Debug.Log("Jump!");
			_rb.AddForce(Vector2.up * _holdForce, ForceMode2D.Impulse);
		}


		public void Move(Vector2 direction)
		{
            _rb.AddForce(_direction * _speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
		}

		void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
				_isJumping = true;
            }
        }
		
	}

}


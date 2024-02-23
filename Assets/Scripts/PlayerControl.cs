using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mobiiliesimerkki
{
	/// <summary>
	/// Hallinnoi pelihahmoa. Riippuvuudet: InputReader ja Mover.
	/// </summary>
	[RequireComponent(typeof(InputReader), typeof(Mover))]
	public class PlayerControl : MonoBehaviour
	{
		private const string SpeedAnimationParameter = "Speed";
		private const string DirectionXAnimationParameter = "DirectionX";
		private const string DirectionYAnimationParameter = "DirectionY";
		private InputReader _inputReader = null;
		private Mover _mover = null;
		private Vector2 _movement;
		private Animator _animator = null;
		private SpriteRenderer _spriteRenderer = null;

		private void Awake()
		{
			// Alustetaan InputReader ja Mover Awake-metodissa.
			_inputReader = GetComponent<InputReader>();
			_mover = GetComponent<Mover>();
			_animator = GetComponent<Animator>();
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void Update()
		{
			_movement = _inputReader.Movement;
			UpdateAnimator(_movement);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			ItemVisual itemVisual = other.GetComponent<ItemVisual>();
			if(itemVisual != null)
			{
				//Kerää esine, lisää inventarioon
				Debug.Log("Collected: {itemVisual.Item.Name}");
			}
		}

		private void FixedUpdate() {
			_mover.Move(_movement);
		}

		private void UpdateAnimator(Vector2 movement) {
			if(movement != Vector2.zero) {
				_animator.SetFloat(DirectionXAnimationParameter, _movement.x);
				_animator.SetFloat(DirectionYAnimationParameter, _movement.y);
			}
			_animator.SetFloat(SpeedAnimationParameter, _movement.sqrMagnitude);

			bool lookRight = movement.x > 0;

			_spriteRenderer.flipX = lookRight;
		}
	}
}


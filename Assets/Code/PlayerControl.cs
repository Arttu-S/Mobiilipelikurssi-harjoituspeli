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

        [SerializeField] private float _inventoryMaxWeight = 100;

        private Inventory _inventory = null;
        private void Awake()
        {
            _inputReader = GetComponent<InputReader>();
            _physicsMover = GetComponent<PhysicsMover>();

            _inventory = new Inventory(_inventoryMaxWeight);
        }

        
		private void OnTriggerEnter2D(Collider2D otherCollider)
		{
			if (otherCollider.gameObject.TryGetComponent<Coin>(out Coin coin))
			{
				GameManager.Score += coin.Score;
				Destroy(otherCollider.gameObject);
			}
		}

        // Update is called once per frame
        void Update()
        {
            Vector2 movement = _inputReader.Movement;
            _physicsMover.Move(movement);
        }

		private void Collect(ItemVisual itemVisual)
		{
			// Kerää esine! TODO: Lisää esine inventorioon, kun se on toteutettu.
			if (_inventory.Add(itemVisual.Item, 1)) // TODO: Entä jos kerätään esim. kasa kolikoita?
			{
				Destroy(itemVisual.gameObject);
			}
		}
    }
}

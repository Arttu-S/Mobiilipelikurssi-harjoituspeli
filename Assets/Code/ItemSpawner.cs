using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harjoituspeli
{
	public class ItemSpawner : MonoBehaviour
	{
		// Kuinka usein uusi esine luodaan (sekunteina)
		[SerializeField, Tooltip("Kuinka usein esineitä luodaan (sekunteina)")]
		private float _spawnInterval = 1;

		[SerializeField, Tooltip("Satunnaisaika, joka lisätään spawn rateen")]
		private float _randomInterval = 0.5f;

		[SerializeField, Tooltip("Maksimimäärä spawnattavia esineitä")]
		private int _maxItems = 10;

		[SerializeField, Tooltip("Luotavan esineen sijainnin määrittävän ympyrän säde")]
		private float _spawnRadius = 5;

		[SerializeField, Tooltip("Esineen prefab")]
		private ItemVisual _itemPrefab = null;

		[SerializeField, Tooltip("Debug väri")]
		private Color _debugColor = Color.yellow;

		    [SerializeField] int maxAttempts = 10;

		private float _spawnTimer = 0;
		private int _spawnedItemCount = 0;

		public bool IsTimerRunning => _spawnTimer > 0;

		#region Unity Methods

		private void Start()
		{
			// Asetetaan ensimmäinen spawn timer.
			SetSpawnTimer();
		}

		private void Update()
		{
			if (IsTimerRunning)
			{
				// Päivitetään ajastin
				_spawnTimer -= Time.deltaTime;
				if (_spawnTimer <= 0)
				{
					// Ajastin nollautunut, luodaan uusi esine.
					SpawnItem();
					SetSpawnTimer();
				}
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = _debugColor;
			Gizmos.DrawWireSphere(transform.position, _spawnRadius);
		}

		#endregion Unity Methods

		private bool ValidSpawnLocation(Vector3 position)
		{
			// Tarkistetaan, ettei esine spawnaisi seinän sisään.
			// Tämä voisi olla monimutkaisempikin, mutta tämä on yksinkertainen esimerkki.
			return !Physics2D.OverlapCircle(position, 0.1f);
		}

private ItemVisual SpawnItem()
{
    Vector3 spawnPosition;
    int attempts = 0;

    // Generoidaan satunnainen sijainti ja varmistetaan sen kelvollisuus
    do
    {
        spawnPosition = transform.position + (Vector3)Random.insideUnitCircle * _spawnRadius;
        spawnPosition.z = 0; // Jos spawnerilla olikin z-koordinaatti
        attempts++;

        // Lisää tarkistus, joka lopettaa silmukan, jos liian monta yritystä on tehty
        if (attempts >= maxAttempts)
        {
            Debug.LogWarning("Silmukka lopetettu, koska yritettiin liian monta kertaa.");
            return null;
        }
    } while (!ValidSpawnLocation(spawnPosition)); // Jatka, kunnes löydetään kelvollinen sijainti

    // Varsinainen esineen luominen.
    // Quaternion.identity kappaletta ei ole rotatoitu.
    ItemVisual item = Instantiate(_itemPrefab, spawnPosition, Quaternion.identity);
    _spawnedItemCount++;

    return item;
}

		private bool SetSpawnTimer()
		{
			if (_spawnedItemCount >= _maxItems)
			{
				// Maksimimäärä esineitä luotu, ei jatketa enää.
				return false;
			}

			_spawnTimer = _spawnInterval + Random.Range(-_randomInterval, _randomInterval);
			return true;
		}
	}
}

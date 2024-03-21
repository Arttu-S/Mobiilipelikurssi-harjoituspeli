using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harjoituspeli
{
	public class ItemVisual : MonoBehaviour
	{
		// Viittaus Item-ScriptableObjectiin projektissa.
		[SerializeField] private Item _item = null;

		public Item Item => _item; 
	}
}

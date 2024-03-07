using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harjoituspeli
{
    public class Inventory
    {
        // Sisältää avain-arvopareja. Kunkin avaimen on oltava uniikki.
        // Avain: Item, Arvo: Määrä (uint).
        // uint: unsigned integer, eli ei-negatiivinen kokonaisluku.
        private Dictionary<Item, uint> _items = new Dictionary<Item, uint>();

        private float MaxWeight { get; }

        public Inventory(float maxWeight)
        {
            // Auto-propertyn arvoa ei voi muuttaa, joten asetetaan se konstruktorissa.
            MaxWeight = maxWeight;
        }

        // Toiminnallisuus:
        // 1. Lisääminen
        // 2. Poistaminen
        // 3. Tavaran haku
        // 3.1 Onko tavara olemassa
        // 4. Kokonaispaino
        // 5. Kokonaisarvo

        public bool Add(Item item, uint amount)
        {
            //Tarkista, ylittyykö inventory max paino
            if (GetWeight() + item.Weight * amount > MaxWeight)
            {
                return false;
            }

            if (item.IsKeyItem)
            {
                // Jos kyseessä on avain, niin lisätään vain yksi kappale.
                _items.Add(item, amount);
                return true;
            }

            // Tarkista, onko tavara jo inventaariossa.
            bool exists = _items.ContainsKey(item);
            if (exists)
            {
                // Jos on, niin lisätään määrää.
                _items[item] += amount;
            }
            else
            {
                // Jos ei ole, niin lisätään uusi avain-arvo -pari.
                _items.Add(item, amount);
            }

            return true;
        }

        public bool Remove(Item item, uint amount)
        {
            // Tarkista, onko tavara olemassa.
            if (!_items.ContainsKey(item) || _items[item] < amount)
            {
                return false;
            }
            if (_items[item] == amount)
            {
                _items.Remove(item);
            }
            else
            {
                _items[item] -= amount;
            }

            return true;
        }

        public float GetWeight()
        {
            float weight = 0;
            foreach (KeyValuePair<Item, uint> item in _items)
            {
                weight += item.Key.Weight * item.Value;
            }
            return weight;
        }

        public float GetValue()
        {
            float value = 0;
            foreach (KeyValuePair<Item, uint> item in _items)
            {
                value += item.Key.Value * item.Value;
            }
            return value;
        }


        public void Clear()
        {
            _items.Clear();
        }

        public List<Item, uint> GetItems()
        {
            List<Item, uint> items = new List<Item, uint>();
            foreach (KeyValuePair<Item, uint> item in _items)
            {
                items.Add((item.Key, item.Value));
            }
            return items;
        }
    }
}

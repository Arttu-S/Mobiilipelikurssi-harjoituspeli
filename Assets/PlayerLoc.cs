using UnityEngine;

namespace Mobiiliesimerkki
{
    public class PlayerLoc : MonoBehaviour
    {
        public UnityEngine.Transform p; //pelaajan gameobject

        // Update is called once per frame
        void Update()
        {
            Vector3 pos = p.transform.position;
            pos.z = -10; // Dumb
            gameObject.transform.position = pos;
        }
    }
}

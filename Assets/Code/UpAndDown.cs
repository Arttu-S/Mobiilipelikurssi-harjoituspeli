using UnityEngine;

namespace Harjoituspeli
{
    public class UpAndDown : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5f;
        [SerializeField]
        private float minY = -5f; // Minimum coordinate
        [SerializeField]
        private float maxY = 5f;  // Maximum coordinate

        private int direction = 1; // 1 up, -1 down

        // Update is called once per frame
        void Update()
        {
            // Move the object up or down based on the direction
            float verticalMovement = direction * speed * Time.deltaTime;
            transform.Translate(new Vector3(0f, verticalMovement, 0f));

            // Check if the object has reached the upper or lower bounds
            if (transform.position.y <= minY || transform.position.y >= maxY)
            {
                // Reverse the direction to change the motion
                direction *= -1;
            }
        }
    }
}

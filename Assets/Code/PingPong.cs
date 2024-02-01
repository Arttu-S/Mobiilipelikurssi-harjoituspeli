using UnityEngine;

public class PingPong : MonoBehaviour
{
    public float speed = 5f;
    public float distance = 5f;

    private Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate movement based on sine function to make it go back and forth
        float movement = Mathf.Sin(Time.time * speed) * distance;

        // Update the Rigidbody2D position
        GetComponent<Rigidbody2D>().MovePosition(startPosition + new Vector2(movement, 0f));
    }
}

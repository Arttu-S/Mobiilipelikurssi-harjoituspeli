using UnityEngine;

namespace Harjoituspeli {
public class LaunchAndFall : MonoBehaviour
{
    public float launchSpeed = 10f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Launch the object upwards
        rb.velocity = new Vector2(0f, launchSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Apply full gravity effect
        rb.velocity += new Vector2(0f, Physics2D.gravity.y * Time.deltaTime);
    }
}
}
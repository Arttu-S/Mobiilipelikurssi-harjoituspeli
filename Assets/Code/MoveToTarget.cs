using UnityEngine;

namespace Harjoituspeli {
public class MoveToTarget : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
            MoveCharacter(target.position);
    }

    void MoveCharacter(Vector2 targetPosition)
    {
        // Laske suunta kohteen suuntaan
        Vector2 direction = (targetPosition - rb.position).normalized;

        // Laske liikkumisvektori
        Vector2 movement = direction * moveSpeed * Time.deltaTime;

        // Liikuta hahmoa käyttäen Rigidbody2D-komponenttia
        rb.MovePosition(rb.position + movement);
    }
}
}
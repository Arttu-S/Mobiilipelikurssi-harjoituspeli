using UnityEngine;

public class PingPong : MonoBehaviour
{
    public float speed = 5f;
    public float minX = -5f; // Minimikoordinaatti
    public float maxX = 5f;  // Maksimikoordinaatti

    private int direction = 1; // Liikkumissuunta: 1 eteenpäin, -1 taaksepäin

    // Update is called once per frame
    void Update()
    {
        // Liikuta oliota vaakasuunnassa
        float horizontalMovement = direction * speed * Time.deltaTime;
        transform.Translate(new Vector3(horizontalMovement, 0f, 0f));

        // Tarkista, onko olio saavuttanut reunan
        if (transform.position.x <= minX || transform.position.x >= maxX)
        {
            // Vaihda liikkumissuuntaa
            direction *= -1;
        }
    }
}

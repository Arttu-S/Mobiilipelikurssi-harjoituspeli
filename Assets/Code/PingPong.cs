using UnityEngine;

namespace Harjoituspeli {
public class PingPong : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float minX = -5f; // Minimikoordinaatti
    [SerializeField]
    private float maxX = 5f;  // Maksimikoordinaatti

    private int direction = 1; // Liikkumissuunta: 1 eteenpäin, -1 taaksepäin
    private float initialX; // Alkuperäinen X-koordinaatti

    // Start is called before the first frame update
    void Start()
    {
        initialX = transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Liikuta oliota vaakasuunnassa
        float horizontalMovement = direction * speed * Time.deltaTime;
        transform.Translate(new Vector3(horizontalMovement, 0f, 0f), Space.Self);

        // Tarkista, onko olio saavuttanut reunan
        if (transform.localPosition.x <= initialX + minX || transform.localPosition.x >= initialX + maxX)
        {
            // Vaihda liikkumissuuntaa
            direction *= -1;
        }
    }
}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform : MonoBehaviour
{
    [SerializeField]    //Saa privatet näkymään editorin puolella
    private float speed = 10;
    [SerializeField]
    private float distance = 8;
    private float startx;
    void Start()
    {
        startx = transform.position.x;  //Aloittaa x -positiosta
    }

    void Update()
    {   //Vector2: liikkuu kahdessa dimensiossa, Mathf.pingpong palauttaa luvun 0-distance väliltä
        transform.position = new Vector2(startx + -Mathf.PingPong(Time.time * speed, distance), transform.position.y);
    }
}

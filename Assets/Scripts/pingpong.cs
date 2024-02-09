using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform : MonoBehaviour
{
    [SerializeField]    //Saa privatet näkymään editorin puolella
    private float speed = 10;
    [SerializeField]
    private float distance = 8;
    [SerializeField] private bool isMovingX;
    [SerializeField] private bool reverseDirection;
    private float startx;
    private float starty;
    
    void Start()
    {
        starty = transform.position.y;
        startx = transform.position.x;  //Aloittaa x -positiosta
    }

    void Update()
    {   //Vector2: liikkuu kahdessa dimensiossa, Mathf.pingpong palauttaa luvun 0-distance väliltä
        float move = Mathf.PingPong(Time.time * speed, distance);
        if(reverseDirection) {
            move = -move;
        }
        if(isMovingX) {
            transform.position = new Vector2(startx + move, transform.position.y);
        } else {
            transform.position = new Vector2(transform.position.x, starty + move);
        }
    }
}

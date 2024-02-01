using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harjoituspeli
{
public class Mover : MonoBehaviour

{
    [SerializeField]
    private float _speed = 1.0f;
    // Start is called before the first frame update

    public void Move(Vector2 direction)
    {
        Vector3 position = transform.position;
        position += new Vector3(direction.x, direction.y, 0) * _speed * Time.deltaTime;
        transform.position = position;
    }
}
}
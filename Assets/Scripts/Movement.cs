using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 _direction;
    public Vector2 Direction { get => _direction; set => _direction = value; }

    [SerializeField]
    private bool useGravity;

    private void LateUpdate()
    {
        if(useGravity)
        {

        }


        Move();
    }

    private void Move()
    {

    }
}

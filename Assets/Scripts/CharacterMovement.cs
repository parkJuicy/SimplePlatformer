using System.Collections;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector2 _velocity;

    public void AddForce(Vector2 force)
    {
        _velocity += force;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_velocity * Time.deltaTime);
    }
}

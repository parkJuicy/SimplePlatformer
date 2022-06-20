using UnityEngine;
using InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private Movement _movement;

    private void Awake()
    {
        if(_movement == null)
        {
            _movement = GetComponent<Movement>();
        }
    }

    private void Update()
    {
        
    }
}

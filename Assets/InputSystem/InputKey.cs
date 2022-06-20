using UnityEngine;

namespace InputSystem
{
    public class KeyInput
    {
        public bool IsKeyPressed { get; set; }
        public bool IsKeyUp { get; set; }
        public bool IsKeyDown { get; set; }
        public KeyCode Code { get; set; }

        public KeyInput(KeyCode code)
        {
            Code = code;
        }
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

public class Rogue_Inputs : MonoBehaviour
{
    public float moveX;
    
    public bool jump;

    public void OnMove(InputValue value)
    {
        moveX = value.Get<Vector2>().x;
    }

    public void OnJump(InputValue value)
    {
        jump = value.isPressed;
    }
}

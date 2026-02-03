using UnityEngine;
using UnityEngine.InputSystem;

public class Rogue_Inputs : MonoBehaviour
{
    public float moveX;
    
    public bool jump;
    public bool interact;
    public bool dash;

    public void OnMove(InputValue value)
    {
        moveX = value.Get<Vector2>().x;
    }

    public void OnJump(InputValue value)
    {
        jump = value.isPressed;
    }

    public void OnInteract(InputValue value)
    {
        interact = value.isPressed;
    }

    public void OnDash(InputValue value)
    {
        dash = value.isPressed;
    }
}

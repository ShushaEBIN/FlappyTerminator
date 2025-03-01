using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const KeyCode TapKey = KeyCode.Space;
    private const KeyCode ShootButton = KeyCode.D;

    public bool ReturnTapPressed() 
    { 
        return Input.GetKeyDown(TapKey);
    }

    public bool ReturnShootPressed()
    {
        return Input.GetKeyDown(ShootButton);
    }
}
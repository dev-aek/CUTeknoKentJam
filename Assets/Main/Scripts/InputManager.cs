using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;

    private static InputManager _instance;
    public static InputManager Instance => _instance;


    private void Awake()
    {
        if(_instance !=null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        playerControls = new PlayerControls();
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 getPlayerMovement()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }


    public Vector2 getMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumpThisFrame()
    {
        return playerControls.Player.Jump.triggered;
    }

    public bool PlayerRunThisFrame()
    {
        return playerControls.Player.Run.IsPressed();
    }



}

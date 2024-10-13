using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput ;
    private PlayerInput.OnFootActions onFoot ;

    private PlayerMotor motor ;
    private PlayerLook look ;
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>() ;

        onFoot.Jump.performed += ctx => motor.Jump() ;
    }

    void FixedUpdate()
    {
        // Read input from the PlayerInput system and process movement
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>()) ;
    }

    private void OnEnable()
    {
        // Enable input actions
        onFoot.Enable();
    }

    private void OnDisable()
    {
        // Disable input actions
        onFoot.Disable();
    }
}

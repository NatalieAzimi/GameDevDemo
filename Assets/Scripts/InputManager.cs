using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;


    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        onFoot.Jump.performed += ctx => motor.Jump();
    }


    void FixedUpdate() {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());

    }


    private void OnEnable() {
        onFoot.Enable();
    }
    
    private void OnDisable()
    {
        onFoot.Disable();
    }


}

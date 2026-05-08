using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, IInput
{

    private Vector2 moveInput;
    private bool _interactPressed;
    private bool _attackPressed;
    private bool _switchWeaponPressed;
    private bool _consumePressed;
    public void OnMove(InputValue value)
    {
        if (!enabled) return;
        moveInput = value.Get<Vector2>();
       
    }

    public Vector2 GetInputDetection()
    {
        return moveInput;
    }

    public void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            _interactPressed = true;
        }
    }
    public void OnSwitchWeapon(InputValue value)
    {
        _switchWeaponPressed = value.isPressed;
    }

    public void OnAttack(InputValue value)
    {
        _attackPressed = value.Get<float>() > 0;
    }

    public void OnConsume(InputValue value)
    {
        if (value.isPressed) _consumePressed = true;
    }

    public bool GetInteractPressed()
    {
        bool pressed = _interactPressed;
        _interactPressed = false; 
        return pressed;
    }
    public bool GetAttackPressed()
    {
        return _attackPressed;
    }

    public bool GetSwitchWeaponPressed()
    {
        bool pressed = _switchWeaponPressed;
        _switchWeaponPressed = false;
        return pressed;
    }

    public bool GetConsumePressed()
    {
        bool pressed = _consumePressed;
        _consumePressed = false;
        return pressed;
    }
}

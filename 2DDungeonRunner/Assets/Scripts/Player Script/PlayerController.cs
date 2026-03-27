using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private MonoBehaviour _inputType;
    [SerializeField] private InteractionDetector _interaction;
    [SerializeField] private LookAt _lookAt;
    [SerializeField] private WeaponHolder _weaponHolder;


    private IInput _input;
    private Vector2 _currentInputDirection;

    private void Awake()
    {
        _input = _inputType as IInput;
    }

    private void Update()
    {
        _currentInputDirection = _input.GetInputDetection();

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _lookAt.LookAtMouse(mousePos);

        if (_input.GetInteractPressed())
            _interaction.Interact();

        if (_input.GetAttackPressed())
            _weaponHolder.Attack();

        if (_input.GetSwitchWeaponPressed())
            _weaponHolder.SwitchWeapon();
        
    }

    private void FixedUpdate()
    {
        _movement.Move(_currentInputDirection);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _lookAt.LookAtMouse(mousePos);
    }
}

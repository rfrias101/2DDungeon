using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private MonoBehaviour _inputType;
    [SerializeField] private InteractionDetector _interaction;

    private IInput _input;
    private Vector2 _currentInputDirection;

    private void Awake()
    {
        _input = _inputType as IInput;
    }

    private void Update()
    {
        _currentInputDirection = _input.GetInputDetection();

        if (_input.GetInteractPressed())
            _interaction.Interact();

        if (_input.GetAttackPressed())
            Debug.Log("Attack!");
    }

    private void FixedUpdate()
    {
        _movement.Move(_currentInputDirection);
    }
}

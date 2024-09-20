using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReaderSO : ScriptableObject, IPlayerActions
{
    public event Action<Vector2> Movement;
    public event Action Jump;

    Controls _control;

    private Vector2 moveDir;

    private void OnEnable()
    {
        if (_control == null)
        {
            _control = new Controls();
            _control.Player.SetCallbacks(this);
        }

        _control.Enable();

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) Jump?.Invoke();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>();
        Movement?.Invoke(moveDir);
    }
}

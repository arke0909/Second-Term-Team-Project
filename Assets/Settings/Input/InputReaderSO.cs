using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReaderSO : ScriptableObject, IPlayerActions, IPlayerComponent
{
    public event Action<Vector2> Movement;
    public event Action Jump;

    Controls _control;

    public Vector2 MoveDir { get; private set; }
    private Player _player;

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
        MoveDir = context.ReadValue<Vector2>();
        Movement?.Invoke(MoveDir);
    }

    public void Initialize(Player player)
    {
        _player = player;
    }
}

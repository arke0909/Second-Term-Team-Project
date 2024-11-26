using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReaderSO : ScriptableObject, IPlayerActions, IUIActions, IPlayerComponent
{
    public event Action<Vector2> Movement;
    public event Action Jump;

    Controls _control;

    public Vector2 MoveDir { get; private set; }
    private Player _player;

    private void OnEnable()
    {
        try
        {
            if (_control == null)
            {
                _control = new Controls();
                _control.Player.SetCallbacks(this);
                _control.UI.SetCallbacks(this);
            }

            _control.Player.Enable();
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
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

    public void InputChange()
    {
        Debug.Log(_control.Player.enabled);
        if (_control.Player.enabled == true)
        {
            _control.Player.Disable();
            _control.UI.Enable();
        }
        else
        {
            _control.Player.Enable();
            _control.UI.Disable();
        }

    }

    public void OnESC(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("¹ßµ¿");
            InputChange();
        }
    }
}

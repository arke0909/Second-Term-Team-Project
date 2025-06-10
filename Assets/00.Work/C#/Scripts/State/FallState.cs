public class FallState : State
{
    public FallState(Player player, string animaName, StateMachine stateMachine) : base(player, animaName, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _groundChecker.IsGround.OnValueChanged += HandleIsGroundChange;
    }

    public override void StateFixedUpdate()
    {
        _playerMovement.Movement();
    }

    private void HandleIsGroundChange(bool prev, bool next)
    {
        if (next)
        {
            _player.LandingEvent?.Invoke();
            _stateMachine.ChageState(PlayerStateEnum.Idle);
        }
    }

    public override void Exit()
    {
        _groundChecker.IsGround.OnValueChanged -= HandleIsGroundChange;
        base.Exit();
    }
}

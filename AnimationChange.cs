using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationChange : MonoBehaviour
{
    private const string JumpAnimationName = "jump_hero";
    private const string RunAnimationName = "run_hero";
    private const string IdleAnimationName = "idle_hero";

    [SerializeField] private Movement _player;

    private Animator _animator;
    private bool _isJump;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Movement>();
    }

    private void OnEnable()
    {
        _player.Running += OnRunning;
        _player.Jumped += OnJumped;
    }

    private void OnDestroy()
    {
        _player.Running -= OnRunning;
        _player.Jumped -= OnJumped;
    }

    private void OnRunning(float valueXPosition)
    {
        if (valueXPosition != 0 && _isJump == false)
            _animator.Play(RunAnimationName);
        else if (_isJump == false)
            _animator.Play(IdleAnimationName);
    }

    private void OnJumped(bool isJump)
    {
        _animator.Play(JumpAnimationName);
        _isJump = isJump;
    }
}

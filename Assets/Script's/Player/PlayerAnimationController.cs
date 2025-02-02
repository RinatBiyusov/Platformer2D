using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string Run = nameof(Run);

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TriggerRun(float value)
    {
        if (Mathf.Abs(value) > 0)
            _animator.SetBool(Run, true);
        else
            _animator.SetBool(Run, false);
    }
}

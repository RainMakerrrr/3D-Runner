using PlayerController.Movement;
using UnityEngine;
using Zenject;

namespace PlayerController.Animations
{
    public class PlayerAnimation : MonoBehaviour
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int IsPushing = Animator.StringToHash("isPushing");
        private static readonly int IsDodgeLeft = Animator.StringToHash("isDodgeLeft");
        private static readonly int IsDodgeRight = Animator.StringToHash("isDodgeRight");
        private static readonly int Action = Animator.StringToHash("inAction");

        public bool InAction => _animator.GetBool(Action);
        
        private PlayerMovement _movement;
        private Animator _animator;

        [Inject]
        private void Construct(PlayerMovement movement, Animator animator)
        {
            _movement = movement;
            _animator = animator;
        }
        
        private void Update() => UpdateMovementAnimation();

        private void UpdateMovementAnimation() => _animator.SetFloat(Speed, _movement.Speed);


        public void SetDodgeLeftAnimation()
        {
            _animator.SetTrigger(IsDodgeLeft);
            _animator.SetBool(Action,true);
        }

        public void SetDodgeRightAnimation()
        {
            _animator.SetTrigger(IsDodgeRight);
            _animator.SetBool(Action,true);
        }

        public void SetPushingAnimation(bool isPushing) => _animator.SetBool(IsPushing,isPushing);
    }
}
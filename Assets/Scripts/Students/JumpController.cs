using UnityEngine;

namespace DefaultNamespace {
    public class JumpController : MonoBehaviour {
        [SerializeField] private Animator _animator;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
        }

        private void Jump() {
            bool isGround = Player.Instance.State.IsGrounded;
            bool canJump = !Player.Instance.State.IsJumping;
            bool isNotStagger = !Player.Instance.State.IsStagger;

            if (isGround && canJump && isNotStagger) {
                _animator.Play("Jump", -1, 0.0f);
            }
        }
    }
}
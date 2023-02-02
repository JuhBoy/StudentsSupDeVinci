using Students;
using UnityEngine;

namespace DefaultNamespace {
    public class JumpController : MonoBehaviour {
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody2D _body2D;
        [SerializeField] private float vSpeed;

        private void Update() {
            PlayerState state = Player.Instance.State;
            if (Input.GetKeyDown(KeyCode.Space) && state.ControlState == ControlState.Movable)
                Jump();
        }

        private void Jump() {
            bool isGround = Player.Instance.State.IsGrounded;
            bool canJump = !Player.Instance.State.IsJumping;
            bool isNotStagger = !Player.Instance.State.IsStagger;

            if (isGround && canJump && isNotStagger) {
                _animator.Play("Jump", -1, 0.0f);
            }
            
            if (Input.GetKeyDown(KeyCode.Space)) {
                _body2D.AddForce(new Vector2(0, vSpeed), ForceMode2D.Impulse);
            }
        }
    }
}
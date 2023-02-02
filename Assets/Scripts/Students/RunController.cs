using Students;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class RunController : MonoBehaviour {
    private Animator _animator;
    private Rigidbody2D _body2D;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float speed;

    [SerializeField] private BoxCollider2D box;
    private static readonly int Running = Animator.StringToHash("Running");

    private void Awake() {
        _animator = gameObject.GetComponent<Animator>();
        _body2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update() {
        PlayerState state = Player.Instance.State;

        if (state.ControlState == ControlState.Movable)
            Move();
        else 
            _animator.SetBool(Running, false);
        
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) {
            _body2D.velocity = new Vector2(0, _body2D.velocity.y);
        }
    }

    private void Move() {
        _animator.SetBool(Running, Input.GetKey(KeyCode.D));

        if (Input.GetKey(KeyCode.D)) {
            _body2D.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
            _spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.A)) {
            _body2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
            _spriteRenderer.flipX = true;
        }
    }

    private void FixedUpdate() {
        Vector2 vel = _body2D.velocity;
        _body2D.velocity = new Vector2(Mathf.Clamp(vel.x, -maxSpeed, maxSpeed), vel.y);
    }

    private void ClickHappened() { }
}
using System;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class RunController : MonoBehaviour {
    private Animator _animator;
    private Rigidbody2D _body2D;

    [SerializeField] private float maxSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float vSpeed;

    private static readonly int Running = Animator.StringToHash("Running");

    private void Awake() {
        _animator = GetComponent<Animator>();
        _body2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update() {
        _animator.SetBool(Running, Input.GetKey(KeyCode.D));
        if (Input.GetKey(KeyCode.D)) {
            _body2D.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            _body2D.AddForce(new Vector2(0, vSpeed), ForceMode2D.Impulse);
        }

        Vector2 velocity = _body2D.velocity;
        Debug.Log(velocity);
    }

    private void FixedUpdate() {
        Vector2 vel = _body2D.velocity;
        _body2D.velocity = new Vector2(Mathf.Clamp(vel.x, -maxSpeed, maxSpeed), Mathf.Clamp(vel.y, -vSpeed, vSpeed));
    }

    private void ClickHappened() { }
}
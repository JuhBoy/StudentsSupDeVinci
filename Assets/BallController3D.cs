using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController3D : MonoBehaviour {
    [SerializeField] private Vector2 target;
    [SerializeField] private float speed;

    private Rigidbody _rigidbody;
    
    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 step = Vector3.Lerp(transform.position, new Vector3(target.x, transform.position.y, target.y),
            speed * Time.deltaTime);
        transform.position = step;
    }
}
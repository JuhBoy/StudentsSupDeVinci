using System;
using UnityEngine;

namespace DefaultNamespace {
    public class Player : MonoBehaviour {
        private PlayerState _state;

        public static Player Instance { get; private set; }
        public PlayerState State => _state;

        private void Awake() {
            Instance = this;
            _state = new PlayerState() {
                IsGrounded = true,
                IsJumping = false,
                IsStagger = false
            };
        }
    }
}
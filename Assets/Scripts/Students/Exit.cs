using System;
using Students;
using UnityEngine;

namespace DefaultNamespace {
    public class Exit : MonoBehaviour {
        [SerializeField] private GameObject exitIndicator;
        
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Player")) {
                exitIndicator.SetActive(true);
                Player.Instance.State.ControlState = ControlState.None;
            }
        }
    }
}
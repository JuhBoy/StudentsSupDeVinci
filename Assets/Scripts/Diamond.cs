using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace {
    [RequireComponent(typeof(Animator))]
    public class Diamond : MonoBehaviour {
        private static readonly int CollectedAnimHash = Animator.StringToHash("DiamondCatch");

        [SerializeField] private int count;
        [SerializeField] private float animationDurationInSeconds;

        [NonSerialized] private Animator animator;
        [NonSerialized] private bool collected;

        private void Awake() {
            animator = GetComponent<Animator>();
        }

        public int Count => count;

        public bool TryCollect(out int collectedCount) {
            collectedCount = -1;

            if (collected) return false;

            collectedCount = Count;
            OnCollected();

            return (collected = true);
        }

        private void OnCollected() {
            animator.Play(CollectedAnimHash, -1, .0f);
            StartCoroutine(WaitingEndsOfAnimationCoroutine());
        }

        private IEnumerator WaitingEndsOfAnimationCoroutine() {
            yield return new WaitForSeconds(animationDurationInSeconds);
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
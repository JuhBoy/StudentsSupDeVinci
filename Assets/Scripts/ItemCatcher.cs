using System;
using Students;
using UnityEngine;

namespace DefaultNamespace {
    public class ItemCatcher : MonoBehaviour {
        private static readonly string DiamondTag = "Diamond";

        private void OnTriggerEnter2D(Collider2D potentialDiamond) {
            if (!potentialDiamond.CompareTag(DiamondTag)) return;

            CollectState state = Player.Instance.CollectState;
            var diamondComponent = potentialDiamond.GetComponent<Diamond>();

            if (diamondComponent.TryCollect(out int collectedCount)) {
                state.DiamondCount += collectedCount;
            }
        }
    }
}
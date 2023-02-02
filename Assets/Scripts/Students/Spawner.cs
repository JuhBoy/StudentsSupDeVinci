using Students;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private Transform player;
    [SerializeField] private Vector2 startPlayerPosition;
    [SerializeField] private Transform startElement;

    private void Awake() {
        Vector3 positionEl = startElement.position;
        player.position = new Vector3(positionEl.x, positionEl.y, 0);
        Player.Instance.State.ControlState = ControlState.Movable;
    }

    // TODO: Visualize anchor for spawn.
}
using UnityEngine;

public class Interactor : MonoBehaviour {
    [SerializeField] private float pickupDistance = 1.5f;

    public bool CanInteract(Transform anotherObject) {
        return Vector2.Distance(
            transform.position,
            anotherObject.position
        ) <= pickupDistance;
    }
}

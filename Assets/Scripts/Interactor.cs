using UnityEngine;

public class Interactor : MonoBehaviour {
    [SerializeField] private float pickupDistance = 1.5f;

    public bool CanInteract(Transform anotherObject) {
        // hack
        var collider1 = GetComponent<Collider2D>();
        var collider2 = anotherObject.GetComponent<Collider2D>();

        return collider1.Distance(collider2).distance <= pickupDistance;
    }
}

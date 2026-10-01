using System;
using UnityEngine;

public class PickableItem : MonoBehaviour {
    public void Pickup(Transform interactor) {
        var newItem = Instantiate(gameObject, interactor, true);
        newItem.transform.localPosition = Vector3.zero;
        newItem.transform.localRotation = Quaternion.identity;
        newItem.GetComponent<Collider2D>().enabled = false;
    }
}

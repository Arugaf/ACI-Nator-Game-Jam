using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PickableItem : MonoBehaviour {
    public string itemName;

    public PickableItem Pickup(Transform interactor) {
        var newItem = Instantiate(gameObject, interactor, true);
        newItem.transform.localPosition = Vector3.zero;
        newItem.transform.localRotation = Quaternion.identity;
        newItem.GetComponent<Collider2D>().enabled = false;

        return newItem.GetComponent<PickableItem>();
    }
}

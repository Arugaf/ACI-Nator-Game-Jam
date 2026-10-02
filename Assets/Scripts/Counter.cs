using System;
using UnityEngine;

public class Counter : MonoBehaviour {
    [SerializeField] private ItemSequenceObserver observer;

    private void Awake() {
        if (observer == null) throw new Exception("Need Item Sequence Observer");
    }

    public void AcceptItem(Transform interactor, PickableItem item, Aura aura) {
        if (item == null || aura == null) return;

        observer.InsertItem(interactor, item, aura);
    }
}

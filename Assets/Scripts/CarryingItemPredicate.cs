using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(PickableItemInteractor))]
public class CarryingItemPredicate : Predicate {
    private PickableItemInteractor _interactor;

    private void Awake() {
        if (_interactor == null) _interactor = GetComponent<PickableItemInteractor>();
    }

    public override bool Evaluate(GameObject target) {
        return !_interactor.CurrentlyCarryingItem;
    }
}

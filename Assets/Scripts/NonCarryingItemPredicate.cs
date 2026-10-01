using System;
using UnityEngine;

[Serializable]
public class NonCarryingItemPredicate : Predicate {
    [SerializeField] private PickableItemInteractor interactor;

    public override bool Evaluate(GameObject target) {
        return interactor.currentlyCarryingItem;
    }
}
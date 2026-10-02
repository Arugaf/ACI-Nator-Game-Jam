using System;
using UnityEngine;

[Serializable]
public class CurrentlyWithAuraPredicate : Predicate {
    [SerializeField] private AuraInteractor interactor;

    public override bool Evaluate(GameObject target) {
        return !interactor.currentlyWithAura;
    }
}

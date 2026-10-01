using System;
using UnityEngine;

[Serializable]
public abstract class Predicate : MonoBehaviour {
    public abstract bool Evaluate(GameObject target);
}

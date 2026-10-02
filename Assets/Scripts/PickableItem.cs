using PlayerEffects;
using UnityEngine;

public class PickableItem : MonoBehaviour {
    public string itemName;
    public ReactionSystem.Category category;

    private StatusEffect[] _effects;

    private void Awake() {
        _effects = GetComponents<StatusEffect>();
    }

    public PickableItem Pickup(Transform interactor, Transform parent) {
        var newItem = Instantiate(gameObject, parent, true);
        newItem.transform.localPosition = Vector3.zero;
        newItem.transform.localRotation = Quaternion.identity;
        newItem.GetComponent<Collider2D>().enabled = false;

        var effectController = interactor.GetComponent<EffectController>();
        if (effectController == null) return newItem.GetComponent<PickableItem>();

        foreach (var effect in _effects) {
            Debug.Log("New effect " + effect.GetType().Name);
            effectController.AddEffect(effect, gameObject);
        }

        return newItem.GetComponent<PickableItem>();
    }
}

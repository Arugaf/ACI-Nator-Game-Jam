using PlayerEffects;
using UnityEngine;

public class Aura : MonoBehaviour {
    public string auraName;
    public Color auraColor =  Color.white;

    public StatusEffect[] Effects { get; private set; }

    private void Awake() {
        Effects = GetComponents<StatusEffect>();
    }

    public Aura Pickup(Transform interactor) {
        var newAura = Instantiate(gameObject, interactor, true);
        newAura.transform.localPosition = Vector3.zero;
        newAura.transform.localRotation = Quaternion.identity;
        newAura.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f); // hack
        newAura.GetComponent<Collider2D>().enabled = false;

        // var effectController = interactor.GetComponent<EffectController>();
        // if (effectController == null) return newAura.GetComponent<Aura>();
        //
        // foreach (var effect in Effects) {
        //     Debug.Log("New effect " + effect.GetType().Name);
        //     effectController.AddEffect(effect, gameObject);
        // }

        return newAura.GetComponent<Aura>();
    }
}

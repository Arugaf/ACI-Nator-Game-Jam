using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AuraLight : MonoBehaviour {
    [SerializeField] private Light2D lightSource;

    private void Awake() {
        ResetLight();
    }

    public void SetAura(Aura aura) {
        lightSource.color = aura.auraColor;
        lightSource.enabled = true;
    }

    public void ResetLight() {
        lightSource.enabled = false;
    }
}

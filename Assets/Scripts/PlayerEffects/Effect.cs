using UnityEngine;

namespace PlayerEffects {
    public struct EffectContext {
        public GameObject Source;
        public GameObject Target;

        public EffectContext(GameObject source, GameObject target) {
            Source = source;
            Target = target;
        }
    }

    public abstract class Effect : MonoBehaviour {
        public abstract void Apply(EffectContext context);
    }
}
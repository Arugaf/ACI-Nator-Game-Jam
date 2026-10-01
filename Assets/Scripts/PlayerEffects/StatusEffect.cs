using UnityEngine;

namespace PlayerEffects {
    public abstract class StatusEffect : Effect {
        [SerializeField] private float _duration = 5f;

        public float Duration => _duration;

        public abstract void OnStart(EffectContext context);

        public abstract void OnUpdate(
            EffectContext context,
            float deltaTime);

        public abstract void OnEnd(EffectContext context);
    }
}

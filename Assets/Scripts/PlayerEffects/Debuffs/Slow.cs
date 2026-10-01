using UnityEngine;

namespace PlayerEffects.Debuffs {
    public class Slow : StatusEffect {
        [SerializeField] [Range(0f, 1f)] private float slowMultiplier = 0.5f;

        public override void Apply(EffectContext context) {
            throw new System.NotImplementedException();
        }

        public override void OnStart(EffectContext context) {
            context.Target.GetComponent<CharacterController2D>()?.MultiplySpeed(slowMultiplier);
        }

        public override void OnUpdate(EffectContext context, float deltaTime) { }

        public override void OnEnd(EffectContext context) {
            context.Target.GetComponent<CharacterController2D>()?.MultiplySpeed(1f / slowMultiplier);
        }
    }
}

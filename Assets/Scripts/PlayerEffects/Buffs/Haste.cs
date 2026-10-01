using UnityEngine;

namespace PlayerEffects.Buffs {
    public class Haste : StatusEffect {
        [SerializeField] [Range(1f, 10f)] private float hasteMultiplier = 2f;

        public override void Apply(EffectContext context) {
            throw new System.NotImplementedException();
        }

        public override void OnStart(EffectContext context) {
            var controller = context.Target.GetComponent<CharacterController2D>();
            if (controller == null) return;

            controller.MultiplySpeed(hasteMultiplier);
        }

        public override void OnUpdate(EffectContext context, float deltaTime) { }

        public override void OnEnd(EffectContext context) {
            context.Target.GetComponent<CharacterController2D>()?.MultiplySpeed(1f / hasteMultiplier);
        }
    }
}
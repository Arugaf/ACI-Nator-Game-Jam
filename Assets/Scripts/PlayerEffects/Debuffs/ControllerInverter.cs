using UnityEngine;

namespace PlayerEffects.Debuffs {
    public class ControllerInverter : StatusEffect {
        public override void Apply(EffectContext context) {
            throw new System.NotImplementedException();
        }

        public override void OnStart(EffectContext context) {
            context.Target.GetComponent<CharacterController2D>()?.InvertController();
        }

        public override void OnUpdate(EffectContext context, float deltaTime) { }

        public override void OnEnd(EffectContext context) {
            context.Target.GetComponent<CharacterController2D>()?.InvertController();
        }
    }
}
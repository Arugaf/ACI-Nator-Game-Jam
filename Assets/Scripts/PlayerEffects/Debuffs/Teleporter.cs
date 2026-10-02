using UnityEngine;

namespace PlayerEffects.Debuffs {
    public class Teleporter : StatusEffect {
        [SerializeField] private Transform[] teleportPoints;

        private float _originalTimeScale;

        public override void Apply(EffectContext context) {
            throw new System.NotImplementedException();
        }

        public override void OnStart(EffectContext context) {
            if (teleportPoints.Length == 0) return;

            context.Target.transform.position = teleportPoints[Random.Range(0, teleportPoints.Length)].position;
        }

        public override void OnUpdate(EffectContext context, float deltaTime) { }

        public override void OnEnd(EffectContext context) { }
    }
}

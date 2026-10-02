using UnityEngine;

namespace PlayerEffects.Debuffs {
    public class Enrager : StatusEffect {
        [SerializeField] private GameTimer timer;
        [SerializeField] private float timeScale = 2f;

        private float _originalTimeScale;

        public override void Apply(EffectContext context) {
            throw new System.NotImplementedException();
        }

        public override void OnStart(EffectContext context) {
            _originalTimeScale = timer.timeScale;
            timer.timeScale = timeScale;
        }

        public override void OnUpdate(EffectContext context, float deltaTime) { }

        public override void OnEnd(EffectContext context) {
            timer.timeScale = _originalTimeScale;
        }
    }
}

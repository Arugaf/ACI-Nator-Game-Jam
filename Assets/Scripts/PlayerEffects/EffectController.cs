using System.Collections.Generic;
using UnityEngine;

namespace PlayerEffects {
    public class EffectController : MonoBehaviour {
        private readonly List<ActiveEffect> _activeEffects = new();

        public void AddEffect(StatusEffect effect, GameObject source) {
            var context = new EffectContext(source, gameObject);

            var activeEffect = new ActiveEffect(effect, source, gameObject);

            activeEffect.Definition.OnStart(context);

            _activeEffects.Add(activeEffect);
        }

        private void Update() {
            for (var i = _activeEffects.Count - 1; i >= 0; i--) {
                var effect = _activeEffects[i];

                var context = new EffectContext(
                    effect.Source,
                    gameObject
                );

                effect.Definition.OnUpdate(
                    context,
                    Time.deltaTime
                );

                if (!effect.Update(Time.deltaTime)) continue;
                effect.Definition.OnEnd(context);
                _activeEffects.RemoveAt(i);
            }
        }
    }
}

using UnityEngine;

namespace PlayerEffects {
    public class ActiveEffect {
        public StatusEffect Definition { get; }

        public GameObject Source { get; }
        public GameObject Target { get; }

        public float RemainingTime { get; private set; }

        public ActiveEffect(StatusEffect definition, GameObject source, GameObject target) {
            Definition = definition;
            Source = source;
            Target = target;

            RemainingTime = definition.Duration;
        }

        public bool Update(float deltaTime) {
            RemainingTime -= deltaTime;

            return RemainingTime <= 0f;
        }
    }
}

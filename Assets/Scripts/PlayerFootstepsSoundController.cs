using UnityEngine;

public class PlayerFootstepsSoundController : MonoBehaviour {
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] footstepClips;
    [SerializeField] private float stepInterval = 0.4f;

    private Rigidbody2D _rb2D;
    private float _stepTimer;

    private void Start() {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        var isMoving = _rb2D.linearVelocity.magnitude > 0.1f;

        if (isMoving) {
            _stepTimer -= Time.deltaTime;

            if (!(_stepTimer <= 0f)) return;

            PlayRandomFootstep();
            _stepTimer = stepInterval;
        } else {
            _stepTimer = 0f;
        }
    }

    private void PlayRandomFootstep() {
        if (footstepClips.Length == 0) return;

        var index = Random.Range(0, footstepClips.Length);
        var clip = footstepClips[index];

        audioSource.pitch = Random.Range(0.9f, 1.1f);

        audioSource.PlayOneShot(clip);
    }
}

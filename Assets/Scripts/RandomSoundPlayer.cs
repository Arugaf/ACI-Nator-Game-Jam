using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomSoundPlayer : MonoBehaviour {
    [SerializeField] private AudioClip[] audioClips;

    private AudioSource _audioSource;
    private int _lastClipIndex = -1;

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = false;
    }

    private void Update() {
        if (!_audioSource.isPlaying && audioClips.Length > 0) {
            PlayRandomClip();
        }
    }

    public void PlayRandomClip() {
        if (audioClips.Length == 0) return;

        var randomIndex = GetUniqueRandomIndex();
        _audioSource.clip = audioClips[randomIndex];
        _audioSource.Play();
    }

    private int GetUniqueRandomIndex() {
        if (audioClips.Length <= 1) return 0;

        var newIndex = Random.Range(0, audioClips.Length);
        while (newIndex == _lastClipIndex) {
            newIndex = Random.Range(0, audioClips.Length);
        }

        _lastClipIndex = newIndex;
        return newIndex;
    }
}
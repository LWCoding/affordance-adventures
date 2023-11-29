using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundEffect
{
    DOOR_UNLOCK = 0, FIRE_SIZZLE
}

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    [Header("Audio Assignments")]
    [SerializeField] private AudioClip _doorUnlockSFX;
    [SerializeField] private AudioClip _fireSizzleSFX;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(SoundEffect effect)
    {
        switch (effect)
        {
            case SoundEffect.DOOR_UNLOCK:
                _audioSource.PlayOneShot(_doorUnlockSFX, 2f);
                break;
            case SoundEffect.FIRE_SIZZLE:
                _audioSource.PlayOneShot(_fireSizzleSFX, 0.7f);
                break;
        }
    }

}

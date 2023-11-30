using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ProximityDingHandler : MonoBehaviour
{

    [Header("Audio Assignments")]
    [SerializeField] private AudioClip _proximitySFX;
    [Range(0, 2)]
    [SerializeField] private float _sfxVolume;

    private AudioSource _audioSource;
    private float _timeBeforeLastDing;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _timeBeforeLastDing = 0;    
    }

    private void Update()
    {
        _timeBeforeLastDing += Time.deltaTime;
        float distToMouse = GetDistanceToMouse();
        distToMouse = Mathf.Lerp(0.05f, 1f, distToMouse / 5);
        if (_timeBeforeLastDing > distToMouse)
        {
            _audioSource.PlayOneShot(_proximitySFX, _sfxVolume);
            _timeBeforeLastDing = 0;
        }
    }

    private float GetDistanceToMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return Vector2.Distance(transform.position, mousePos);
    }

}

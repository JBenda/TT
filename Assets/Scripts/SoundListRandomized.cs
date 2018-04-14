using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script allows a list of audioClips to be played within a prederfined pitch range.
    */
public class SoundListRandomized : MonoBehaviour {

    public float minimumPitch,
                 maximumPitch;
    public List<AudioClip> _audioList;

    private AudioSource _audioSource;
    private EventManager _eventManager;

    private void OnEnable() {
        _eventManager = FindObjectOfType<EventManager>();
        _eventManager.OnCallRandomSound += new OnCallRandomSoundEventHandler(OnCallRandomSound);
    }

    private void OnDisable() {
        _eventManager.OnCallRandomSound -= new OnCallRandomSoundEventHandler(OnCallRandomSound);
    }

    void Start () {
        _audioSource = GetComponent<AudioSource>();
	}

	void OnCallRandomSound () {
		_audioSource.PlayOneShot(_audioList[Random.Range(0, _audioList.Count-1)]);
    }
}

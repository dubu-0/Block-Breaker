using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSFX : MonoBehaviour
{
	[Header("Pitching parameters")]
	[SerializeField] float minPitch;
	[SerializeField] float maxPitch;

	// [Header("Sounds when ball hit something")]
	// [SerializeField] AudioClip[] hitSounds;

	AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		audioSource.pitch = Random.Range(minPitch, maxPitch);
		audioSource.Play();
		//audio.PlayOneShot(hitSounds[Random.Range(0, hitSounds.Length)]);
	}
}

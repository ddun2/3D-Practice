using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicZone : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeTime;
    public float maxVolume;
    private float targetVolume;

    void Start()
    {
        targetVolume = 0.0f;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = targetVolume;
        audioSource.Play();
    }

    void Update()
    {
        if(!Mathf.Approximately(audioSource.volume, targetVolume)) // Approximately() : 근사값 범위에서 같은 값으로 취급해줌
        {
            audioSource.volume = Mathf.MoveTowards(audioSource.volume, targetVolume, (maxVolume / fadeTime) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetVolume = maxVolume;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetVolume = 0.0f;
        }
    }
}

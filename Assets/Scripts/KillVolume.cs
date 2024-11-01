using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class KillVolume : MonoBehaviour
{
    [SerializeField] private string _killText = "Wow, you actually did it!";
    [SerializeField] private AudioSource _killSoundPrefab;
    [SerializeField] private AudioSource _killSoundPrefab2;
    [SerializeField] private ParticleSystem _killParticlePrefab;

    private UIController _uiController;

    private void Awake()
    {
        _uiController = FindObjectOfType<UIController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CarController carController = other.attachedRigidbody.gameObject.GetComponent<CarController>();
        if(carController != null)
        {

            if (_killParticlePrefab != null)
            {
                ParticleSystem newParticle = Instantiate(_killParticlePrefab, other.transform.position, Quaternion.identity);
                newParticle.Play();
            }

            if (_killSoundPrefab != null)
            {
                SoundPlayer.Instance.PlaySFX(_killSoundPrefab, other.transform.position);
                SoundPlayer.Instance.PlaySFX(_killSoundPrefab2, other.transform.position);
            }

            carController.Die();
        }
    }
}

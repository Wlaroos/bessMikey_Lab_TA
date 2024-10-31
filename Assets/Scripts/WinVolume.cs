using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinVolume : MonoBehaviour
{
    [SerializeField] private string _winText = "Wow, you actually did it!";
    [SerializeField] private AudioSource _winSoundPrefab;
    [SerializeField] private ParticleSystem _winParticlePrefab;

    private UIController _uiController;

    private void Awake()
    {
        _uiController = FindObjectOfType<UIController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);

        if (_uiController != null)
        {
            _uiController.ShowWinText(_winText);
        }

        if (_winParticlePrefab != null)
        {
            ParticleSystem newParticle = Instantiate(_winParticlePrefab, other.transform.position, Quaternion.identity);
            newParticle.Play();
        }

        if (_winSoundPrefab != null)
        {
            SoundPlayer.Instance.PlaySFX(_winSoundPrefab, other.transform.position);
        }
    }
}

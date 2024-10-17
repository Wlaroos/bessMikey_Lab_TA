using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVolume : MonoBehaviour
{
    [SerializeField] private string _killText = "Wow, you actually did it!";
    [SerializeField] private AudioSource _killSoundPrefab;

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
            _uiController.ShowWinText(_killText);
        }

        if (_killSoundPrefab != null)
        {
            SoundPlayer.Instance.PlaySFX(_killSoundPrefab, transform.position);
        }
    }
}

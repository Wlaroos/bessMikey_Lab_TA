using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
        CarController carController = other.attachedRigidbody.gameObject.GetComponent<CarController>();
        if(carController != null)
        {
            carController.Die();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinVolume : MonoBehaviour
{
    [SerializeField] private string _winText = "Wow, you actually did it!";
    [SerializeField] private AudioSource _winSoundPrefab;

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

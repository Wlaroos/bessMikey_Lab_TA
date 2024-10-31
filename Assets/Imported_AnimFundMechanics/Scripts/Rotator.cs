using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] 
    private Vector3 rotateForce = new Vector3(0, 1, 0);
    [SerializeField]
    private float rotateSpeed = 100;

    [SerializeField] private AnimationCurve _bobCurve;

    private Vector3 _initPos;

    private void Awake()
    {
        _initPos = transform.position;
    }


    void Update()
    {
        // rotate this object each frame
        this.transform.Rotate(rotateForce * rotateSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, _initPos.y + _bobCurve.Evaluate((Time.time % _bobCurve.length)), transform.position.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Transform _pointA;
    [SerializeField] Transform _pointB;
    [SerializeField] float _duration;
    [SerializeField] float _radius = .5f;

    public float Radius {get => _radius;}

    float _t;

    private void FixedUpdate() {
        _t = Mathf.Repeat(Time.time,_duration)/_duration;
        transform.position = Vector3.Lerp(_pointA.position,_pointB.position,_t);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] Transform _G1;
    [SerializeField] Transform _G2;
    [SerializeField] Transform _G3;

    public Transform G1 { get => _G1;}
    public Transform G2 { get => _G2;}
    public Transform G3 { get => _G3;}

    private void OnDrawGizmos() {
        Gizmos.DrawLine(G1.position,G2.position);
        Gizmos.DrawLine(G2.position, G3.position);
    }
}   

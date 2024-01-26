using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _maxDist;
    [SerializeField] float _speed = 1;
    float _angle = 0.5f; // Angle en demi-Tours (en fait en pourcentage de l'angle max)
    float _dist = 0; //Pourcentage de distance par rapport a la distance max

    public float Angle { get => _angle; set => _angle = value; }
    public float Dist { get => _dist; set => _dist = value; }

    private void FixedUpdate() {
        //Passage de coordonées polaire à cartésienne
        float x = _maxDist*Dist*Mathf.Cos(Angle*Mathf.PI);
        float y = _maxDist*Dist*Mathf.Sin(Angle*Mathf.PI);

        //translation au niveau du joueur
        transform.position = _player.position + new Vector3(x,y,0);
    }

    private void Update() {
        if(Input.GetKey(KeyCode.UpArrow)){
            Dist = Mathf.Min(Dist+_speed*Time.deltaTime,1f);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            Dist = Mathf.Max(Dist-_speed*Time.deltaTime,0f);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            Angle = Mathf.Min(Angle+_speed*Time.deltaTime,1f);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            Angle = Mathf.Max(Angle-_speed*Time.deltaTime,0f);
        }
    }
}

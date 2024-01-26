using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _lifetime;
    [SerializeField] float _maxSpeed;
    [SerializeField] float _radius = .5f;
    [SerializeField] float _wind = 4f;

    float _gravity = 9.81f;
    public Vector2 Speed {get; set;}
    public float MaxSpeed { get => _maxSpeed; }
    public Target Target {get; set;}
    public Ground Ground {get; set;}

    private void Awake() {
        Destroy(gameObject,_lifetime); 
    }

    private void FixedUpdate() {
        Vector2 A = new Vector2(_wind, -_gravity); //PFD

        Speed += A*Time.fixedDeltaTime;//Premiere intégration discrete

        transform.position += new Vector3(Speed.x, Speed.y, 0f)*Time.fixedDeltaTime; // Seconde intégration discrete
        
        CollideTarget();
        CollideGround();
    }

    private void CollideTarget(){
        float distTarget = (Target.transform.position - transform.position).magnitude;
        if(distTarget <= _radius + Target.Radius){
            Debug.Log("Touché !");
            Destroy(gameObject);
        }
    }

    private void CollideGround(){

        //Les Edges
        Vector2 v1 = Ground.G2.position - Ground.G1.position;
        Vector2 v2 = Ground.G3.position - Ground.G2.position;

        //Position dans le referentiel des vertices
        Vector2 pos1 = transform.position - Ground.G1.position;
        Vector2 pos2 = transform.position - Ground.G2.position;

        //Normales
        Vector2 n1 = new Vector2(-v1.y,v1.x);
        Vector2 n2 = new Vector2(-v2.y, v2.x);

        //Produit Scalaire avec chacun pour savoir de quel coté est l'objet
        if(Vector2.Dot(pos1,n1)<= 0 && Vector2.Dot(pos2,n2)<=0){
            Debug.Log("Au Sol");
            Destroy(gameObject);
        }
    }
}

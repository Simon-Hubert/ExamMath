using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Target _target;
    [SerializeField] Aim _reticule;
    [SerializeField] GameObject _bullet;
    [SerializeField] Ground _ground;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            Bullet bulletSave = Instantiate(_bullet,transform).GetComponent<Bullet>();
            Vector2 dir = new Vector2(Mathf.Cos(_reticule.Angle*Mathf.PI), Mathf.Sin(_reticule.Angle*Mathf.PI));
            bulletSave.Speed = bulletSave.MaxSpeed*_reticule.Dist*dir;
            bulletSave.Target = _target;
            bulletSave.Ground = _ground;
        }
    }
}

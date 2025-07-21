using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTarget : MonoBehaviour
{

    [SerializeField] private Bullet _bullet;


    public void Shoot(Vector3 targetPosition)
    {
        Instantiate(_bullet, transform.position, transform.rotation);
    }

}

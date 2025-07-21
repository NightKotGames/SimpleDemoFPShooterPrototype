using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] private GameObject _bullet;

    [Space(5), Range(1f, 5f),SerializeField] private float _bulletSpeed;
    [Range(1f, 5f), SerializeField] private float _bulletFlyTime;

    [SerializeField] private Transform _body;

    private void Awake()
    {
      

    }

    private void OnEnable()
    {
        PlayerShoot.PlayerShooting += Shoot;
    }

    private void OnDisable()
    {
        PlayerShoot.PlayerShooting -= Shoot;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.green, 3f);
    }

    private void Shoot()
    {

        Debug.Log($"Shoot:");
        Instantiate(_bullet, transform.position, transform.rotation);
        
        //activeBullet.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, Time.deltaTime * _bulletSpeed);
    }

    private void ReturnTo()
    {

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [Range(1, 100), SerializeField] private float _shootRange;
    [Space(5), SerializeField] private InputControl _inputSystem;
    [SerializeField] private Camera _camera;

    public static event Action<int> EnemyOnTarget = delegate { };
    public static event Action PlayerShooting = delegate { };

    private GameObject _objectOnTarget;
    private Ray _ray;
    private RaycastHit _hit;

    private void Awake()
    {
        _inputSystem = new InputControl();
    }

    private void OnEnable()
    {
        _inputSystem.Enable();
        _inputSystem.Player.Shoot.performed += context => Shoot();
    }
    private void OnDisable()
    {
        _inputSystem.Disable();
        _inputSystem.Player.Shoot.performed -= context => Shoot();
    }

    private void Update()
    {

        _ray = new Ray(transform.position, transform.forward);        
        if (Physics.Raycast(_ray, out _hit, _shootRange))
        {
            _objectOnTarget = _hit.collider.gameObject;
            if(_objectOnTarget.TryGetComponent(out Enemy enemy))
            {
                EnemyOnTarget.Invoke(enemy.NumberEnemy);
                Debug.Log($"{enemy.NumberEnemy}");
            }          

        }
        else
        {
            _objectOnTarget = null;
            EnemyOnTarget.Invoke(-1);
        }

        

    }

    private void Shoot()
    {
        
        //Vector3 target = new Vector3(_ray.origin.x, _ray.origin.y, _ray.origin.z) + transform.forward;
        PlayerShooting.Invoke();

    }



}

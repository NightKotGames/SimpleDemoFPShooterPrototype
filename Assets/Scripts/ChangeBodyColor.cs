using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy), typeof(MeshRenderer))]
public class ChangeBodyColor : MonoBehaviour
{
       
    [SerializeField] private Material _mainColorMaterial;
    [SerializeField] private Material _atGunpointMaterial;

    private Enemy _enemyBody;
    private MeshRenderer _mainMeshRenderer;
    private int _mainNumberEnemy;
    private bool _onTarget;

    private void Awake()
    {
        _enemyBody = GetComponent<Enemy>();
        _mainMeshRenderer = GetComponent<MeshRenderer>();
        _mainNumberEnemy = _enemyBody.NumberEnemy;
    }

    private void OnEnable()
    {
        PlayerShoot.EnemyOnTarget += ChangeColor;  
    }
    private void OnDisable()
    {
        PlayerShoot.EnemyOnTarget -= ChangeColor;
    }

    private void ChangeColor(int numberEnemy)
    {
        if(numberEnemy == _mainNumberEnemy)
        {
            if (_mainMeshRenderer.material != _atGunpointMaterial)
            {
                _mainMeshRenderer.material = _atGunpointMaterial;
            }
            
        }
        else if(numberEnemy == -1)
        {
            if(_mainMeshRenderer.material != _mainColorMaterial)
            {
                _mainMeshRenderer.material = _mainColorMaterial;
            }
            
        }
    }


}

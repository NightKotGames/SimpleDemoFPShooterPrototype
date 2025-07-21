using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ScanArea : MonoBehaviour
{

    [Range(.1f, 50f), SerializeField] private float _scanRadius;
    [Space(10), SerializeField] private AttackTarget _attackTarget;

    [SerializeField] private bool _alarm;

    private GameObject _playerObj;

    private SphereCollider _scanArea;


    private void Awake()
    {
        _scanArea = GetComponent<SphereCollider>();        
        _scanArea.isTrigger = true;
        _scanArea.radius = _scanRadius;

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.TryGetComponent(out PlayerBody player))
        {
            _alarm = true;
            _playerObj = player.gameObject;
        }
    }

    private void OnTriggerStay(Collider col)
    {

        if (_alarm == true & _playerObj != null)
        {

            Vector3 targetDirection = (_playerObj.transform.position - transform.position).normalized;
            float targetDistance = Vector3.Distance(transform.position, _playerObj.transform.position);
            
            Ray ray = new Ray(transform.position, targetDirection);
            Physics.Raycast(ray, out RaycastHit hit);
            try
            {
                if (hit.collider.gameObject == _playerObj)
                {
                    Debug.DrawRay(ray.origin, ray.direction * targetDistance, Color.red);
                }
            }
            catch(Exception err)
            {
                Debug.Log($"{err}");
            }
           
            //_attackTarget.Shoot(_scanList[0].transform.position);
            
        
        
        }
    
    }


    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.TryGetComponent(out PlayerBody player))
        {
            _alarm = false;
            _playerObj = null;
        }

    }

}


        
 
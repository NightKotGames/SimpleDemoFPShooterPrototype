using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    
    [Range(1f, 15f), SerializeField] private float _damage;
    [Range(1f, 10f), SerializeField] private float _startSpeed;    
    [Range(1f, 15f), SerializeField] private float _timeToDestruct;

    [Space(10), SerializeField] private Gun _gun;
    [Space(10), SerializeField] private ParticleSystem _particleHit;

    
    public static event Action<float> BulletTargetDamage = delegate { };

    private Vector3 _previousStep;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        
        Invoke("ReturnToGun", _timeToDestruct);
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.TransformDirection(Vector3.forward * _startSpeed);
        _previousStep = transform.position;

    }

    private void FixedUpdate()
    {
       Quaternion currentStep = gameObject.transform.rotation;
       transform.LookAt(_previousStep, transform.forward);

        Ray ray = new Ray(transform.position, _previousStep);
        RaycastHit hit = new RaycastHit();
        float distance = Vector3.Distance(_previousStep, transform.position);

        if(distance == 0.0f)
        {
            distance = 1 - 05f;
        }

        float raydistance = distance * .9999f;

        transform.rotation = currentStep;
        _previousStep = gameObject.transform.position;

        ///<summary>
        /// RayCast
        ///</summary>>

        Debug.DrawRay(_previousStep, transform.TransformDirection(Vector3.back) * raydistance);
        
        if(Physics.Raycast(ray, out hit, raydistance))
        {
            if (_particleHit != null)
            {
                _particleHit.Play();
                BulletTargetDamage.Invoke(_damage);
            }
            
        }

        ///<summary>
        /// RayCast
        ///</summary>>

    }

    private void ReturnToGun()
    {
        Destroy(gameObject);
    }
}
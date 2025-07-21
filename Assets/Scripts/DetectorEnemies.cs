using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*[RequireComponent(typeof())]*/
public class DetectorEnemies : MonoBehaviour
{
    private SphereCollider _mainColliderDetector;

    public static event Action<GameObject> SetColor = delegate { };

    private void Awake()
    {
        _mainColliderDetector = GetComponent<SphereCollider>();
        _mainColliderDetector.isTrigger = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.TryGetComponent(out ChangeBodyColor bodyColor))
        {
            SetColor.Invoke(col.gameObject);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.TryGetComponent(out ChangeBodyColor bodyColor))
        {
            SetColor.Invoke(col.gameObject);
        }
    }


}

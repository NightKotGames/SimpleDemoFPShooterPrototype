using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Min(0), SerializeField] private int _numberEnemy;
    public int NumberEnemy
    {
        get { return _numberEnemy; }
        protected set { }
    }

    [Range(1, 10), SerializeField] private float _delayTimeBetweenMovements;
    [Space(5), SerializeField] private NavMeshAgent _enemyNavMesh;
    [Space(2), SerializeField] private List<Transform> _destinationPoint;
    

    private void OnEnable()
    {
        MoveToDestinationPoint(_delayTimeBetweenMovements);
    }


    private void MoveToDestinationPoint(float time)
    {

        if(_enemyNavMesh == null || _destinationPoint.Count == 0)
        {
            return;
        }

        StartCoroutine(StartEnemy());
        IEnumerator StartEnemy()
        {

            yield return new WaitForSeconds(time);
            Transform currentDestination = _destinationPoint[Random.Range(0, _destinationPoint.Count)];
            _enemyNavMesh.SetDestination(currentDestination.position);
            MoveToDestinationPoint(_delayTimeBetweenMovements);
        }
    }


}

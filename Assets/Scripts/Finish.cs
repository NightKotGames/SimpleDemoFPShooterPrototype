using System;
using UnityEngine;

public class Finish : MonoBehaviour
{

    [SerializeField] private GameState.State _stateGame;

    public static event Action<string> FinishEvent = delegate { }; 
       
    private void OnTriggerEnter(Collider col)
    {
       if(col.gameObject.TryGetComponent(out PlayerMovement player))
       {
            FinishEvent.Invoke($"{_stateGame}");
       }
    }

}

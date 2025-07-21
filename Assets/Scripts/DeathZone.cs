using System;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    [SerializeField] private GameState.State _stateGame;

    public static event Action<string> PlayerIsDeaD = delegate { };

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.TryGetComponent(out PlayerBody player))
        {
            PlayerIsDeaD.Invoke($"{_stateGame}");
        }
    }


}

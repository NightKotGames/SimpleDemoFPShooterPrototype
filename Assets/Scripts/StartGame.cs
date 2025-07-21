using System;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    [SerializeField] private GameState.State _startState;

    [Space(5), SerializeField] private Transform _startPosition;
    [SerializeField] private PlayerMovement _player;


    private Transform _playerTransform;

    public static event Action<string> GameStarted = delegate { };

    
    private void Start()
    {
        _playerTransform = _player.GetComponent<Transform>();
        GameStart();
    }

    private void OnEnable()
    {
        NewGame.StartEvent += GameStart;
    }
    private void OnDisable()
    {
        NewGame.StartEvent -= GameStart;
    }

    private void GameStart()
    {
        _player.enabled = false;
        _playerTransform.position = _startPosition.position;
        _player.enabled = true;
        GameStarted.Invoke($"{_startState}");
    }
}

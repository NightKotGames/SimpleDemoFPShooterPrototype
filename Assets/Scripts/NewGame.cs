using System;
using UnityEngine;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{

    [SerializeField] private Button _newGameButton;

    public static event Action StartEvent = delegate { };

    private void OnEnable()
    {
        _newGameButton.onClick.AddListener(()=> 
        {
            StartEvent.Invoke();

        });
    }


}

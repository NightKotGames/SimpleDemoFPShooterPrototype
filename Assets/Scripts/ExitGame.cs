using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(() => 
        {
            ExitOfGame();       
        });
    }

    private void ExitOfGame()
    {
        Application.Quit();
    }

}

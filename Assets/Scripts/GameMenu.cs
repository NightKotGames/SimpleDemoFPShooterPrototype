using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private Canvas _menuPanel;

    [Space(5), SerializeField] private TextMeshProUGUI _statusText;
    [SerializeField] private Button _exitButton;

    private InputControl _inputControl;
    private void Awake()
    {
        _inputControl = new InputControl();
        _menuPanel.gameObject.SetActive(false);
        _exitButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _inputControl.Enable();
        _inputControl.Player.ESC.performed += context => MenuEnabler();
        NewGame.StartEvent += MenuEnabler;
        DeathZone.PlayerIsDeaD += ShowGameStatus;
        Finish.FinishEvent += ShowGameStatus;
    }
    private void OnDisable()
    {
        _inputControl.Disable();
        _inputControl.Player.ESC.performed += context => MenuEnabler();
        NewGame.StartEvent -= MenuEnabler;
        DeathZone.PlayerIsDeaD -= ShowGameStatus;
        Finish.FinishEvent -= ShowGameStatus;
    }

    #region MenuOn/Off

    private void MenuEnabler()
    {
        _statusText.text = "";
        if (_menuPanel.gameObject.activeSelf == false)
        {
            Time.timeScale = 0;            
            _menuPanel.gameObject.SetActive(true);
            _exitButton.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if(_menuPanel.gameObject.activeSelf == true)
        {
            Time.timeScale = 1;
            _menuPanel.gameObject.SetActive(false);
            _exitButton.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;            
        }
    }

    #endregion
    
    private void ShowGameStatus(string state)
    {

        MenuEnabler();
        _statusText.text = state;
    }
}
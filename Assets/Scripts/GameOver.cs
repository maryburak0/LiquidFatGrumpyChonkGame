using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public bool _wasRestartButtonClicked = false;
    public bool _wasBackToMenuButtonClicked = false;

    public Button RestartButton;
    public Button BackToMenuButton;

    public AudioManager AudioManager;

    private void Awake()
    {
        RestartButton.onClick.AddListener(OnRestartButtonClicked);

        BackToMenuButton.onClick.AddListener(OnBackToMenuButtonClicked);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.SceneIndex = 1;

        if (_wasRestartButtonClicked)
        {
            SceneManager.LoadScene(3);
        }

        if (_wasBackToMenuButtonClicked)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnRestartButtonClicked()
    {
        _wasRestartButtonClicked = true;
    }

    private void OnBackToMenuButtonClicked()
    {
        _wasBackToMenuButtonClicked = true;
    }
}

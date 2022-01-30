using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private Button _resume;
    private Button _restart;
    private Button _exitToMainMenu;
    private Button _exitToDekstop;
    private bool _isPause = false;
    

    void Start()
    {
        gameObject.SetActive(false);
        _isPause = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isPause)
        {
            gameObject.SetActive(true);
            _isPause = true;
            Time.timeScale = 0;
        }
    }

    private void OnEnable()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        _resume = rootVisualElement.Q<Button>("Resume");
        _restart = rootVisualElement.Q<Button>("Restart");
        _exitToMainMenu = rootVisualElement.Q<Button>("ExitToMainMenu");
        _exitToDekstop = rootVisualElement.Q<Button>("ExitToDekstop");

        _resume.clicked += Resume;
        _restart.clicked += Restart;
        _exitToMainMenu.clicked += ExitToMainMenu;
        _exitToDekstop.clicked += ExitToDekstop;
    }

    private void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        _isPause = false;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ExitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void ExitToDekstop()
    {
        Application.Quit();
    }


}

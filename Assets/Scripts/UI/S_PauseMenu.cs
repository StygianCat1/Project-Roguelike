using UnityEngine;
using UnityEngine.SceneManagement;

public class S_PauseMenu : MonoBehaviour
{
    public string mainMenuSceneToLoadName;
    
    public GameObject verificationMenu;
    private S_PauseMenuVerifiication _verificationMenuScript;

    private void Awake()
    {
        _verificationMenuScript = verificationMenu.GetComponent<S_PauseMenuVerifiication>();
        Time.timeScale = 0;
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void GoBackToMainMenu()
    {
        verificationMenu.SetActive(true);   
        _verificationMenuScript.tryClosingGame = false;
    }

    public void QuitGame()
    {
        verificationMenu.SetActive(true);
        _verificationMenuScript.SceneToLoadName = mainMenuSceneToLoadName;
        _verificationMenuScript.tryClosingGame = true;
    }
}

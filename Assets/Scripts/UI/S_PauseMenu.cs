using UnityEngine;
using UnityEngine.SceneManagement;

public class S_PauseMenu : MonoBehaviour
{
    public GameObject verificationMenu;
    private S_PauseMenuVerification _verificationMenuScript;

    private void Awake()
    {
        Time.timeScale = 0;
        _verificationMenuScript = verificationMenu.GetComponent<S_PauseMenuVerification>();
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
        _verificationMenuScript.tryClosingGame = true;
    }
}

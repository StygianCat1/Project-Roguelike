using UnityEngine;
using UnityEngine.SceneManagement;

public class S_PauseMenuVerification : MonoBehaviour
{

    [HideInInspector] public bool tryClosingGame;
    public string SceneToLoadName;
        
    public void CloseWindows()
    {
        gameObject.SetActive(false);
    }

    public void Accept()
    {
        if (tryClosingGame)
        {
            Application.Quit();
            return;
        }
        SceneManager.LoadScene(SceneToLoadName);
    }
}

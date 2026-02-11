using UnityEngine;
using UnityEngine.SceneManagement;

public class S_PauseMenuVerifiication : MonoBehaviour
{

    [HideInInspector] public bool tryClosingGame;
    [HideInInspector] public string SceneToLoadName;
        
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

using UnityEngine;
using UnityEngine.SceneManagement;

public class S_MainMenuScript : MonoBehaviour
{
    public GameObject OptionsMenu;
    [SerializeField] private string _hubSceneName;
    
    public void LaunchGame()
    {
        SceneManager.LoadScene(_hubSceneName);
    }

    public void OpenOptionsMenu()
    {
        OptionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void DoExitGame()
    {
        Application.Quit();
    }
}

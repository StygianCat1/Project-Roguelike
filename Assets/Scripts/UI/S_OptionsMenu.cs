using UnityEngine;

public class S_OptionsMenu : MonoBehaviour
{
    public GameObject MainMenu;

    public void QuitOptionsMenu()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}

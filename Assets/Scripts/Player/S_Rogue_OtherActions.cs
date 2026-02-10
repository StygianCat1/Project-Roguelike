using UnityEngine;

public class S_Rogue_OtherActions : MonoBehaviour
{
    private S_Rogue_Inputs _inputsManager;
    [SerializeField] private  GameObject _pauseMenuRef;
    private GameObject _pauseMenu;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _inputsManager = GetComponent<S_Rogue_Inputs>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_inputsManager.pause)
        {
            if (_pauseMenu == null)
            {
                _pauseMenu = Instantiate(_pauseMenuRef);
            }
        }
    }
}

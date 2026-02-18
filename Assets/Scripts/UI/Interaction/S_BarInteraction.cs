using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class S_BarInteraction : MonoBehaviour
{
    private GameObject _player;

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private int _moneyUsedToBar;
    [SerializeField] private int _healthGained;

    private void Start()
    {
        Time.timeScale = 0f;
        _player = GameObject.FindGameObjectWithTag("MainCharacter");
        _text.text = "Gain " + _healthGained.ToString() + " health by using " + _moneyUsedToBar.ToString() + " coins";
    }

    public void UseBar()
    {
        if (_player.GetComponent<S_Resources>()._resourcesInGame >= _moneyUsedToBar)
        {
            _player.GetComponent<S_HP_Component>().Heal(_healthGained);
            _player.GetComponent<S_Resources>()._resourcesInGame -= _moneyUsedToBar;
            
        }
    }

    public void QuitUi()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}

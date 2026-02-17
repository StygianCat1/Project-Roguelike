using UnityEngine;
using UnityEngine.TextCore.Text;

public class S_BarInteraction : MonoBehaviour
{
    private GameObject _player;

    [SerializeField] private int _moneyUsedToBar;
    [SerializeField] private int _healthGained;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("MainCharacter");
    }

    public void UseBar()
    {
        if (_player.GetComponent<S_Resources>()._resourcesInGame >= _moneyUsedToBar)
        {
            _player.GetComponent<S_HP_Component>().Heal(_healthGained);
        }
    }

    public void QuitUi()
    {
        Destroy(gameObject);
    }
}

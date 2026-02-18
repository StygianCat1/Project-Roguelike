using UnityEngine;

public class S_VendingMachineInteraction : MonoBehaviour
{
    private GameObject _player;
    private S_Resources _playerResources;

    [SerializeField] private int _moneyForFood;
    [SerializeField] private int _healthGainedByFood;

    [SerializeField] private int _moneyForDrink;
    [SerializeField] private float _speedBoost;

    [SerializeField] private int _moneyForBullets;
    [SerializeField] private int _bulletsGained;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Time.timeScale = 0f;
        _player = GameObject.FindGameObjectWithTag("MainCharacter");
        _playerResources = _player.GetComponent<S_Resources>();
    }

    public void Food()
    {
        if (_playerResources._resourcesInGame >= _moneyForFood)
        {
            _player.GetComponent<S_HP_Component>().Heal(_healthGainedByFood);
            _playerResources._resourcesInGame -= _moneyForFood;
        }
    }

    public void EnergicDrink()
    {
        if (_playerResources._resourcesInGame >= _moneyForDrink)
        {
            _player.GetComponent<S_Rogue_MovementComponent>()._movementSpeed += _speedBoost;
            _playerResources._resourcesInGame -= _moneyForDrink;
        }
    }

    public void Bullets()
    {
        if (_playerResources._resourcesInGame >= _moneyForBullets)
        {
            _player.GetComponent<S_Rogue_Combat>().gunAmmunitions += _bulletsGained;
            _playerResources._resourcesInGame -= _moneyForBullets;
        }
    }
    
    
    public void QuitUi()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}

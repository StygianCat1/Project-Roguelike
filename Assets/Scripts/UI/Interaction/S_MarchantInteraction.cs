using UnityEngine;

public class S_MarchantInteraction : MonoBehaviour
{
    private GameObject _player;
    private S_Rogue_Bonus _bonus;
    private S_Resources _resources;

    [SerializeField] private int _basicPrice1 = 10;
    [SerializeField] private int _basicPrice2 = 20;
    [SerializeField] private int _basicPrice3 = 30;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Time.timeScale = 0f;
        _player = GameObject.FindGameObjectWithTag("MainCharacter");
        _bonus = _player.GetComponent<S_Rogue_Bonus>();
        _resources = _player.GetComponent<S_Resources>();
    }

    public void AddAvidity()
    {
        if (_bonus.avidityUpgradeLevel == 3)
        {
            return;
        }

        if (_resources._resourcesOutGame >= _basicPrice1 && _bonus.avidityUpgradeLevel == 0)
        {
            _bonus.avidityUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.avidityUpgradeLevel);
            Debug.Log("Avidity added");
        }

        if (_resources._resourcesOutGame >= _basicPrice2 && _bonus.avidityUpgradeLevel == 1)
        {
            _bonus.avidityUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.avidityUpgradeLevel);
            Debug.Log("Avidity added");
        }

        if (_resources._resourcesOutGame >= _basicPrice3 && _bonus.avidityUpgradeLevel == 2)
        {
            _bonus.avidityUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.avidityUpgradeLevel);
            Debug.Log("Avidity added");
        }
    }
    
    public void AddAngryKaori()
    {
        if (_bonus.angryKaoriUpgradeLevel == 3)
        {
            return;
        }

        if (_resources._resourcesOutGame >= _basicPrice1 && _bonus.angryKaoriUpgradeLevel == 0)
        {
            _bonus.angryKaoriUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.angryKaoriUpgradeLevel);
            Debug.Log ("Angry Kaori added");
        }

        if (_resources._resourcesOutGame >= _basicPrice2 && _bonus.angryKaoriUpgradeLevel == 1)
        {
            _bonus.angryKaoriUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.angryKaoriUpgradeLevel);
            Debug.Log ("Angry Kaori added");
        }

        if (_resources._resourcesOutGame >= _basicPrice3 && _bonus.angryKaoriUpgradeLevel == 2)
        {
            _bonus.angryKaoriUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.angryKaoriUpgradeLevel);
            Debug.Log ("Angry Kaori added");
        }
    }
    
    public void AddLuckyGambler()
    {
        if (_bonus.luckyGamblerUpgradeLevel == 3)
        {
            return;
        }

        if (_resources._resourcesOutGame >= _basicPrice1 && _bonus.luckyGamblerUpgradeLevel == 0)
        {
            _bonus.luckyGamblerUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.luckyGamblerUpgradeLevel);
            Debug.Log("Lucky Gambler added");
        }

        if (_resources._resourcesOutGame >= _basicPrice2 && _bonus.luckyGamblerUpgradeLevel == 1)
        {
            _bonus.luckyGamblerUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.luckyGamblerUpgradeLevel);
            Debug.Log("Lucky Gambler added");
        }

        if (_resources._resourcesOutGame >= _basicPrice3 && _bonus.luckyGamblerUpgradeLevel == 2)
        {
            _bonus.luckyGamblerUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.luckyGamblerUpgradeLevel);
            Debug.Log("Lucky Gambler added");
        }
    }
    
    public void AddLuckyShot()
    {
        if (_bonus.luckyShotLevel == 3)
        {
            return;
        }

        if (_resources._resourcesOutGame >= _basicPrice1 && _bonus.luckyShotLevel == 0)
        {
            _bonus.luckyShotLevel += 1;
            _bonus.AvidityLevel(_bonus.luckyShotLevel);
            Debug.Log("Lucky Shot added");
        }

        if (_resources._resourcesOutGame >= _basicPrice2 && _bonus.luckyShotLevel == 1)
        {
            _bonus.luckyShotLevel += 1;
            _bonus.AvidityLevel(_bonus.luckyShotLevel);
            Debug.Log("Lucky Shot added");
        }

        if (_resources._resourcesOutGame >= _basicPrice3 && _bonus.luckyShotLevel == 2)
        {
            _bonus.luckyShotLevel += 1;
            _bonus.AvidityLevel(_bonus.luckyShotLevel);
            Debug.Log("Lucky Shot added");
        }
    }
    
    public void QuitUi()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}

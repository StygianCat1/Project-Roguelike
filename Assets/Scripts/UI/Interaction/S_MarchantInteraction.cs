using UnityEngine;

public class S_MarchantInteraction : MonoBehaviour
{
    private GameObject _player;
    private S_Rogue_Bonus _bonus;
    private S_Resources _resources;

    [SerializeField] private int _basicPrice1 = 10;
    [SerializeField] private int _basicPrice2 = 20;
    [SerializeField] private int _basicPrice3 = 30;
    
    [SerializeField] private GameObject _avidity1; 
    [SerializeField] private GameObject _avidity2; 
    [SerializeField] private GameObject _avidity3;
    [SerializeField] private GameObject _avidityMax;
    
    [SerializeField] private GameObject _angryKaori1; 
    [SerializeField] private GameObject _angryKaori2; 
    [SerializeField] private GameObject _angryKaori3;
    [SerializeField] private GameObject _angryKaorimax;
    
    [SerializeField] private GameObject _luckyGambler1; 
    [SerializeField] private GameObject _luckyGambler2; 
    [SerializeField] private GameObject _luckyGambler3;
    [SerializeField] private GameObject _luckyGamblermax;
    
    [SerializeField] private GameObject _luckyShot1; 
    [SerializeField] private GameObject _luckyShot2; 
    [SerializeField] private GameObject _luckyShot3;
    [SerializeField] private GameObject _luckyShotMax;
    
    
    
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
        Debug.Log(_bonus.avidityUpgradeLevel);
        if (_resources._resourcesOutGame >= _basicPrice1 && _bonus.avidityUpgradeLevel == 0)
        {
            _bonus.avidityUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.avidityUpgradeLevel);
            _avidity1.SetActive(false);
            _avidity2.SetActive(true);
            _resources._resourcesOutGame -= _basicPrice1;
            return;
        }

        if (_resources._resourcesOutGame >= _basicPrice2 && _bonus.avidityUpgradeLevel == 1)
        {
            _bonus.avidityUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.avidityUpgradeLevel);
            _avidity2.SetActive(false);
            _avidity3.SetActive(true);
            _resources._resourcesOutGame -= _basicPrice2;
            return;
        }

        if (_resources._resourcesOutGame >= _basicPrice3 && _bonus.avidityUpgradeLevel == 2)
        {
            _bonus.avidityUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.avidityUpgradeLevel);
            _avidity3.SetActive(false);
            _avidityMax.SetActive(true);
            _resources._resourcesOutGame -= _basicPrice3;
        }
    }
    
    public void AddAngryKaori()
    {
        if (_resources._resourcesOutGame >= _basicPrice1 && _bonus.angryKaoriUpgradeLevel == 0)
        {
            _bonus.angryKaoriUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.angryKaoriUpgradeLevel);
            _angryKaori1.SetActive(false);
            _angryKaori2.SetActive(true);
            _resources._resourcesOutGame -= _basicPrice1;
            return;
        }

        if (_resources._resourcesOutGame >= _basicPrice2 && _bonus.angryKaoriUpgradeLevel == 1)
        {
            _bonus.angryKaoriUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.angryKaoriUpgradeLevel);
            _angryKaori2.SetActive(false);
            _angryKaori3.SetActive(true);
            _resources._resourcesOutGame -= _basicPrice2;
            return;
        }

        if (_resources._resourcesOutGame >= _basicPrice3 && _bonus.angryKaoriUpgradeLevel == 2)
        {
            _bonus.angryKaoriUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.angryKaoriUpgradeLevel);
            _angryKaori3.SetActive(false);
            _angryKaorimax.SetActive(true);
            _resources._resourcesOutGame -= _basicPrice3;
        }
    }
    
    public void AddLuckyGambler()
    {
        if (_resources._resourcesOutGame >= _basicPrice1 && _bonus.luckyGamblerUpgradeLevel == 0)
        {
            _bonus.luckyGamblerUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.luckyGamblerUpgradeLevel);
            _luckyGambler1.SetActive(false);
            _luckyGambler2.SetActive(true);
            _resources._resourcesOutGame -= _basicPrice1;
            return;
        }

        if (_resources._resourcesOutGame >= _basicPrice2 && _bonus.luckyGamblerUpgradeLevel == 1)
        {
            _bonus.luckyGamblerUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.luckyGamblerUpgradeLevel);
            _luckyGambler2.SetActive(false);
            _luckyGambler3.SetActive(true);
            _resources._resourcesOutGame -= _basicPrice2;
            return;
        }

        if (_resources._resourcesOutGame >= _basicPrice3 && _bonus.luckyGamblerUpgradeLevel == 2)
        {
            _bonus.luckyGamblerUpgradeLevel += 1;
            _bonus.AvidityLevel(_bonus.luckyGamblerUpgradeLevel);
            _luckyGambler3.SetActive(false);
            _luckyGamblermax.SetActive(true);
            _resources._resourcesOutGame -= _basicPrice3;
        }
    }
    
    public void AddLuckyShot()
    {
        if (_resources._resourcesOutGame >= _basicPrice1 && _bonus.luckyShotLevel == 0)
        {
            _bonus.luckyShotLevel += 1;
            _bonus.AvidityLevel(_bonus.luckyShotLevel);
            _luckyShot1.SetActive(false);
            _luckyGambler2.SetActive(true);
            _resources._resourcesOutGame -= _basicPrice1;
            return;
        }

        if (_resources._resourcesOutGame >= _basicPrice2 && _bonus.luckyShotLevel == 1)
        {
            _bonus.luckyShotLevel += 1;
            _bonus.AvidityLevel(_bonus.luckyShotLevel);
            _luckyShot2.SetActive(false);
            _luckyShot3.SetActive(true);
            _resources._resourcesOutGame -= _basicPrice2;
            return;
        }

        if (_resources._resourcesOutGame >= _basicPrice3 && _bonus.luckyShotLevel == 2)
        {
            _bonus.luckyShotLevel += 1;
            _bonus.AvidityLevel(_bonus.luckyShotLevel);
            _luckyShot3.SetActive(false);
            _luckyShotMax.SetActive(true);
            _resources._resourcesOutGame -= _basicPrice3;
        }
    }
    
    public void QuitUi()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}

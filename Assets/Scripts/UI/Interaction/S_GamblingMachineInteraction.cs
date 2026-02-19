using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class S_GamblingMachineInteraction : MonoBehaviour
{
    private GameObject _player;

    [SerializeField] private int _moneyToPlay;
    
    [SerializeField] private GameObject _gainCanvasUi;
    
    [SerializeField] private int _healValue;
    [SerializeField] private int _bulletGained;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Time.timeScale = 0f;
        _player = GameObject.FindGameObjectWithTag("MainCharacter");
    }

    public void LetsGoGambling()
    {
        GameObject gainCanvas = new GameObject();

        gainCanvas = Instantiate(_gainCanvasUi);
        
        int randomDrop = Random.Range(0, 100);
        int randomDrop2 = Random.Range(0, 100);
        if (_player.GetComponent<S_Resources>()._resourcesInGame >= _moneyToPlay)
        {
            if (randomDrop <= 60 - _player.GetComponent<S_Rogue_Bonus>().luckMultiplier * 10)
            {
                gainCanvas.GetComponent<S_GamblingGainUi>().imageNothing.SetActive(true);
                gainCanvas.GetComponent<S_GamblingGainUi>().imageHeals.SetActive(false);
                gainCanvas.GetComponent<S_GamblingGainUi>().imageBullets.SetActive(false);
            }
            else
            {
                if (randomDrop2 <= 50)
                {
                    _player.GetComponent<S_HP_Component>().Heal(_healValue * _player.GetComponent<S_Rogue_Bonus>().luckMultiplier);
                    gainCanvas.GetComponent<S_GamblingGainUi>().imageNothing.SetActive(false);
                    gainCanvas.GetComponent<S_GamblingGainUi>().imageHeals.SetActive(true);
                    gainCanvas.GetComponent<S_GamblingGainUi>().imageBullets.SetActive(false);
                }
                else
                {
                    _player.GetComponent<S_Rogue_Combat>().gunAmmunitions += _bulletGained * _player.GetComponent<S_Rogue_Bonus>().luckMultiplier;
                    gainCanvas.GetComponent<S_GamblingGainUi>().imageNothing.SetActive(false);
                    gainCanvas.GetComponent<S_GamblingGainUi>().imageHeals.SetActive(false);
                    gainCanvas.GetComponent<S_GamblingGainUi>().imageBullets.SetActive(true);
                }
            }
        }
    }
    
    public void QuitUi()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}

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
        string gainCanvasUi;
        int randomDrop = Random.Range(0, 100);
        int randomDrop2 = Random.Range(0, 100);
        if (_player.GetComponent<S_Resources>()._resourcesInGame >= _moneyToPlay)
        {
            if (randomDrop < 50)
            {
                gainCanvasUi = "You got nothing";
            }
            else
            {
                if (randomDrop2 <= 40)
                {
                    _player.GetComponent<S_HP_Component>().Heal(_healValue);
                    gainCanvasUi = "You got some heals";
                }
                else if (randomDrop2 <= 80)
                {
                    _player.GetComponent<S_Rogue_Combat>().gunAmmunitions += _bulletGained;
                    gainCanvasUi = "You got some bullets";
                }
                else
                {
                    gainCanvasUi = "You got a perk";
                }
            }
            gainCanvas = Instantiate(_gainCanvasUi);
            gainCanvas.GetComponent<S_GamblingGainUi>()._textToChange.text = gainCanvasUi;
        }
    }


    private void GainPerks()
    {
        
    }
    
    public void QuitUi()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}

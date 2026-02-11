using UnityEngine;

public class S_Rogue_Bonus : MonoBehaviour
{
    [Range(0, 3)] public int perversionUpgradeLevel;
    [Range(0, 3)] public int luckyGamblerUpgradeLevel;
    [Range(0, 3)] public int avidityUpgradeLevel;
    [Range(0, 3)] public int angryKaoriUpgradeLevel;
    public int baseKaoriCooldown;
    
    [Range(0, 3)] public int luckyShotCooldown;
    public int luckyshotRate = 0;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        perversionUpgradeLevel = S_GameManager.perversionUpgradeLevelSave;
        luckyGamblerUpgradeLevel =S_GameManager.luckyGamblerUpgradeLevelSave;
        avidityUpgradeLevel = S_GameManager.avidityUpgradeLevelSave;
        angryKaoriUpgradeLevel = S_GameManager.angryKaoriUpgradeLevelSave;
        luckyShotCooldown = S_GameManager.luckyShotCooldownSave;
        
        //VerifyAllBonuses();
    }
    
    public void VerifyAllBonuses()
    {
        
    }

    private void PerversionLevel()
    {
        
    }
    
    public void SaveAllBonuses()
    {
        S_GameManager.perversionUpgradeLevelSave = perversionUpgradeLevel;
        S_GameManager.luckyGamblerUpgradeLevelSave = luckyGamblerUpgradeLevel;
        S_GameManager.avidityUpgradeLevelSave = avidityUpgradeLevel;
        S_GameManager.angryKaoriUpgradeLevelSave = angryKaoriUpgradeLevel;
        S_GameManager.luckyShotCooldownSave = luckyShotCooldown;
        
    }
}

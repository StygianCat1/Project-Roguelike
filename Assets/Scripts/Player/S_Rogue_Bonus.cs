using UnityEngine;

public class S_Rogue_Bonus : MonoBehaviour
{
    [Range(0, 3)] public int luckyGamblerUpgradeLevel = 0;
    [HideInInspector] public int luckMultiplier = 1;
    [Range(0, 3)] public int avidityUpgradeLevel = 0;
    [HideInInspector] public int avidityMultiplier = 1;
    [Range(0, 3)] public int angryKaoriUpgradeLevel = 0;
    [HideInInspector] public float baseKaoriCooldown;
    private float newKaoriCooldown;
    
    [Range(0, 3)] public int luckyShotLevel = 0;
    [HideInInspector] public int luckyshotRate = 0;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        luckyGamblerUpgradeLevel = S_GameManager.luckyGamblerUpgradeLevelSave;
        avidityUpgradeLevel = S_GameManager.avidityUpgradeLevelSave;
        angryKaoriUpgradeLevel = S_GameManager.angryKaoriUpgradeLevelSave;
        luckyShotLevel = S_GameManager.luckyShotCooldownSave;
        baseKaoriCooldown = GetComponent<S_Rogue_Combat>()._capacityCooldown;
        VerifyAllBonuses();
    }
    
    public void VerifyAllBonuses()
    {
        LuckyGamblerLevel(luckyGamblerUpgradeLevel);
        AvidityLevel(avidityUpgradeLevel);
        AngryKaoriLevel(angryKaoriUpgradeLevel);
        LuckyShotLevel(luckyShotLevel);
        
    }

    public void LuckyGamblerLevel(int lvl)
    {
        if (lvl == 0)
        {
            return;
        }
        if (lvl == 1)
        {
            luckMultiplier = 2;
            return;
        }
        if (lvl == 2)
        {
            luckMultiplier = 3;
            return;
        }
        if (lvl == 3)
        {
            luckMultiplier = 4;   
        }
    }
    
    public void AvidityLevel(int lvl)
    {
        if (lvl == 0)
        {
            return;
        }
        if (lvl == 1)
        {
            avidityMultiplier = 2;
            return;
        }
        if (lvl == 2)
        { 
            avidityMultiplier = 3;
            return;
        }
        if (lvl == 3)
        {
            avidityMultiplier = 5;
        }
    }
    
    public void AngryKaoriLevel(int lvl)
    {
        if (lvl == 0)
        {
            return;
        }
        if (lvl == 1)
        {
            newKaoriCooldown = baseKaoriCooldown - baseKaoriCooldown / (15 / 100);
            GetComponent<S_Rogue_Combat>()._capacityCooldown = newKaoriCooldown;
            return;
        }
        if (lvl == 2)
        {
            newKaoriCooldown = baseKaoriCooldown - baseKaoriCooldown / (30 / 100);
            GetComponent<S_Rogue_Combat>()._capacityCooldown = newKaoriCooldown;
            return;
        }
        if (lvl == 3)
        {
            newKaoriCooldown = baseKaoriCooldown - baseKaoriCooldown / (50 / 100);
            GetComponent<S_Rogue_Combat>()._capacityCooldown = newKaoriCooldown;
        }
    }
    
    public void LuckyShotLevel(int lvl)
    {
        if (lvl == 0)
        {
            return;
        }
        if (lvl == 1)
        {
            luckyshotRate = 15;
            return;
        }
        if (lvl == 2)
        {
            luckyshotRate = 33;
            return;
        }
        if (lvl == 3)
        {
            luckyshotRate = 50;
        }
    }
    
    public void SaveAllBonuses()
    {
        S_GameManager.luckyGamblerUpgradeLevelSave = luckyGamblerUpgradeLevel;
        S_GameManager.avidityUpgradeLevelSave = avidityUpgradeLevel;
        S_GameManager.angryKaoriUpgradeLevelSave = angryKaoriUpgradeLevel;
        S_GameManager.luckyShotCooldownSave = luckyShotLevel;
        
    }

    public void CancelBonuses()
    {
        S_GameManager.luckyGamblerUpgradeLevelSave = 0;
        S_GameManager.avidityUpgradeLevelSave = 0;
        S_GameManager.angryKaoriUpgradeLevelSave = 0;
        S_GameManager.luckyShotCooldownSave = 0;
    }
}

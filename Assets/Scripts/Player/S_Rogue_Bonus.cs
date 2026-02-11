using UnityEngine;

public class S_Rogue_Bonus : MonoBehaviour
{
    [Range(0, 3)] public int perversionUpgradeLevel;
    [Range(0, 3)] public int luckyGamblerUpgradeLevel;
    [Range(0, 3)] public int avidityUpgradeLevel;
    [Range(0, 3)] public int pangryKaoriUpgradeLevel;
    private int baseKaoriCooldown;
    
    [Range(0, 3)] public int LuckyShotCooldown;
    public int luckyshotRate = 0;
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

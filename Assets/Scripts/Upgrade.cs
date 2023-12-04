
 using UnityEngine;

public class Upgrade
    {
        public int Level;
        public int BaseEffect;   // Base effect of the upgrade
        public int BaseCost;     // Base cost of the upgrade
        public float CostMultiplier;  // Multiplier for cost increase per level
        public float EffectMultiplier;  // Multiplier for effect increase per level
        public UpgradeType Type;

        // Calculate current cost based on level
        public int CurrentCost => (int)(BaseCost * Mathf.Pow(CostMultiplier, Level));

        // Calculate current effect based on level
        public int CurrentEffect => (int)(BaseEffect * Mathf.Pow(EffectMultiplier, Level));
    }
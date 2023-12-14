[System.Serializable]
public class PlayerData 
{
    // Don't forget to initialize the value when there is no save
    public float TotalPoints = 0; 
    public float PointsPerClick = 1;
    public float PointsPerSecond = 0;
    public int TotalNumberOfClicks = 0; // for the stats
    public float TotalNumberOfPointsObtained = 0;  // for the stats
    public int LevelUpgradePointsPerSecond;
    public int LevelUpgradePointsPerClick;
}
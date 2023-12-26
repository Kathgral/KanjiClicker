[System.Serializable]
public class PlayerData 
{
    // Don't forget to initialize the value when there is no save
    public float TotalPoints = 0; 
    public float PointsPerClick = 1;
    public float PointsPerSecond = 0;
    public int TotalNumberOfClicks = 0; // for the stats
    public float TotalNumberOfPointsObtained = 0; 
    public int LevelUpgradePointsPerSecond = 0;
    public int LevelUpgradePointsPerClick = 0;
    public int LevelKanji = 0;
    public int Volume = 10;
    public int indexBackgroundImage = 0;
}
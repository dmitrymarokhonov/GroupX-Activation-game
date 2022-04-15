using Relanima;

[System.Serializable]

public class GameData
{
    public int resources;

    public GameData(GameStatus status)
    {
        resources = status.resources;
    }

}




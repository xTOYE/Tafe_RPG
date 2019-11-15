[System.Serializable]
public class PlayerDataToSave
{
    //data - from game
    public string playerName;
    public int level;
    public string checkPoint;
    public float maxHealth, maxMana, maxStamina;
    public float curHealth, curMana, curStamina;
    public float x, y, z;
    public float rX, rY, rZ, rW;
    public float pX, pY, pZ;
    public int skinIndex;
    public int hairIndex;
    public int eyesIndex;
    public int mouthIndex;
    public int clothesIndex;
    public int armourIndex;
    public int classIndex;
    public int[] stats = new int [6];

    public PlayerDataToSave(PlayerHandler player)
    {
        playerName = player.name;
        level = 0;
        //checkPoint = player.curCheckPoint;
        maxHealth = player.maxHealth;
        maxMana = player.maxMana;
        maxStamina = player.maxStamina;

        curHealth = player.curHealth;
        curMana = player.curMana;
        curStamina = player.curStamina;

        pX = player.transform.position.x;
        pY = player.transform.position.y;
        pZ = player.transform.position.z;

        rX = player.transform.rotation.x;
        rY = player.transform.rotation.y;
        rZ = player.transform.rotation.z;
        rW = player.transform.rotation.w;
    }
}

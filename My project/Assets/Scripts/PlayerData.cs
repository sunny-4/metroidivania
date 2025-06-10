using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public float[] positionArray;
    public string room;
    public bool double_jump;
    public bool swim;
    public bool fire;
    public bool key1;
    public bool key2;
    public bool key3;

    public PlayerData(Player player)
    {
        health = player.health;
        positionArray = new float[3] { 
            player.transform.position.x, 
            player.transform.position.y, 
            player.transform.position.z 
        };

        room = player.room;
        double_jump = player.double_jump;
        swim = player.swim;
        fire = player.fire;
        key1 = player.key1;
        key2 = player.key2;
        key3 = player.key3;
    }
}

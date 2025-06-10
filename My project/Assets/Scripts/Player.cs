using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public string room;
    public bool double_jump;
    public bool swim;
    public bool fire;
    public bool key1;
    public bool key2;
    public bool key3;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        Debug.Log("Working");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        health = data.health;
        room = data.room;
        transform.position = new Vector3(
            data.positionArray[0], 
            data.positionArray[1], 
            data.positionArray[2]
        );
        double_jump = data.double_jump;
        swim = data.swim;
        fire = data.fire;
        key1 = data.key1;
        key2 = data.key2;
        key3 = data.key3;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

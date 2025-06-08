using UnityEngine;
using UnityEngine.SceneManagement;

public class Playgame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void newgame()
    {
        if (SaveManager.player1_empty == true && SaveManager.player2_empty == true)
        {
            SaveManager.SaveData player1data = new SaveManager.SaveData();
            player1data.health = 5;
            player1data.position = new Vector3(0, 0, 0);
            player1data.room = "Store Room";
            player1data.double_jump = false;
            player1data.swim = false;
            player1data.fire = false;
            player1data.key1 = false;
            player1data.key2 = false;
            player1data.key3 = false;

            SaveManager.Save(player1data, 1);
            SceneManager.LoadScene("Store Room");

        }

        else if (SaveManager.player1_empty == true && SaveManager.player2_empty == false)
        {
            SaveManager.SaveData player1data = new SaveManager.SaveData();
            player1data.health = 5;
            player1data.position = new Vector3(0, 0, 0);
            player1data.room = "Store Room";
            player1data.double_jump = false;
            player1data.swim = false;
            player1data.fire = false;
            player1data.key1 = false;
            player1data.key2 = false;
            player1data.key3 = false;

            SaveManager.Save(player1data, 1);
            SceneManager.LoadScene("Store Room");
        }

        else if (SaveManager.player1_empty == false && SaveManager.player2_empty == true)
        {
            SaveManager.SaveData player2data = new SaveManager.SaveData();
            player2data.health = 5;
            player2data.position = new Vector3(0, 0, 0);
            player2data.room = "Store Room";
            player2data.double_jump = false;
            player2data.swim = false;
            player2data.fire = false;
            player2data.key1 = false;
            player2data.key2 = false;
            player2data.key3 = false;

            SaveManager.Save(player2data, 2);
            SceneManager.LoadScene("Store Room");
        }

        else
        {
            SceneManager.LoadScene("No game available");
        }


    }

    public void loadgame()
    {
        SceneManager.LoadScene("load room");
    }

    public void loadplayer1()
    {
        var data = SaveManager.Load(1);
        if (data != null)
        {
            SceneManager.LoadScene(data.room);
        }
        else
        {
            Debug.Log("No save file found for Player 1.");
            SceneManager.LoadScene("No game available"); // or some error screen
        }
    }



    public void loadplayer2()
    {
        var data = SaveManager.Load(2);
        if (data != null)
        {
            SceneManager.LoadScene(data.room);
        }
        else
        {
            Debug.Log("No save file found for Player 2.");
            SceneManager.LoadScene("No game available"); // or some error screen
        }
    }

    public void newgameback()
    {
        SceneManager.LoadScene("Main menu");
    }

    public void Deleteplayer1()
    {
        SaveManager.DeleteSave(1);
    }

    public void Deleteplayer2()
    {
        SaveManager.DeleteSave(2);
    }

    public void Savegame()
    {
        if (slot == 1)
        {
            SaveManager.SaveData player1data = new SaveManager.SaveData();
            player1data.health = 5;
            player1data.position = new Vector3(0, 0, 0);
            player1data.room = "Store Room";
            player1data.double_jump = false;
            player1data.swim = false;
            player1data.fire = false;
            player1data.key1 = false;
            player1data.key2 = false;
            player1data.key3 = false;

            SaveManager.Save(player1data, 1);
        }
        else
        {
            SaveManager.SaveData player2data = new SaveManager.SaveData();
            player1data.health = 5;
            player1data.position = new Vector3(0, 0, 0);
            player1data.room = "Store Room";
            player1data.double_jump = false;
            player1data.swim = false;
            player1data.fire = false;
            player1data.key1 = false;
            player1data.key2 = false;
            player1data.key3 = false;

            SaveManager.Save(player2data, 2);
        }
    }
}

using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public class SaveData
    {
        public int health;
        public Vector3 position;
        public string room;
        public bool double_jump;
        public bool swim;
        public bool fire;
        public bool key1;
        public bool key2;
        public bool key3;
    }

    // Save to a specific slot (e.g., 1 for Player 1, 2 for Player 2)
    public static void Save(SaveData data, int slot)
    {
        string json = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.persistentDataPath, $"saveData{slot}.json");
        File.WriteAllText(path, json);
    }

    // Load from a specific slot
    public static SaveData Load(int slot)
    {
        string path = Path.Combine(Application.persistentDataPath, $"saveData{slot}.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            return data; // Returns null if JsonUtility fails, or the data if it succeeds
        }
        return null; // Returns null if the file doesn't exist
    }


    public static void DeleteSave(int slot)
    {
        string path = Path.Combine(Application.persistentDataPath, $"saveData{slot}.json");
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static bool player1_empty
    {
        get
        {
            string path = Path.Combine(Application.persistentDataPath, "saveData1.json");
            return !File.Exists(path);
        }
    }

    public static bool player2_empty
    {
        get
        {
            string path = Path.Combine(Application.persistentDataPath, "saveData2.json");
            return !File.Exists(path);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private static HashSet<string> keys = new HashSet<string>();

    [Header("Player Stats")]
    [Range(0, 5)]
    public static int health = 5;

    [Header("Abilities")]
    public static bool doubleJump = false;
    public static bool swim = false;
    public static bool attack = false;

    public static void AddKey(string keyID)
    {
        keys.Add(keyID);
        Debug.Log("Key collected: " + keyID);
    }

    public static bool HasKey(string keyID)
    {
        return keys.Contains(keyID);
    }

    public static bool UseKey(string keyID)
    {
        if (keys.Contains(keyID))
        {
            keys.Remove(keyID);
            Debug.Log("Key used: " + keyID);
            return true;
        }
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private HashSet<string> keys = new HashSet<string>();

    [Header("Player Stats")]
    [Range(0, 5)]
    public int health = 5;

    [Header("Abilities")]
    public bool doubleJump = false;
    public bool swim = false;
    public bool attack = false;

    public void AddKey(string keyID)
    {
        keys.Add(keyID);
        Debug.Log("Key collected: " + keyID);
    }

    public bool HasKey(string keyID)
    {
        return keys.Contains(keyID);
    }

    public bool UseKey(string keyID)
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

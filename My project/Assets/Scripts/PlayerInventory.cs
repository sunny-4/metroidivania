using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour
{
    private HashSet<string> keys = new HashSet<string>();

    public void AddKey(string keyID)
    {
        keys.Add(keyID);
        Debug.Log("Key collected: " + keyID);
    }

    // Add these methods directly below AddKey
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


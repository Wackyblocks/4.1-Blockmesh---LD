using UnityEngine;
using System.Collections.Generic;

public class PlayerKeyInventory : MonoBehaviour
{
    private HashSet<DoorActionBehaviour.KeyType> keys = new();

    public void AddKey(DoorActionBehaviour.KeyType key)
    {
        keys.Add(key);
    }

    public bool HasKey(DoorActionBehaviour.KeyType key)
    {
        return keys.Contains(key);
    }
}

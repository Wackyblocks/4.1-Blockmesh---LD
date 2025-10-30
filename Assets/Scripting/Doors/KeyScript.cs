using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.Audio;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private enum keyType { Red, Green, Blue }
    [SerializeField] private keyType KeyType = keyType.Red;

    [Header("Objects")]
    [SerializeField] private GameObject keyItem;

    [Header("Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupSound;

    [Header("Materials")]
    [SerializeField] Material Red;
    [SerializeField] Material Green;
    [SerializeField] Material Blue;

    private bool pickedUp;

    private void OnDrawGizmos()
    {
        //assing material of key based on enum
        //Renderer renderer = GetComponent<Renderer>();
        if (KeyType == keyType.Red)
        {
            //renderer.material = Red;
        }
        else if (KeyType == keyType.Green)
        {
            //renderer.material = Green;
        }
        else if (KeyType == keyType.Blue)
        {
            //renderer.material = Green;
        }
    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player") && !pickedUp)
        {
            pickedUp = true;
            Destroy(keyItem);

            Debug.Log("Key picked up");
            //store data that key is picked up
            return;
        }
    }


}

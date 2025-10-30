using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.Audio;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private enum keyType { Red, Green, Blue }
    [SerializeField] private keyType KeyType = keyType.Red;

    [Header("Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupSound;

    private bool active;

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            active = true;
            Debug.Log("Stepped on plate");
            return;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            active = false;
            Debug.Log("Left plate");
            return;
        }
    }


}

using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private enum keyType { Red, Green, Blue }
    [SerializeField] private keyType KeyType = keyType.Red;

    [Header("Objects")]
    [SerializeField] private GameObject keyItem;
    [SerializeField] private SphereCollider Trigger;

    [Header("Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupSound;

    private bool pickedUp;


    void Start()
    {
        //set defaults
        pickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void pickUpKey()
    {
        pickedUp = true;
        Destroy(keyItem);

        //play audio
        audioSource.clip = pickupSound;
        audioSource.PlayOneShot(pickupSound);
    }
}

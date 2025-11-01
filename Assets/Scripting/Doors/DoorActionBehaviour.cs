using UnityEngine;
using StarterAssets;

public class DoorActionBehaviour : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private GameObject promptOpen;
    [SerializeField] private GameObject promptNeedKey;

    [Header("Locks")]
    [SerializeField] private bool useKeys = false;
    public enum KeyType { Red, Green, Blue }
    [SerializeField] private KeyType keyType = KeyType.Red;

    [Header("Sound")]
    [SerializeField] private AudioClip soundDoorOpen;
    [SerializeField] private AudioClip soundDoorClose;

    private bool isOpen;
    private bool inTrigger;

    private StarterAssetsInputs inputs;
    private AudioSource audioSource;

    private void Start()
    {
        promptOpen?.SetActive(false);
        promptNeedKey?.SetActive(false);

        inputs = Object.FindFirstObjectByType<StarterAssetsInputs>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!inTrigger) return;

        bool playerHasKey = CheckIfPlayerHasKey();

        // Update prompts while player is near the door
        if (useKeys)
        {
            if (playerHasKey)
            {
                if (!promptOpen.activeSelf)
                {
                    promptNeedKey.SetActive(false);
                    promptOpen.SetActive(true);
                }
            }
            else
            {
                if (!promptNeedKey.activeSelf)
                {
                    promptOpen.SetActive(false);
                    promptNeedKey.SetActive(true);
                }
            }
        }

        // Open door on interact
        if (inputs != null && inputs.interact)
        {
            if (!useKeys || playerHasKey)
            {
                OpenDoor();
            }

            // Consume input
            inputs.interact = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        inTrigger = true;

        if (useKeys)
        {
            if (CheckIfPlayerHasKey())
                promptOpen?.SetActive(true);
            else
                promptNeedKey?.SetActive(true);
        }
        else
        {
            promptOpen?.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        inTrigger = false;
        promptOpen?.SetActive(false);
        promptNeedKey?.SetActive(false);

        //  Auto-close the door
        CloseDoor();
    }

    private void OpenDoor()
    {
        if (isOpen) return;

        isOpen = true;
        doorAnimator.SetBool("isOpen", true);

        if (soundDoorOpen)
            audioSource?.PlayOneShot(soundDoorOpen);

        promptOpen?.SetActive(false);
        promptNeedKey?.SetActive(false);
    }

    private void CloseDoor()
    {
        if (!isOpen) return;

        isOpen = false;
        doorAnimator.SetBool("isOpen", false);

        if (soundDoorClose)
            audioSource?.PlayOneShot(soundDoorClose);
    }

    private bool CheckIfPlayerHasKey()
    {
        if (!useKeys) return true;

        var keyManager = Object.FindFirstObjectByType<PlayerKeyInventory>();
        if (keyManager == null) return false;

        return keyManager.HasKey(keyType);
    }
}

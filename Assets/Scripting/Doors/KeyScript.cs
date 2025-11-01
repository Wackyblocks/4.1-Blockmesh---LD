using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [Header("Key Settings")]
    [SerializeField] private DoorActionBehaviour.KeyType keyType = DoorActionBehaviour.KeyType.Red;

    [Header("Objects")]
    [SerializeField] private GameObject keyItem; // visual model of the key

    [Header("Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupSound;

    private bool pickedUp;

    private void OnTriggerEnter(Collider other)
    {
        if (pickedUp) return;
        if (!other.CompareTag("Player")) return;

        // Prevent multiple triggers
        pickedUp = true;

        // Add key to player's inventory
        var inventory = other.GetComponent<PlayerKeyInventory>();
        if (inventory != null)
        {
            inventory.AddKey(keyType);
            Debug.Log($"Player picked up {keyType} key!");
        }
        else
        {
            Debug.LogWarning("No PlayerKeyInventory found on player!");
        }

        // Play pickup sound
        if (audioSource && pickupSound)
        {
            audioSource.PlayOneShot(pickupSound);
        }

        // Hide or remove the key model
        if (keyItem != null)
            keyItem.SetActive(false);

        // Optional: destroy after sound delay
        Destroy(gameObject, pickupSound ? pickupSound.length : 0f);
    }
}

using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.Audio;

public class Powerup : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject powerupItem;

    [Header("Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupSound;

    [Header("Refill")]
    [SerializeField] private float refillTime = 40.0f;

    private bool pickedUp;
    private bool isOnCooldown;

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player") && !pickedUp)
        {
            pickedUp = true;
            powerupItem.SetActive(false);

            Debug.Log("Powerup picked up");

            //trigger cooldown
            StartCoroutine(Cooldown());
            //store data that key is picked up
            return;
        }
    }
    IEnumerator Cooldown()
    {
        isOnCooldown = true;
        float timer = 0f;

        while (timer < refillTime)
        {
            timer += Time.deltaTime;
            refillTime = 1 - (timer / refillTime);
            yield return null;
        }

        Refill(); 
    }

    void Refill()
    {
        isOnCooldown = false;
        pickedUp = false;
        Debug.Log("Add refill here for object");
        powerupItem.SetActive(true);
    }
}

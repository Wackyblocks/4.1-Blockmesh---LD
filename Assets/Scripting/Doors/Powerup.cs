using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.Audio;

public class Powerup : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject powerupItem;
    [SerializeField] private Animator animator;

    [Header("Sounds")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupSound;

    [Header("Refill")]
    [SerializeField] private float refillTime = 6.0f;

    private bool pickedUp = false;
    private bool isOnCooldown = false;

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player") && !isOnCooldown)
        {
            pickedUp = true;
            powerupItem.SetActive(false);

            Debug.Log("Powerup picked up, add effect of you choice");

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
            float progress = timer / refillTime;

            yield return null;
        }

        Refill(); 
    }

    void Refill()
    {
        isOnCooldown = false;
        pickedUp = false;

        animator.SetTrigger("Spawn");
        powerupItem.SetActive(true);
        
    }
}

using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DoorTriggerBehaviour : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Animator doorAnimator;

    [Header("Sound")]
    [SerializeField] private AudioClip soundDoorOpen;
    [SerializeField] private AudioClip soundDoorClose;

    private bool isOpen;

    
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            isOpen = true;
            doorAnimator.SetBool("isOpen", true);
            return;

        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            //play sound effect
            isOpen = false;
            doorAnimator.SetBool("isOpen", false);
            Debug.Log("Door closed");
            
            return;
        }
    }



}

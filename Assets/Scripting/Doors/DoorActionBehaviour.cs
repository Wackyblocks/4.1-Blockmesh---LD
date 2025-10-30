using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class DoorActionBehaviour : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Animator doorAnimator;

    [Header("Locks")]
    [SerializeField] private bool useKeys = false;
    [SerializeField] private enum keyType { Red, Green, Blue }
    [SerializeField] private keyType KeyType = keyType.Red;

    [Header("Sound")]
    [SerializeField] private AudioClip soundDoorOpen;
    [SerializeField] private AudioClip soundDoorClose;

    private bool isOpen;
    private bool inTrigger;
    private void Update()
    {
        if (inTrigger) //figure out how to get interact trigger from player
        {
            //if (_input.interact && !isOpen)
            //{
            //    Debug.Log("DoorClick");
            //}

        }
    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            inTrigger = true;
            Debug.Log("Press `E` to Open Door");
            return;
        }
    }
    void OpenDoor()
    {
        isOpen = true;
        doorAnimator.SetBool("isOpen", true);
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

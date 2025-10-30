using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private BoxCollider boxTrigger;
    [SerializeField] private Animator doorAnimator;

    [Header("Behaviour")]
    [SerializeField] private float remainOpenInSeconds = 2f;

    [Header("Sound")]
    [SerializeField] private AudioClip soundDoorOpen;
    [SerializeField] private AudioClip soundDoorClose;

    private bool isOpen;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("door opened no tag");
        if (other.CompareTag("Player"))
        {
            OpenDoor();
            Debug.Log("door opened");
            return;
        }
    }

    void Start()
    {
        //init
        
    }
    void Update()
    {
        //check for player
        
    }

    void OpenDoor()
    {
        //play effect
        isOpen = true;
        doorAnimator.SetBool("IsJumping", true);
        //anim open
    }

    //void IEnumerator DoorRemainOpen()

    void CloseDoor()
    {
        //play sound effect
        isOpen = false;

        //anim close
    }



}

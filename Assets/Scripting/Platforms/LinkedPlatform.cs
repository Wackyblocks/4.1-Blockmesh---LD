using UnityEngine;

public class LinkedPlatform : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Animator animator;
    [SerializeField] private bool isTriggered;

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            animator.SetBool("isTriggered", true);
        }
        else
        {
            animator.SetBool("isTriggered", false);
        }

    }
}

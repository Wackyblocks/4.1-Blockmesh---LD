using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Animator animator;
    [SerializeField] private bool isEnabled;

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            animator.SetBool("isActive", true);
        }
        else
        {
            animator.SetBool("isActive", false);
        }

    }
}

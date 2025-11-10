using UnityEngine;
using UnityEngine.UI;

public class CaptureZone : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject captureTrigger;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject captureProgressText;
    [SerializeField] private Slider captureProgressSlider;

    [Header("Settings")]
    [SerializeField] private float captureDuration = 5.0f;      
    [SerializeField] private float decayRate = 0.5f;            

    private bool inCaptureArea;
    private bool captured;
    private float captureProgress = 0f;

    private void Start()
    {
        if (captureProgressText != null)
            captureProgressText.SetActive(false);

        if (captureProgressSlider != null)
            captureProgressSlider.value = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inCaptureArea = true;

            // Always show when entering, if not captured
            if (!captured && captureProgressText != null)
                captureProgressText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inCaptureArea = false;
        }
    }

    private void Update()
    {
        if (captured) return;

        //refresh calculation
        if (inCaptureArea)
        {
            captureProgress += Time.deltaTime / captureDuration;
        }
        else
        {
            captureProgress -= Time.deltaTime * decayRate;
        }

        captureProgress = Mathf.Clamp01(captureProgress);

        //hide when no activity
        if (!inCaptureArea && captureProgress <= 0f && captureProgressText.activeSelf)
        {
            captureProgressText.SetActive(false);
        }

        //refresh
        if (captureProgressSlider != null)
        {
            captureProgressSlider.value = captureProgress;
        }

        //complete capturing
        if (captureProgress >= 1f && !captured)
        {
            captured = true;
            Debug.Log("area captured");
            animator.SetTrigger("Collapse");

            if (captureTrigger != null)
                captureTrigger.SetActive(true);
        }
    }
}

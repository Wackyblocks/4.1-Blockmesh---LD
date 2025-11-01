using UnityEngine;
using StarterAssets;

public class Keypad : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject keypadBlock; 
    [SerializeField] private GameObject keypadPrompt; 
    [SerializeField] private Camera playerCamera;    
    [SerializeField] private float interactDistance = 3f;

    private bool inTrigger;
    private bool keypadActivated;

    private StarterAssetsInputs inputs;

    private void Start()
    {
        keypadPrompt.SetActive(false);
        inputs = Object.FindFirstObjectByType<StarterAssetsInputs>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
            keypadPrompt.SetActive(false);
        }
    }

    private void Update()
    {
        //raycast check on keypad block

        if (!inTrigger) return;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            // check if ray hitting our keypad block
            if (hit.collider.gameObject == keypadBlock)
            {
                keypadPrompt.SetActive(true);

                // interact from input actions
                if (inputs != null && inputs.interact)
                {
                    ActivateKeypad();
                    inputs.interact = false; // consume the input (1 time use)
                }
            }
            else
            {
                keypadPrompt.SetActive(false);
            }
        }
        else
        {
            keypadPrompt.SetActive(false);
        }
    }

    private void ActivateKeypad()
    {
        if (keypadActivated) return;

        keypadActivated = true;
        Debug.Log("keypad activated"); //todo potential triggers
        keypadPrompt.SetActive(false);
    }
}

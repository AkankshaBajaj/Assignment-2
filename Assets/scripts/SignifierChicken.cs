using UnityEngine;

public class SignifierChicken : MonoBehaviour
{
    public GameObject signifierChicken; // Reference to the SignifierChicken GameObject

    // Start is called before the first frame update
    void Start()
    {
        // Set the SignifierChicken GameObject to active when the scene starts
        if (signifierChicken != null)
        {
            signifierChicken.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No SignifierChicken GameObject assigned to toggle!");
        }
    }

    // Function to enable the SignifierChicken GameObject
    public void EnableSignifierChicken()
    {
        if (signifierChicken != null)
        {
            signifierChicken.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No SignifierChicken GameObject assigned to enable!");
        }
    }

    // Function to disable the SignifierChicken GameObject
    public void DisableSignifierChicken()
    {
        if (signifierChicken != null)
        {
            signifierChicken.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No SignifierChicken GameObject assigned to disable!");
        }
    }
}

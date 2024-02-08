using UnityEngine;

public class Broccoli : MonoBehaviour
{
    public GameObject broccoli; // Reference to the broccoli GameObject

    // Start is called before the first frame update
    void Start()
    {
        // Set the broccoli GameObject to active when the scene starts
        if (broccoli != null)
        {
            broccoli.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No broccoli GameObject assigned to toggle!");
        }
    }

    // Function to enable the broccoli GameObject
    public void EnableBroccoli()
    {
        if (broccoli != null)
        {
            broccoli.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No broccoli GameObject assigned to enable!");
        }
    }

    // Function to disable the broccoli GameObject
    public void DisableBroccoli()
    {
        if (broccoli != null)
        {
            broccoli.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No broccoli GameObject assigned to disable!");
        }
    }
}

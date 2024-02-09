using UnityEngine;

public class Broccoli1 : MonoBehaviour
{
    public GameObject broccoli1; // Reference to the broccoli GameObject

    // Start is called before the first frame update
    void Start()
    {
        // Set the broccoli GameObject to active when the scene starts
        if (broccoli1 != null)
        {
            broccoli1.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No broccoli GameObject assigned to toggle!");
        }
    }

    // Function to enable the broccoli GameObject
    public void EnableBroccoli()
    {
        if (broccoli1 != null)
        {
            broccoli1.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No broccoli GameObject assigned to enable!");
        }
    }

    // Function to disable the broccoli GameObject
    public void DisableBroccoli()
    {
        if (broccoli1 != null)
        {
            broccoli1.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No broccoli GameObject assigned to disable!");
        }
    }
}

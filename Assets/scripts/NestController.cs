using UnityEngine;

public class NestController : MonoBehaviour
{
    public GameObject nest; // Reference to the nest GameObject

    void Start()
    {
        // Disable the nest GameObject at the start
        DisableNest();
    }

    // Function to enable the nest GameObject
    public void EnableNest()
    {
        if (nest != null)
        {
            nest.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No nest GameObject assigned to enable!");
        }
    }

    // Function to disable the nest GameObject
    public void DisableNest()
    {
        if (nest != null)
        {
            nest.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No nest GameObject assigned to disable!");
        }
    }
}

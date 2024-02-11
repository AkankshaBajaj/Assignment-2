using UnityEngine;

public class Farmer : MonoBehaviour
{
    public GameObject farmer; // Reference to the farmer GameObject

    // Start is called before the first frame update
    void Start()
    {
        // Set the farmer GameObject to active when the scene starts
        if (farmer != null)
        {
            farmer.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No farmer GameObject assigned to toggle!");
        }
    }

    // Function to enable the farmer GameObject
    public void EnableFarmer()
    {
        if (farmer != null)
        {
            farmer.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No farmer GameObject assigned to enable!");
        }
    }

    // Function to disable the farmer GameObject
    public void DisableFarmer()
    {
        if (farmer != null)
        {
            farmer.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No farmer GameObject assigned to disable!");
        }
    }
}

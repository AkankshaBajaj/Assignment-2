using UnityEngine;

public class RedButtonController : MonoBehaviour
{
    public GameObject farmer; // Reference to the farmer GameObject
    public GameObject banner; // Reference to the banner GameObject

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

    // Function to enable the banner GameObject
    public void EnableBanner()
    {
        if (banner != null)
        {
            banner.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No banner GameObject assigned to enable!");
        }
    }

    // Function to disable the banner GameObject
    public void DisableBanner()
    {
        if (banner != null)
        {
            banner.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No banner GameObject assigned to disable!");
        }
    }
}

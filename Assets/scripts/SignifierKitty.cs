using UnityEngine;

public class SignifierKitty : MonoBehaviour
{
    public GameObject signifierKitty; // Reference to the SignifierKitty GameObject

    // Start is called before the first frame update
    void Start()
    {
        // Set the SignifierKitty GameObject to active when the scene starts
        if (signifierKitty != null)
        {
            signifierKitty.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No SignifierKitty GameObject assigned to toggle!");
        }
    }

    // Function to enable the SignifierKitty GameObject
    public void EnableSignifierKitty()
    {
        if (signifierKitty != null)
        {
            signifierKitty.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No SignifierKitty GameObject assigned to enable!");
        }
    }

    // Function to disable the SignifierKitty GameObject
    public void DisableSignifierKitty()
    {
        if (signifierKitty != null)
        {
            signifierKitty.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No SignifierKitty GameObject assigned to disable!");
        }
    }
}

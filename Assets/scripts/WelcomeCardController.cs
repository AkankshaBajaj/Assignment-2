using UnityEngine;

public class WelcomeCardController : MonoBehaviour
{
    public GameObject welcomeCard; // Reference to the WelcomeCard GameObject

    // Start is called before the first frame update
    void Start()
    {
        // Set the WelcomeCard GameObject to active when the scene starts
        if (welcomeCard != null)
        {
            welcomeCard.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No WelcomeCard GameObject assigned to toggle!");
        }
    }

    // Function to enable the WelcomeCard GameObject
    public void EnableWelcomeCard()
    {
        if (welcomeCard != null)
        {
            welcomeCard.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No WelcomeCard GameObject assigned to enable!");
        }
    }

    // Function to disable the WelcomeCard GameObject
    public void DisableWelcomeCard()
    {
        if (welcomeCard != null)
        {
            welcomeCard.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No WelcomeCard GameObject assigned to disable!");
        }
    }
}


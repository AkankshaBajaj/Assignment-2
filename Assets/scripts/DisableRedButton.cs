using UnityEngine;

public class DisableRedButton : MonoBehaviour
{
    public GameObject bigRedButton; // Reference to the BigRedButton GameObject

    // Function to disable the BigRedButton
    public void DisableButton()
    {
        if (bigRedButton != null)
        {
            bigRedButton.SetActive(false); // Disable the BigRedButton GameObject
        }
        else
        {
            Debug.LogWarning("No BigRedButton GameObject assigned!");
        }
    }
}

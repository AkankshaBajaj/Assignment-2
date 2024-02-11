using UnityEngine;

public class CoopInteraction : MonoBehaviour
{
    public GameObject Dog;
    public GameObject Chicken;
    public GameObject Kitty;
    public GameObject heart; // Reference to the heart GameObject
    public AudioClip thankYouClip;
    private bool hasDog;
    private bool hasChicken;
    private bool hasKitty;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Dog)
        {
            hasDog = true;
        }
        else if (other.gameObject == Chicken)
        {
            hasChicken = true;
        }
        else if (other.gameObject == Kitty)
        {
            hasKitty = true;
        }

        CheckItems();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Dog)
        {
            hasDog = false;
        }
        else if (other.gameObject == Chicken)
        {
            hasChicken = false;
        }
        else if (other.gameObject == Kitty)
        {
            hasKitty = false;
        }

        CheckItems(); // Check again when an animal exits to update the state of the heart GameObject
    }

    void CheckItems()
    {
        if (hasDog && hasChicken && hasKitty)
        {
            EnableHeart();
            PlayThankYouClip();
        }
        else
        {
            DisableHeart();
        }
    }

    void EnableHeart()
    {
        if (heart != null)
        {
            heart.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Heart GameObject not assigned to enable!");
        }
    }

    void DisableHeart()
    {
        if (heart != null)
        {
            heart.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Heart GameObject not assigned to disable!");
        }
    }

    void PlayThankYouClip()
    {
        if (thankYouClip != null && audioSource != null && !audioSource.isPlaying)
        {
            audioSource.clip = thankYouClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Thank you audio clip or audio source not set, or audio is already playing!");
        }
    }
}

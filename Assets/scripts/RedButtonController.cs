using UnityEngine;

public class WellDoneTrigger : MonoBehaviour
{
    public GameObject Kitty; // Capitalized "Kitty"
    public GameObject Chicken; // Capitalized "Chicken"
    public GameObject Dog; // Capitalized "Dog"

    public AudioClip wellDoneClip;
    private AudioSource audioSource;

    private bool kittyInCoop = false;
    private bool chickenInCoop = false;
    private bool dogInCoop = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if all three animals are in the coop
        if (kittyInCoop && chickenInCoop && dogInCoop)
        {
            PlayWellDoneSound();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Kitty) // Capitalized "Kitty"
        {
            kittyInCoop = true;
        }
        else if (other.gameObject == Chicken) // Capitalized "Chicken"
        {
            chickenInCoop = true;
        }
        else if (other.gameObject == Dog) // Capitalized "Dog"
        {
            dogInCoop = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Kitty) // Capitalized "Kitty"
        {
            kittyInCoop = false;
        }
        else if (other.gameObject == Chicken) // Capitalized "Chicken"
        {
            chickenInCoop = false;
        }
        else if (other.gameObject == Dog) // Capitalized "Dog"
        {
            dogInCoop = false;
        }
    }

    void PlayWellDoneSound()
    {
        if (audioSource != null && wellDoneClip != null)
        {
            audioSource.clip = wellDoneClip;
            audioSource.Play();
        }
    }
}

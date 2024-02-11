using UnityEngine;

public class CarrotDisappearance : MonoBehaviour
{
    public GameObject rabbit;
    public AudioClip eatingSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == rabbit)
        {
            // Play eating sound
            if (audioSource != null && eatingSound != null)
            {
                audioSource.PlayOneShot(eatingSound);
            }

            // Destroy the carrot
            Destroy(gameObject);
        }
    }
}

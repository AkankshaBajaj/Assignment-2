using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class collcheck : MonoBehaviour
{
    public AudioTrigger audioTrigger;
    public GameObject mesh1;
    public GameObject mesh2;

    void Start()
    {
        // Get the AudioTrigger script component from the same GameObject
        audioTrigger = GetComponent<AudioTrigger>();
    }

    void Update()
    {
        // Check for overlap between the two meshes
        if (MeshesOverlap(mesh1, mesh2))
        {
            Debug.Log("Meshes are overlapping!");

            // Call PlayAudio() from AudioTrigger script
            if (audioTrigger != null)
            {
                audioTrigger.PlayAudio();
            }
        }


        //checkCollide();
    }

    public void checkCollide()
    {
        if (MeshesOverlap(mesh1, mesh2))
        {
            Debug.Log("Meshes are overlapping!");

            // Call PlayAudio() from AudioTrigger script
            if (audioTrigger != null)
            {
                audioTrigger.PlayAudio();
            }
        }
    }

    bool MeshesOverlap(GameObject obj1, GameObject obj2)
    {
        // Get the colliders of both objects
        Collider collider1 = obj1.GetComponent<Collider>();
        Collider collider2 = obj2.GetComponent<Collider>();

        // Check for overlap using Physics.OverlapBox
        if (collider1 != null && collider2 != null)
        {
            Bounds bounds1 = collider1.bounds;
            Bounds bounds2 = collider2.bounds;

            // Adjust the size of the box according to your needs
            Vector3 overlapBoxSize = new Vector3(1f, 1f, 1f);

            // Check for overlap using Physics.OverlapBox
            return Physics.OverlapBox(bounds1.center, overlapBoxSize / 2, Quaternion.identity)
                .Any(collider => collider == collider2);
        }

        return false;
    }
}
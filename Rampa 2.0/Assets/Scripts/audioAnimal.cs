using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioAnimal : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (audioSource != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
           
    }
}

using UnityEngine;

public class Horn : MonoBehaviour
{
    public AudioClip hornSound;
    public AudioClip driveSound;

    public AudioSource audioSource;  
    public AudioSource audioSource2; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            audioSource.PlayOneShot(hornSound);
        }

        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput != 0f)
        {
            if (!audioSource2.isPlaying)
            {
                audioSource2.loop = true; 
                audioSource2.clip = driveSound;
                audioSource2.Play();
            }
            audioSource2.volume = 1f;
        }
        else
        {
            audioSource2.volume = 0.3f;
        }
    }
}

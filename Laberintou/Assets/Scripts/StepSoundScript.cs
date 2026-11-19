using UnityEngine;

public class StepSoundScript : MonoBehaviour
{
    private AudioSource aSource;
    public AudioClip stepSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aSource = gameObject.AddComponent<AudioSource>();
        aSource.playOnAwake = false;
        aSource.volume = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StepHit(){

        if (stepSound == null){
            return;
        }
        aSource.pitch = Random.Range(.8f, 1.2f);
        aSource.PlayOneShot(stepSound);
    }
}

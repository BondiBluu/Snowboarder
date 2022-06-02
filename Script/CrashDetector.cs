using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float crashDelayTime = 2f;
    [SerializeField] ParticleSystem crashEffect;
    //getting a public SFX to hook onto in Unity.  
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
void OnTriggerEnter2D(Collider2D other){
    //if the circle collider on the player's head hits the ground (capsule collider is not trigger, circle collider is) 
    //AND if you haven't crashed yet
    if(other.tag == "Ground" && hasCrashed == false){
        //you've crashed, so the sound and particle effect won't play anymore.
        hasCrashed = true;
        //contacting PlayerController class to disable movement when crashing
        FindObjectOfType<PlayerController>().DisableControls();
        //trigger particle effect
        crashEffect.Play();
        //play a certain audio clip
        GetComponent<AudioSource>().PlayOneShot(crashSFX);
        //invoke Reload method at a certain time
        Invoke("ReloadScene", crashDelayTime);
    }
}

void ReloadScene(){
    SceneManager.LoadScene(0);
}
}

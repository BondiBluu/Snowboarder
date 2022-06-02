using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;
    [SerializeField] ParticleSystem finishEffect;
void OnTriggerEnter2D(Collider2D other){
    if(other.tag == "Player"){
        //trigger particle effect
        finishEffect.Play();
        //playing the audio attached to the gameobject
        GetComponent<AudioSource>().Play();
        //invoke Reload method at a certain time
        Invoke("ReloadScene", delayTime);
    }
}
void ReloadScene(){
    SceneManager.LoadScene(0);
}
}

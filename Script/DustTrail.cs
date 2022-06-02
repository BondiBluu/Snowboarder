using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField] class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem boardParticles;
    void OnCollisionEnter2D(Collision2D other){
        //if the board is touching the ground, play the board particles
        if(other.gameObject.tag == "Ground"){
            boardParticles.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other){
        //if the board exits the ground, stop the board particles
        if(other.gameObject.tag == "Ground"){
            boardParticles.Stop();
        }
    }
}

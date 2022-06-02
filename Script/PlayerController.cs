using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //adding torque (rotation ) to the chara's rigidbody when the player psuhes the keyboard
        Rigidbody2D rb2d;
        [SerializeField] float torqueAmount = 1;
        [SerializeField] float boostSpeed = 30f;
        [SerializeField] float baseSpeed = 20f;
        SurfaceEffector2D surfaceEffector2D;
        bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        //getting the rigidbody in whoever is holding the script to control
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if you haen't crashed yet, you have control over the player.
        if(canMove){
        RotatePlayer();
        RespondToBoost();
        }
    }

    public void DisableControls(){
        //disabling player controls when player crashes
        canMove = false;

    }

    void RotatePlayer()
    {
        //if player presses left, add torque to move character forward
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost(){
        //if up is pushed, speed up, otherwise, stay at the normal speed
        //accessing SurfaceEffector2D and changing its speed
        if(Input.GetKey(KeyCode.UpArrow)){
            surfaceEffector2D.speed = boostSpeed;
        }else{
            surfaceEffector2D.speed = baseSpeed;
        }
    }
}

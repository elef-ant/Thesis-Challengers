using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator anim;
    public float walking_speed = 0.001f;
    private bool jumping_state = false;
    private AnimatorStateInfo fighter01_layer01;
    private bool left_walking = true;
    private bool right_walking = true;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        fighter01_layer01 = anim.GetCurrentAnimatorStateInfo(0);

        //moving on screen limitations
        Vector3 screenbounds = Camera.main.WorldToScreenPoint(this.transform.position);

        if (screenbounds.x > Screen.width - 200)
        {
            right_walking = false;
        }
        else if (screenbounds.x < 200)
        {
            left_walking = false;
        }
        else
        {
            right_walking = true;
            left_walking = true;
        }

        //move forward
        if (fighter01_layer01.IsTag("Motion"))
        {
            if (right_walking == true)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    anim.SetBool("forward", true);
                    transform.Translate(walking_speed, 0, 0);
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    anim.SetBool("backward", true);
                    transform.Translate(-walking_speed, 0, 0);
                }
                // back to idle
                else
                {
                    anim.SetBool("forward", false);
                    anim.SetBool("backward", false);
                }
            }
            //move backward
            if (left_walking == true)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    anim.SetBool("forward", true);
                    transform.Translate(walking_speed, 0, 0);
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    anim.SetBool("backward", true);
                    transform.Translate(-walking_speed, 0, 0);
                }
                // back to idle
                else
                {
                    anim.SetBool("forward", false);
                    anim.SetBool("backward", false);
                }
            }
            
        }
        
        //jumping
        if (Input.GetAxis("Vertical") > 0)
        {
            if (jumping_state == false)
            {
                jumping_state = true;
                anim.SetTrigger("jump");
                StartCoroutine(JumpingPause());
            }
            
        }
        //crouching
        else if (Input.GetAxis("Vertical") < 0)
        {
            anim.SetBool("crouch", true);
        }
        //back to idle
        else
        {
            anim.SetBool("crouch", false);
        }

    }

   IEnumerator JumpingPause()
    {
        yield return new WaitForSeconds(1.0f);
        jumping_state = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 pos;
    Rigidbody playerrb;


    [SerializeField]float turnspeed;
    float jump;
    [SerializeField]float jumpforce;


    bool isgrounded;
    [SerializeField] float groundclearance;

    [SerializeField] float speedometerspeed;
    [SerializeField] float speedometerspeedsmoothness;

    
    void Start()
    {
        playerrb=GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputmanager();
        Debug.DrawRay(transform.position, -transform.up, Color.red);
        isgrounded = checkground();

        speedometer();
    }

    private void FixedUpdate()
    {
        transform.Translate(pos*turnspeed*Time.deltaTime);


        if (jump == 1&&isgrounded)
        {
            playerrb.AddForce(transform.up * jumpforce*Time.deltaTime,ForceMode.Impulse);
        }
    }
    void inputmanager()
    {
        pos.x = Input.GetAxis("Horizontal");

        jump=Input.GetAxis("Jump");
        

    }
    bool checkground()
    {
        if(Physics.Raycast(transform.position, -transform.up, transform.localScale.y / 2+groundclearance))
        {

            return true;
        }
        return false;

    }


    void speedometer()
    {
        speedometerspeed = Mathf.Lerp(speedometerspeed, 30, speedometerspeedsmoothness);


    }
}

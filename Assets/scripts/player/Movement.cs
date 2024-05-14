using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Vector3 pos;
    Rigidbody playerrb;

    [SerializeField] float skyboxrotation;
    [SerializeField]float turnspeed;
    float jump;
    [SerializeField]float jumpforce;


    bool isgrounded;
    [SerializeField] float groundclearance;

    [SerializeField] public float speedometerspeed;
    [SerializeField] float speedometerspeedsmoothness;

    [SerializeField] int targetspeed;
 
    [SerializeField] int upperbound;

    RaycastHit hit;
    bool collieded=false;

    [SerializeField] CanvasGroup snowsplat;
    [SerializeField] float alphaIncreaseAmount;
    [SerializeField]public  int skiglassamount;
    spawning spawnsc;
    void Start()
    {

        playerrb=GetComponent<Rigidbody>();

        
    }

    void Update()
    {
        inputmanager();
        
        isgrounded = checkground();

        speedometer();

        collisioncheck();
    }

    private void FixedUpdate()
    {
        playerrb.velocity = new Vector3(pos.x * turnspeed * Time.deltaTime, playerrb.velocity.y, playerrb.velocity.z);


        if (jump == 1&&isgrounded)
        {
            playerrb.AddForce(transform.up * jumpforce*Time.deltaTime,ForceMode.Impulse);
        }
    }
    void inputmanager()
    {
        pos.x = Input.GetAxis("Horizontal");

        jump=Input.GetAxis("Jump");

        if (Input.GetKeyDown(KeyCode.M))
        {
            targetspeed += 50;
            StartCoroutine(speedometerspeeddown());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (skiglassamount != 0) {
                skiglassamount--;
                snowsplat.alpha = 0;
            }
        }
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
        speedometerspeed = Mathf.Lerp(speedometerspeed, 120f, speedometerspeedsmoothness);


        if (speedometerspeed < 20)
        {
            SceneManager.LoadScene("Mainmenu");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            spawnsc.spawnrandomlevel();
        }

        if (other.gameObject.CompareTag("towel"))
        {
            if(skiglassamount<3) skiglassamount++;
        }
    }
    void collisioncheck()
    {
        Debug.DrawRay(new Vector3(transform.position.x -1f, transform.position.y-0.5f, transform.position.z), transform.right*2f, Color.red);
 
       if( Physics.Raycast(new Vector3( transform.position.x-1f, transform.position.y-0.5f, transform.position.z), transform.right*2f,out hit))
        {

        if (hit.collider.gameObject.CompareTag("Snowman")&&collieded==false)
        {
                
                shakeeffect();
                splatimagerevel();
                speedometerspeed -= 10;
                collieded = true;

        }
        else
        {
            collieded = false;
        }
        }

    }


    IEnumerator speedometerspeeddown()
    {
        yield return new WaitForSeconds(3f);
        targetspeed -= 50;
    }

    void shakeeffect()
    {
        Camerashaker.Invoke();
    }
    void splatimagerevel()
    {
        float newAlpha = Mathf.Clamp(snowsplat.alpha + alphaIncreaseAmount, 0f, 0.4f);
        snowsplat.alpha = newAlpha;
    }

}

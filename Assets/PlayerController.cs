using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 moveDirection;
    public float speed;
    public bool isRunning;

    public Rigidbody rb;
    public float jumpForce;
    public int jumpsLeft;

    private Animator anim;

    private GameManager gmScript;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Main Camera").GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jumpsLeft = 1;
        gmScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    { 
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(x, 0, z);
        transform.Translate(moveDirection * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Using a rigidbody
            anim.SetTrigger("Jump");
            rb.velocity = new Vector3(0, jumpForce, 0);
            jumpsLeft--;
        }

        //Animator
        if(x != 0 || z != 0)
        {
            anim.SetFloat("Run", .2f);
        }
        else
        {
            anim.SetFloat("Run", 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpsLeft = 1;
        }
        if(collision.gameObject.CompareTag("Death"))
        {
            gmScript.PlayerDeath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Start"))
        {
            gmScript.timerRunning = true;
        }
        if (other.gameObject.CompareTag("End"))
        {
            gmScript.timerRunning = false;
            if(gmScript.timer < gmScript.bestTime)
            {
                gmScript.bestTime = gmScript.timer;
                gmScript.timer = 0;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerXbox : MonoBehaviour
{
    public CharacterController controller;
    //public HeadBob headBob;

    //public GameObject Player;
    //public GameObject Camera;

    public static Vector3 playerPos;

    public float moveSpeed = 10.0f;
    public float gravity = -9.81f;

    public float runSpeed = 16f;
    public float walkSpeed = 10f;
    public float crouchSpeed = 5f;

    public bool crouch = false;
    public bool walk = false;
    public bool run = false;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    Vector3 playerCrouch = new Vector3(1.5f, 1.0f, 1.5f);
    Vector3 playerStand = new Vector3(1.5f, 1.5f, 1.5f);

    public AudioSource source;
    [SerializeField] public bool isMoving;

    //public bool inBox = false;
    //public bool movementCheck = false;


    private void Start()
    {
        source = GetComponent<AudioSource>();
       // StartCoroutine(TrackPlayer());
        //Cursor.visible = false;
    }

    //IEnumerator TrackPlayer()
    //{
    //    while (true)
    //    {
    //        playerPos = gameObject.transform.position;
    //        yield return null;
    //    }
    //}


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        controllerButtons();
        playerDirection();


    }


    void playerDirection()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = 1 * Input.GetAxis("VerticalXbox");

        Vector3 move = transform.right * x + transform.forward * z;


        //Player crouch, walk, and sprint
        //Need to add code to increase/decrease the hearing radius of AI depending on the players movement

        //if (Input.GetKey(KeyCode.LeftControl))     //crouch and move
        //{
        //    moveSpeed = crouchSpeed;
        //    transform.localScale = playerCrouch;
        //    headBob.bobSpeed = 3.0f;
        //    crouch = true;
        //    walk = false;
        //    run = false;
        //}

        //else if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    moveSpeed = runSpeed;
        //    transform.localScale = playerStand;
        //    headBob.bobSpeed = 9.0f;
        //    crouch = false;
        //    walk = false;
        //    run = true;
        //}
        //else
        //{
        //    moveSpeed = walkSpeed;
        //    transform.localScale = playerStand;
        //    headBob.bobSpeed = 6.0f;
        //    crouch = false;
        //    walk = true;
        //    run = false;
        //}

        //if ((move.x > 0.0f || move.x < 0.0f) && (move.z > 0.0f) || (move.z < 0.0))
        //{
        //    movementCheck = true;
        //}
        //else
        //{
        //    movementCheck = false;
        //}

        controller.Move(move * moveSpeed * Time.deltaTime);
        if(controller.velocity.x != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        if(isMoving)
        {
            Debug.Log("Play Music");
            source.Play();
        }
        else
        {
            source.Stop();
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime); //only moves us in the y direction

    }

    public void controllerButtons() //currently displays button values from 1 to -1 or True/False
    {
        //Debug.Log("StartButton: " + Input.GetButtonDown("StartButton"));
        //Debug.Log("LeftBumper: " + Input.GetButtonDown("LeftBumper"));
        //Debug.Log("RightBumper: " + Input.GetButtonDown("RightBumper"));
        //Debug.Log("A Button: " + Input.GetButtonDown("AButton"));
        //Debug.Log("B Button: " + Input.GetButtonDown("BButton"));
        //Debug.Log("X Button: " + Input.GetButtonDown("XButton"));
        //Debug.Log("Y Button: " + Input.GetButtonDown("YButton"));
        //Debug.Log("Triggers: " + Input.GetAxis("Triggers"));

    }
}

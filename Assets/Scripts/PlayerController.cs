using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Player movement items
    public Animator playerAnimation;
    public Rigidbody rb;
    Vector2 _movementInput;
    public float PlayerSpeed = 5;
    public float RotationSpeed = 60;
    float rotateValue;
    public CharacterController _characterController;

    //Player points stuff
    private int income = 0;
    private int units = 0;
    private int foodbar = 100;
    private int sanity = 100;
    private int karma = 0;
    private int influence = 0;
    private int currentCash = 1000;
    [SerializeField] private TMP_Text statuses;
    [SerializeField] private TMP_Text karmaPoints;
    [SerializeField] private TMP_Text cashLeft;
    private int[] points;

    // Start is called before the first frame update
    void Start()
    {
        karma = 0;
        influence = 0;
        playerAnimation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
        points = new int[7];
        UpdateKarmaPoints();
    }

    void OnMove(InputValue input)
    {
        _movementInput = input.Get<Vector2>();
    }

    void OnLook(InputValue input)
    {
        rotateValue = input.Get<Vector2>().x;
    }

    public void IncreaseKarma(int karma)
    {
        karma += karma;
    }

    public void IncreaseInfluence(int influence)
    {
        influence += influence;
    }

    public bool commitPurchase(int price)
    {
        int purchaseRemainder = currentCash - price;
        if (purchaseRemainder < 0)
        {
            return false;
        }
        currentCash = purchaseRemainder;
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.W))
        {
            playerAnimation.SetBool("IsWalkPressed", true);
        } else
        {
            playerAnimation.SetBool("IsWalkPressed", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerAnimation.SetBool("IsSprintPressed", true);
        }
        else
        {
            playerAnimation.SetBool("IsSprintPressed", false);
        }
        */
        MovePlayer();
        RotatePlayer();
        
    }

    void MovePlayer()
    {
        Vector3 movement = new Vector3(_movementInput.x, 0, _movementInput.y);
        movement = transform.forward * movement.z + transform.right * movement.x;
        _characterController.Move(movement * Time.deltaTime * PlayerSpeed);
        if (movement.z != 0)
        {
            playerAnimation.SetBool("IsWalkPressed", true);
        }

        else
        {
            playerAnimation.SetBool("IsWalkPressed", false);
        }

        _characterController.Move(Physics.gravity * Time.deltaTime);
    }

    void RotatePlayer()
    {
        transform.Rotate(Vector3.up * rotateValue * RotationSpeed * Time.deltaTime);
    }

    private void UpdateKarmaPoints()
    {
        string toFinalString = "";
        //Update point array
        points[0] = income;
        points[1] = units;
        points[2] = foodbar;
        points[3] = sanity;
        points[4] = karma;
        points[5] = influence;
        points[6] = currentCash;
        //Convert point array to string
        for(int i = 0; i < 4; i++)
        {
            toFinalString += points[0] + "\n";
        }
        toFinalString += points[5];
        //Push to TMPro;
        statuses.text = toFinalString;
        karmaPoints.text = "Karma: " + karma;
        cashLeft.text = "$" + currentCash;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Triggered something");
        if (collision.gameObject.CompareTag("OptionTrigger"))
        {
            Debug.Log("Collided successfully!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered something");
    }
}

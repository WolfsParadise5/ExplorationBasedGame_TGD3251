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
    public int foodbar = 100;
    public int sanity = 100;
    private int karma = 0;
    private int currentCash = 1000;
    private int bankValue = 0;
    public bool isOwnRentalProperty = false;
    [SerializeField] private TMP_Text statuses;
    [SerializeField] private TMP_Text karmaPoints;
    [SerializeField] private TMP_Text cashLeft;
    private int[] points;
    private float timeControlforHungerInfo;
    private float timeControlforSanityInfo;

    //Player walking sounds
    private Keyboard kb;
    public AudioSource walkingSounds;

    //Player control stuff
    public bool isPlayerTriggerMenu = false;
    public PlayerData playerDataToGo;
    public const float hungerDeductable = 10.0f;
    public const float sanityDeductable = 25.0f;

    //Game Over
    public GameObject gameOverPanel, optionMenu;

    // Start is called before the first frame update
    void Start()
    {
        timeControlforHungerInfo = Time.time;
        timeControlforSanityInfo = Time.time;
        karma = 0;
        playerAnimation = GetComponent<Animator>();
        kb = InputSystem.GetDevice<Keyboard>();
        rb = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
        points = new int[7];
        
        UpdatePoints();
    }

    void OnMove(InputValue input)
    {
        if (!isPlayerTriggerMenu)
        {
            _movementInput = input.Get<Vector2>();
            walkingSounds.Play();
        }   
    }

    public void AddValueCash(int cashToAdd)
    {
        currentCash += cashToAdd;
    }

    public void AddIncome()
    {
        currentCash += income;
    }

    public void AddHunger(int hungerVal)
    {
        int total = foodbar += hungerVal;
        if (total > 100)
        {
            foodbar = 100;
        } else
        {
            foodbar = total;
        }
        UpdatePoints();
    }

    public void AddSanity(int sanityVal)
    {
        int total = sanityVal + sanity;
        if (total > 100)
        {
            sanity = 100;
        }
        else
        {
            sanity = total;
        }
        UpdatePoints();
    }

    void OnLook(InputValue input)
    {
        if (!isPlayerTriggerMenu)
            rotateValue = input.Get<Vector2>().x;
    }

    public void IncreaseKarma(int karma)
    {
        this.karma += karma;
        Debug.Log("Karma points added! " + karma);
        UpdatePoints();
    }

    public void IncreaseInfluence(int influence)
    {
        influence += influence;
    }

    public bool checkInventory(Item item)
    {
        if (playerDataToGo.item.Length == 0)
            return false;
        for(int i = 0; i < playerDataToGo.item.Length; i++)
        {
            if (playerDataToGo.item[i].Equals(item))
                return true;
        }
        return false;
    }

    public bool commitPurchase(int price, string type)
    {
        Debug.Log("Price recieved : " + price + ", Of Type: " + type + ". ");
        int purchaseRemainder = currentCash - price;
        if (purchaseRemainder < 0)
        {
            return false;
        }
        
        if (type == "RoofOverHead")
            isOwnRentalProperty = true;

        currentCash = purchaseRemainder;
        Debug.Log("CurrentCash: " + purchaseRemainder);
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        
        MovePlayer();
        RotatePlayer();

        if (!playerAnimation.GetBool("IsWalkPressed"))
        {
            walkingSounds.Stop();
        }

        if (Time.time - timeControlforHungerInfo > hungerDeductable)
        {
            foodbar -= 1;
            timeControlforHungerInfo = Time.time;
            UpdatePoints();
        }

        if (Time.time - timeControlforSanityInfo > sanityDeductable)
        {
            sanity -= 1;
            timeControlforSanityInfo = Time.time;
            UpdatePoints();
        }

        if (sanity <= 0)
            GameOver();

        if (kb.escapeKey.wasPressedThisFrame)
        {
            if (optionMenu.activeSelf)
            {
                optionMenu.SetActive(false);
                Cursor.visible = false;
            } 
            else
            {
                optionMenu.SetActive(true);
                Cursor.visible = true;
            }
        }

        //Update the income
        //1. If it has been a month, add to cash

    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    void MovePlayer()
    {
        Vector3 movement = new Vector3(_movementInput.x, 0, _movementInput.y);
        movement = transform.forward * movement.z + transform.right* movement.x;
        _characterController.Move(movement * Time.deltaTime * PlayerSpeed);
        if (movement.z != 0)
        {
            playerAnimation.SetBool("IsWalkPressed", true);
        }

        else
        {
            playerAnimation.SetBool("IsWalkPressed", false);
        }

        //_characterController.Move(Physics.gravity * Time.deltaTime);
    }

    void RotatePlayer()
    {
        transform.Rotate(Vector3.up * rotateValue * RotationSpeed * Time.deltaTime);
    }

    private void UpdatePoints()
    {
        string toFinalString = "";
        //Update point array
        points[0] = income;
        points[1] = units;
        points[2] = foodbar;
        points[3] = sanity;
        //Convert point array to string
        for(int i = 0; i < 4; i++)
        {
            toFinalString += points[i].ToString() + "\n";
        }
        //Push to TMPro;
        statuses.text = toFinalString;
        karmaPoints.text = "Karma: " + karma;
        cashLeft.text = "$" + currentCash;
        Debug.Log("Status points updated! " + statuses.text);
    }

    public void SetIncome(int income)
    {
        this.income = income;
        UpdatePoints();
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

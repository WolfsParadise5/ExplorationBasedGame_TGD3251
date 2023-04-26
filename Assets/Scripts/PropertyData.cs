using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PropertyData : MonoBehaviour
{
    //Details
    public string PropertyType { get; set; }
    public int RentalCost { get; set; }
    public int PurchaseCost { get; set; }
    public int initialMultipler = 1;
    public int multiplier;
    private int influenceRent = 20;
    private int influenceBuy = 80;
    public int karma = 5;
    public string description;

    //Manage with player info
    [SerializeField] private PlayerController playerController;

    //To display property description
    //Main Elements
    Keyboard kb;
    private bool isShowingOption = false;
    [SerializeField] private GameObject knowMore;
    [SerializeField] private GameObject knowMorePanel;
    //Description Display
    [SerializeField] private TMP_Text propertyType;
    [SerializeField] private TMP_Text propertyDescription;
    [SerializeField] private TMP_Text propertyRentPrice;
    [SerializeField] private TMP_Text propertyRentInfluence;
    [SerializeField] private TMP_Text propertyBuyPrice;
    [SerializeField] private TMP_Text propertyBuyInfluence;





    // Start is called before the first frame update
    void Start()
    {
        kb = InputSystem.GetDevice<Keyboard>();
        PropertyType = "Apartment";
        RentalCost = 1000 * multiplier;
        PurchaseCost = 4000000 * multiplier;
        description = "A nice humble abode to be in, one of the top apartments of the city";
    }
    
    public void AponRental()
    {
        if (playerController.commitPurchase(RentalCost))
        {
            playerController.IncreaseKarma(karma);
            playerController.IncreaseInfluence(influenceRent);
        } else
        {
            Debug.Log("Not enough budget to purchase!");
        }
    }

    public void AponPurchase()
    {
        if (playerController.commitPurchase(PurchaseCost))
        {
            playerController.IncreaseKarma(karma);
            playerController.IncreaseInfluence(influenceBuy);
        } else
        {
            Debug.Log("Not enough budget to purchase!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (initialMultipler != multiplier)
        {
            Debug.Log("Looks like above average marketing");
        }

        if (kb.eKey.wasPressedThisFrame && isShowingOption)
        {
            //Trigger panel
            knowMorePanel.SetActive(true);

            //Write all the description in
            propertyType.text = PropertyType;
            propertyDescription.text = description;
            propertyRentPrice.text = RentalCost.ToString();
            propertyRentInfluence.text = influenceRent.ToString();
            propertyBuyPrice.text = PurchaseCost.ToString();
            propertyBuyInfluence.text = influenceBuy.ToString();
        }
    }

    public void OnPressBackBtn()
    {
        knowMorePanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isShowingOption = true;
            knowMore.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isShowingOption = false;
            knowMore.SetActive(false);
        }
    }
}

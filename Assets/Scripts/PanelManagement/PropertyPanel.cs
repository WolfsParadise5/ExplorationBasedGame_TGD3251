using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PropertyPanel : BasePanelScript
{
    public enum Properties
    {
        Apartment, Condominium, Townhouse, Flat, TerraceOneStorey, TerraceTwoStorey, Bungalow, Mansion, Castle
    }

    // Values
    [SerializeField] private TMP_Text RentPrice;
    [SerializeField] private TMP_Text RentKarma;
    public int RentalCost;
    public int karmaRent; 
    public Properties propertyType = Properties.Apartment;
    public GameObject propertyOwnedPanel, cookPanel;
    public Button rentBtn;
    [SerializeField] private string uniqueID;
    public TimeController timeController;


    void Start()
    {
        kb = InputSystem.GetDevice<Keyboard>();
        //description = "A nice humble abode to be in, one of the top apartments of the city";
        type = "RoofOverHead";
        rentBtn.onClick.AddListener(AponRental);
        timeController = FindObjectOfType<TimeController>();
    }

    void Update()
    {     
        if (kb.eKey.wasPressedThisFrame && isShowingOption)
        {
            playerController.isPlayerTriggerMenu = true;
            Cursor.visible = true;
            if (playerController.isOwnRentalProperty)
            {
                propertyOwnedPanel.SetActive(true);
                rentBtn.onClick.RemoveListener(AponRental);
                rentBtn.onClick.AddListener(AponRental);
            } 
            else
            {
                //Trigger panel
                basePanel.SetActive(true);

                //Write all the description in
                title.text = propertyType.ToString();
                labelDescription.text = description;
                RentPrice.text = RentalCost.ToString();
                RentKarma.text = karmaRent.ToString();
                BuyPrice.text = PurchaseCost.ToString();
                BuyKarma.text = karmaBuy.ToString();
                rentBtn.GetComponent<PropertyButtonScript>().setID(uniqueID);
            }
        }
    }

    public void AponRental()
    {
        if (!rentBtn.GetComponent<PropertyButtonScript>().isID(uniqueID))
            return;

        Debug.Log("Price recieved : " + RentalCost + ", Of Type: " + type + ". ");
        if (playerController.commitPurchase(RentalCost, type))
        {
            playerController.IncreaseKarma(karmaRent);
            Debug.Log("Enough budget to purchase");
        }
        else
        {
            Debug.Log("Not enough budget to purchase!");
        }
    }

    #region alreadyOwnProperty
    public void OnPressSleep()
    {
        //Screen to black with delay
        /*
        FadeScript.Instance.triggerFadeIn(() => {
            timeController.AddHours(8f);
            FadeScript.Instance.triggerFadeOut();
        });
        */
    }

    public void OnPressShopMore()
    {
        propertyOwnedPanel.SetActive(false);
        basePanel.SetActive(true);
    }

    

    public void OnPressCook()
    {
        propertyOwnedPanel.SetActive(false);
        cookPanel.SetActive(true);
    }

    public void OnPressExitFromOwnedPanel()
    {
        propertyOwnedPanel.SetActive(false);
    }

    
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RestaurantPanel : BasePanelScript
{
    // Panel to show food item
    public GameObject extraPanel;

    //Food itenary
    public string[] foodNames =
    {
        "French Toast",
        "Spaghetti Bolognese",
        "Mixed Rice",
        "Chicken Burger",
        "Vegan Burger",
        "Fries",
        "Samosa",
        "Milkshake",
        "Steamed Crab with Asparagus",
        "Laksa",
        "Mixed Noodles with Stir Fry Vegetables",
        "Fish and Chips",
        "Pisang Goreng",
        "Water"
    };

    public string[] foodDescriptions =
    {
        "Basic toasted bread, coated with egg mix and toasted on a heated pan",
        "Very basic meal with very basic needs of wheat and protein",
        "Mixed categories of food served fresh daily",
        "A burger, with chicken",
        "A burger, for the ones that hate meat",
        "Simple snack for simple fast food enjoyers",
        "Fried South Asian pastry with savory goodness",
        "Ice cream in a cup? Who would've thought",
        "Fancy something different?, Look no further",
        "A Malaysian classic",
        "Vegeterian? We have the noodle dish for you",
        "Savory western esque dish with fish, fries and some coleslaw on the side",
        "A savory banana snack found on the side of the road",
        "Just, water"
    };

    public int[] foodPrice = { 5, 11, 8, 12, 18, 4, 5, 8, 169, 12, 24, 22, 2, 1 };
    public int[] foodBarIncrease = { 15, 55, 60, 45, 40, 15, 20, 15, 95, 55, 60, 70, 15, 3 };

    //Food items
    public Food[] foodItems;

    //Panel Control
    public Button[] button;
    public TextMeshProUGUI value;

    //Quantity control
    public int purchaseQuantity;
    public TextMeshProUGUI quantityText;
    public TextMeshProUGUI priceText;
    public int selectedID;
    

    // Start is called before the first frame update
    void Start()
    {
        kb = InputSystem.GetDevice<Keyboard>();
        description = "What would you like to order?";
        InitiateRestraunt();

        for(int i = 0; i < 13; i++)
        {
            button[i].onClick.AddListener(() =>
            {
                OnPress(i);
                priceText.text = foodPrice[i].ToString();
                purchaseQuantity = 1;
                quantityText.text = purchaseQuantity.ToString();
            });
        }
    }

    public void OnPressUpBtn()
    {
        if (purchaseQuantity < 10)
        {
            purchaseQuantity += 1;
        }
        quantityText.text = purchaseQuantity.ToString();
        priceText.text = (purchaseQuantity * PurchaseCost).ToString();
    }

    public void OnPressDownBtn()
    {
        if (purchaseQuantity > 0)
        {
            purchaseQuantity -= 1;
        }
        quantityText.text = purchaseQuantity.ToString();
        priceText.text = (purchaseQuantity * PurchaseCost).ToString();
    }

    public void InitiateRestraunt()
    {
        for(int i = 0; i < 13; i++)
        {
            foodItems[i] = new Food(foodNames[i], foodDescriptions[i], foodPrice[i], foodBarIncrease[i]);
        }
    }

    public void OnPress(int ID)
    {
        this.selectedID = ID;
    }

    public void BuyBtn()
    {
        playerController.AddHunger(60);
        playerController.AddSanity(60);
    }

    public void AddToPlayerHunger(int index)
    {
        playerController.AddHunger(foodItems[index].foodBarIncrease);
    }

    // Update is called once per frame
    void Update()
    {
        if (kb.eKey.wasPressedThisFrame && isShowingOption)
        {
            basePanel.SetActive(true);
            Cursor.visible = true;
        }
    }
}

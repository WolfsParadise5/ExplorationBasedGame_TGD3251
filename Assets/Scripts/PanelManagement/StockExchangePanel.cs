using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class StockExchangePanel : BasePanelScript
{
    public double multiplier;
    public string[] stockNames = {
        "NUGX", "CKMT", "GXBK" , "FMWD", "TEAU"
    };
    public string[] stockCategories =
    {
        "E-Commerce", "Marketing", "Finance", "Logistics", "NGO"
    };
    public string[] stockValues;
    public int[] initialPrices;
    public string[] initialPriceChangeStr = { "0", "0", "0", "0", "0" };
    public float[] percentageDifference;
    public int ID;
    public int shares = 0;

    //UI Elements
    public TextMeshProUGUI stockName;
    public TextMeshProUGUI stockCategory;
    public TextMeshProUGUI overallProfit;
    public TextMeshProUGUI currentPrice;
    public TextMeshProUGUI sharesOwned;



    // Start is called before the first frame update
    void Start()
    {
        initialPrices = new int[] {2, 4, 3, 5, 7};
        kb = InputSystem.GetDevice<Keyboard>();
        for (int i = 0; i < initialPrices.Length; i++)
        {
            stockValues[i] = initialPrices[i].ToString();
        }
        Debug.Log(initialPrices.Length);
        stockName.text = stockNames[0];
        stockCategory.text = stockCategories[0];
        overallProfit.text = initialPriceChangeStr[0];
        currentPrice.text = initialPrices[0].ToString();
        sharesOwned.text = "0";

    }

    public void ifButtonSelected(int ID)
    {
        this.ID = ID;
        stockName.text = stockNames[ID];
        stockCategory.text = stockCategories[ID];
        currentPrice.text = stockValues[ID];
        sharesOwned.text = shares.ToString();
    }

    public void nextDayMultiplier()
    {
        //Change rng value
        float determineYesOrNo = Random.Range(0f, 1f);
        int determineValueOfIncrease = (int)Random.Range(1f, 4f);
        int totalDifference = initialPrices[4];
        
        for (int i = 0; i < 5; i++)
        {
            if (Random.Range(0f, 1f) >= 0.5f)
            {
                initialPriceChangeStr[i] = "+" + ((initialPrices[i] * determineValueOfIncrease) - initialPrices[i]).ToString();
            }
            else
            {
                initialPriceChangeStr[i] = "-" + ((initialPrices[i] * determineValueOfIncrease) - initialPrices[i]).ToString();
            }
            
        }
        

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

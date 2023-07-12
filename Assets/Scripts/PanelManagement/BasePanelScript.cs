using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public abstract class BasePanelScript : MonoBehaviour
{
    //Manage main panel
    public GameObject basePanel, knowMore;
    //Manage with player info
    public PlayerController playerController;

    //Panel contents
    public string description;
    public Keyboard kb;
    public TMP_Text title;
    public TMP_Text labelDescription;
    public string type = "Base";

    //Panel Control
    public Button buyBtn;

    //Job
    Job[] jobs;

    //Purchase info
    public TMP_Text BuyPrice;
    public TMP_Text BuyKarma;


    public int PurchaseCost;
    public int karmaBuy = 80;

    public AudioSource audioKb;
    public AudioSource audioMouse;

    //Boolean values
    public bool isShowingOption = false;

    public void OnClickPanel()
    {
        basePanel.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (kb.eKey.wasPressedThisFrame && isShowingOption)
        {
            GetComponent<AudioSource>().Play();
            buyBtn.onClick.RemoveListener(AponPurchase);
            buyBtn.onClick.AddListener(AponPurchase);
            
        }
            
    }

    public void AponPurchase()
    {
        if (playerController.commitPurchase(PurchaseCost, type))
        {
            playerController.IncreaseKarma(karmaBuy);
        }
        else
        {
            Debug.Log("Not enough budget to purchase!");
        }
    }

    public void setJobAvailable(int index, string description, int income)
    {
        jobs[index].isJobAvailable = true;
        jobs[index].jobDescription = description;
        jobs[index].jobPIncomePerMonth = income;
    }

    public void OnPressBackBtn()
    {   
        basePanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isShowingOption = true;
            knowMore.SetActive(true);
            knowMore.GetComponent<TMP_Text>().text = "Press E to know more";
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

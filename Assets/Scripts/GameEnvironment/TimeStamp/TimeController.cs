using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using static UnityEngine.Random;

public class TimeController : MonoBehaviour
{
    //Control time
    [SerializeField] private float dateTimeMultiplier;
    [SerializeField] private float startHour;
    [SerializeField] private string debugString;
    [SerializeField] private DateTime currentDateTime;
    private GameObject[] streetLights;
    [SerializeField] private TextMeshProUGUI timeStampText;
    public bool enableHyperInflation = false;
    public int totalDaysToInflation = 20;
    public int month;

    //Values
    public float minMultiplier = 0.5f;
    public float maxMultiplier = 1.2f;
    public float maxOffensiveMultipler = 20.0f;
    public float maxDefensiveMultipler = 0.2f;

    //Control sunlight
    [SerializeField] private Light directionalLight;
    [SerializeField] private StockExchangePanel stockExchange;

    [SerializeField] private PlayerController playerController;

    //Control ambient lighting


    // Start is called before the first frame update
    void Start()
    {
        currentDateTime = new DateTime(2013, 03, 31, 0, 0, 0) + TimeSpan.FromHours(startHour);
        streetLights = GameObject.FindGameObjectsWithTag("StreetLight");
        Cursor.visible = false;
        month = int.Parse(currentDateTime.ToString("MM"));
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
        UpdateLightDirection();
        UpdateStreetLight();
        Debug.Log(currentDateTime.ToString("MM"));

        if (currentDateTime.ToString("HH") == "23")
        {
            stockExchange.nextDayMultiplier();
        }

        if (int.Parse(currentDateTime.ToString("MM")) - month > 0) {
            playerController.AddIncome();
            month = int.Parse(currentDateTime.ToString("MM"));
        }
    }

    //Create custom hour passby
    private void UpdateTimeOfDay()
    {
        currentDateTime = currentDateTime.AddSeconds(Time.deltaTime * dateTimeMultiplier);
        debugString = currentDateTime.ToString("HH:mm");
        timeStampText.text = currentDateTime.ToString("dddd, dd MMMM yyyy hh: mm tt");
    }
    public void OnExit()
    {
        Application.Quit(0);
    }

    public void OnPressSave()
    {

    }


    public void AddHours(float hours)
    {
        Debug.Log("Sleep triggered");
        currentDateTime = currentDateTime.AddHours(hours);
    }

    private void UpdateLightDirection()
    {
        //Light comes around hour 7(420) = rotation reaches 0
        //Light goes out on hour 19(1140) = rotation reaches 180
        int currentMinute = int.Parse(currentDateTime.ToString("mm")) + (int.Parse(currentDateTime.ToString("HH"))  * 60);
        directionalLight.transform.rotation = Quaternion.AngleAxis((currentMinute * 0.25f - 105)%360, Vector3.right);
    }

    private void UpdateStreetLight()
    {
        int currentHour = int.Parse(currentDateTime.ToString("HH"));
        
        if (currentHour >= 18 || currentHour <= 6)
        {
            foreach (GameObject stretlight in streetLights)
            {
                stretlight.GetComponent<Light>().intensity = 6;
            }
        } else
        {
            foreach (GameObject stretlight in streetLights)
            {
                stretlight.GetComponent<Light>().intensity = 0;
            }
        }
    }

    public void UpdateDaysBeforeInflation()
    {
        totalDaysToInflation = Range(50,600);
    }

    public float UpdateMultiplierPrice()
    {
        if (!enableHyperInflation)
        {
            return Range(minMultiplier, maxMultiplier);
        } 
        else
        {
            return Range(maxDefensiveMultipler, maxOffensiveMultipler);
        }
    }

    
}

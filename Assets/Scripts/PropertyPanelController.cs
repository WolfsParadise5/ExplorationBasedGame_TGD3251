using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyPanelController : MonoBehaviour
{
    [SerializeField] private GameObject knowMorePanelProperty;
    [SerializeField] private GameObject knowMorePanelRestraunt;
    [SerializeField] private GameObject knowMorePanelShop;
    [SerializeField] private GameObject knowMorePanelExchange;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject cookPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPressBackCookBtn()
    {
        playerController.isPlayerTriggerMenu = false;
        cookPanel.SetActive(false);
        Cursor.visible = false;
    }

    public void OnPressBackPropertyBtn()
    {
        playerController.isPlayerTriggerMenu = false;
        knowMorePanelProperty.SetActive(false);
        Cursor.visible = false;
    }

    public void OnPressBackRestrauntBtn()
    {
        playerController.isPlayerTriggerMenu = false;
        knowMorePanelRestraunt.SetActive(false);
        Cursor.visible = false;
    }

    public void OnPressBackExchangeBtn()
    {
        playerController.isPlayerTriggerMenu = false;
        knowMorePanelExchange.SetActive(false);
        Cursor.visible = false;
    }

    public void OnPressBackShopBtn()
    {
        playerController.isPlayerTriggerMenu = false;
        knowMorePanelShop.SetActive(false);
        Cursor.visible = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyPanelController : MonoBehaviour
{
    [SerializeField] private GameObject knowMorePanelProperty;
    [SerializeField] private GameObject knowMorePanelRestraunt;
    [SerializeField] private GameObject knowMorePanelShop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPressBackPropertyBtn()
    {
        knowMorePanelProperty.SetActive(false);
    }

    public void OnPressBackRestrauntBtn()
    {
        knowMorePanelRestraunt.SetActive(false);
    }

    public void OnPressBackShopBtn()
    {
        knowMorePanelShop.SetActive(false);
    }
}

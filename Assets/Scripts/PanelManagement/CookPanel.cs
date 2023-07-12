using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CookPanel : BasePanelScript
{
    public GameObject cookPanel;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        kb = InputSystem.GetDevice<Keyboard>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void OnPressBack()
    {
        cookPanel.SetActive(false);
    }
}

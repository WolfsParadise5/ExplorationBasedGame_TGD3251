using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BankPanel : BasePanelScript
{
    // Start is called before the first frame update
    void Start()
    {
        kb = InputSystem.GetDevice<Keyboard>();
        description = "What do you plan to do today?";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JobPanel : BasePanelScript
{

    public int JobValue;

    private void Start()
    {
        kb = InputSystem.GetDevice<Keyboard>();
        type = "JobApply";
    }

    void Update()
    {
        if (kb.eKey.wasPressedThisFrame && isShowingOption)
        {
            Cursor.visible = true;
            basePanel.SetActive(true);
        }
    }
    public void OnPressAcceptJobBtn()
    {
        playerController.SetIncome(JobValue);
    }
    public void OnPressBackBtn()
    {
        Cursor.visible = false;
        basePanel.SetActive(false);
    }
}

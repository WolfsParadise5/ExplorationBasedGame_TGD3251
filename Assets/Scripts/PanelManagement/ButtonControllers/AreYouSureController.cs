using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreYouSureController : MonoBehaviour
{
    public GameObject exitPanel;
    public void OnPressYes()
    {
        SceneManager.LoadScene(0);
    }

    public void OnPressNo()
    {
        exitPanel.SetActive(false);
    }
}

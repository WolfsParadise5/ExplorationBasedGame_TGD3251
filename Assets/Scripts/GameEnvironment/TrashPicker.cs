using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrashPicker : MonoBehaviour
{
    [SerializeField] private GameObject textPrompt;
    [SerializeField] private GameObject trashGear;
    [SerializeField] private PlayerController player;
    Keyboard kb;
    
    private bool isCollide = false;
    

    // Start is called before the first frame update
    void Start()
    {
        kb = InputSystem.GetDevice<Keyboard>();
    }

    // Update is called once per frame
    void Update()
    {
        if (kb.eKey.wasPressedThisFrame && isCollide)
        {
            Debug.Log("Triggered this");
            player.IncreaseKarma(10);
            isCollide = false;
            textPrompt.SetActive(false);
            Destroy(trashGear);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Do something
            isCollide = true;
            textPrompt.SetActive(true);
            textPrompt.GetComponent<TMP_Text>().text = "Press E to discard trash";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Do something
            isCollide = false;
            textPrompt.SetActive(false);
        }
    }
}


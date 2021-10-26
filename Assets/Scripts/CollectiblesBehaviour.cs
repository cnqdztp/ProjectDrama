using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesBehaviour : MonoBehaviour
{
    private TextBehaviour textobj;

    public CollectibleSO itemInfo;

    public string pickupKeyPrompt;

    [SerializeField]private float elaspedTimeSincePlyaerEnter = 0;
    public float desiredTimeBeforePrompt;
    private bool calculateElaspedTime =false,textIsShown=false,playerStayInTrigger = false;
    private void Awake()
    {
        textobj = transform.GetChild(1).GetComponent<TextBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerStayInTrigger = true;
    }
    private void OnTriggerStay(Collider other)
    {
        calculateElaspedTime = true;
    }

    private void OnTriggerExit(Collider other)
    {
        calculateElaspedTime = false;
        playerStayInTrigger = false;
    }

    private void FixedUpdate()
    {
        if (calculateElaspedTime)
        {
            elaspedTimeSincePlyaerEnter += Time.deltaTime;
        }

        if (elaspedTimeSincePlyaerEnter > desiredTimeBeforePrompt && !textIsShown)
        {
            PromptForPickupKey();
            textIsShown = true;
        }

        if (playerStayInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            //TODO DO SOMETHING HERE AFTER PRESSING BUTTON
            gameObject.SetActive(false);
        }
        
    }

    private void PromptForPickupKey()
    {
        textobj.textToShow = pickupKeyPrompt;
        textobj.ShowText();
    }
    
    
}

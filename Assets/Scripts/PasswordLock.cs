using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PasswordLock : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private string password = "password";
    [SerializeField] private List<GameObject> openObjList;
    [SerializeField] private List<GameObject> closeObjList;
    
    private bool isPassed = false;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup.alpha = 0.0f;
        inputField.onSubmit.AddListener(OnSubmit);
    }

    private void OnSubmit(string inputStr)
    {
        if (inputStr == password)
        {
            foreach (var obj in openObjList)
               obj.SetActive(true); 
            foreach (var obj in closeObjList)
               obj.SetActive(false);
            inputField.text = "<color=green>Cleared!</color>";
            isPassed = true;
        }
        else
        {
            inputField.text = "<color=red>Failed!</color>"; 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isPassed)
            return;

        canvasGroup.alpha = 1.0f;
        inputField.ActivateInputField();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canvasGroup.alpha = 0.0f;
        inputField.DeactivateInputField();
    }
}

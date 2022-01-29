using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherboardControl : MonoBehaviour
{
    public static event Action OnGetMotherBoard;
    
    // Start is called before the first frame update
    public GameObject Canvas;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(ObjectControl.GetMotherboard == false)
        {
            Canvas.SetActive(true);
            ObjectControl.GetMotherboard = true;
            OnGetMotherBoard?.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryControl : MonoBehaviour
{
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
        if (ObjectControl.GetMemory == false)
        {
            Canvas.SetActive(true);
            ObjectControl.GetMemory = true;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenIntro : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Canvas;
    private bool isTriggered = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggered)
        {
            Canvas.SetActive(true);
            isTriggered = true;
        }
    }
}

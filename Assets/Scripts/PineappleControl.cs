using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineappleControl : MonoBehaviour
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
        Canvas.SetActive(true);
        ObjectControl.GetPineApple = true;
        Debug.Log(ObjectControl.GetPineApple);
    }
}

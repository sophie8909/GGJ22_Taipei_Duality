using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float JumpForce = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        JumpForce = 0.005F;
    }
}

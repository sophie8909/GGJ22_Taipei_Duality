using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;

    void Start() {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update() {
        if (Input.GetAxisRaw("Vertical") < 0f) {
            if(waitTime <=  0) {
                effector.rotationalOffset = 180f;
                waitTime = 0.1f;
            }
            else {
                waitTime -= Time.deltaTime;
            }
        }
        else if (Input.GetAxisRaw("Vertical") > 0f) {
            if (waitTime <= 0) {
                effector.rotationalOffset = 0f;
                waitTime = 0.1f;
            }
            else {
                waitTime -= Time.deltaTime;
            }
        }
    }
}

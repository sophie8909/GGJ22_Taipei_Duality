using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public static GameObject ChildBox;
    public static GameObject ChildFloor;

    private static void Active_ChildObject()
    {
        ChildSceneBox.SetActive(true);
        ChildSceneFloor.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("v"))
        {
            
        }
    }
}

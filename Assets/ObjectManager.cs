using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private bool age; // true for Adult, false for child
    public static GameObject ChildBox;
    public static GameObject ChildFloor;

    public static GameObject AdultFloor;

    public static void Active_ChildObject(){
        ChildBox.SetActive(true);
        ChildFloor.SetActive(true);
    }

    public static void Active_AdultObject()
    {
        AdultFloor.SetActive(true);
    }

    public static void Close_ChildObject(){
        ChildBox.SetActive(false);
        ChildFloor.SetActive(false);
    }

    public static void Close_AdultObject()
    {
        AdultFloor.SetActive(false);
    }

    // Start is called before the first frame update
    void Start(){
        age = true;
        Active_AdultObject();
        Close_ChildObject();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKey("v")){
            if(age){
                age = false;
                Active_ChildObject();
                Close_AdultObject();
            }
            else{
                age = true;
                Active_AdultObject();
                Close_ChildObject();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public bool age; // true for Adult, false for child
    public GameObject ChildBox;
    public GameObject ChildFloor;

    public GameObject AdultFloor;

    public void Active_ChildObject(){
        ChildBox.SetActive(true);
        ChildFloor.SetActive(true);
    }

    public void Active_AdultObject()
    {
        AdultFloor.SetActive(true);
    }

    public void Close_ChildObject(){
        ChildBox.SetActive(false);
        ChildFloor.SetActive(false);
    }

    public void Close_AdultObject()
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
        if(Input.GetKeyDown("v")){
            if(age){
                age = false;
                Close_AdultObject();
                Active_ChildObject();
            }
            else{
                age = true;
                Close_ChildObject();
                Active_AdultObject();
            }
        }
    }
}

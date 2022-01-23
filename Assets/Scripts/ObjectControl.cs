using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ObjectControl : MonoBehaviour
{
    public static bool age; // true for Adult, false for child

    public static bool GetPineApple; // check if get pineapple

    public static bool GetMotherboard; // check if get motherboard

    public static bool GetMemory;
    public GameObject ChildBox;
    public GameObject AdultBox;
    public GameObject ChildBear1;
    public GameObject AdultBear1;
    public GameObject ChildBear2;
    public GameObject AdultBear2;

    public GameObject Childrock1;
    public GameObject Adultrock1;
    public GameObject Childrock2;
    public GameObject Adultrock2;
    public GameObject Childbike;
    public GameObject Adultbike;

    public GameObject ChildBlackBoard;
    public GameObject AdultBlackBoard;


    private Vector3 getpos(GameObject obj)
    {
        Vector3 temp = obj.transform.position;
        return temp;
    }
    public void Active_ChildObject(){
        ChildBear1.SetActive(true);
        ChildBear1.transform.position = getpos(AdultBear1);
        ChildBear2.SetActive(true);
        ChildBear2.transform.position = getpos(AdultBear2);
        Childbike.SetActive(true);
        Childbike.transform.position = getpos(Adultbike);
        Childrock1.SetActive(true);
        Childrock1.transform.position = getpos(Adultrock1);
        Childrock2.SetActive(true);
        Childrock2.transform.position = getpos(Adultrock2);
        ChildBox.SetActive(true);
        ChildBox.transform.position = getpos(AdultBox);
        ChildBlackBoard.SetActive(true);
        ChildBlackBoard.transform.position = getpos(AdultBlackBoard);
    }

    public void Active_AdultObject()
    {
        
        AdultBear1.SetActive(true);
        AdultBear1.transform.position = getpos(ChildBear1);
        AdultBear2.SetActive(true);
        AdultBear2.transform.position = getpos(ChildBear2);
        Adultbike.SetActive(true);
        Adultbike.transform.position = getpos(Childbike);
        Adultrock1.SetActive(true);
        Adultrock1.transform.position = getpos(Childrock1);
        Adultrock2.SetActive(true);
        Adultrock2.transform.position = getpos(Childrock2);
        AdultBox.SetActive(true);
        AdultBox.transform.position = getpos(ChildBox);
        AdultBlackBoard.SetActive(true);
        AdultBlackBoard.transform.position = getpos(ChildBlackBoard);
    }

    public void Close_ChildObject(){
        ChildBear1.SetActive(false);
        ChildBear2.SetActive(false);
        Childbike.SetActive(false);
        Childrock1.SetActive(false);
        Childrock2.SetActive(false);
        ChildBox.SetActive(false);
        ChildBlackBoard.SetActive(false);
    }

    public void Close_AdultObject()
    {
        AdultBear1.SetActive(false);
        AdultBear2.SetActive(false);
        Adultbike.SetActive(false);
        Adultrock1.SetActive(false);
        Adultrock2.SetActive(false);
        AdultBox.SetActive(false);
        AdultBlackBoard.SetActive(false);
    }

    // Start is called before the first frame update
    void Start(){
        age = true;
        GetMotherboard = false;
        GetPineApple = false;
        Active_AdultObject();
        Close_ChildObject();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown("v")){
            if(age == true && GetPineApple == true ){
                age = false;
                Close_AdultObject();
                Active_ChildObject();
            }
            else if (age == false && GetMotherboard){
                age = true;
                Close_ChildObject();
                Active_AdultObject();
            }
        }
    }
}

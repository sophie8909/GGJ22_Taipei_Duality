using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSceneChecked : MonoBehaviour
{

    public static GameObject ChildSceneBox;
    public static GameObject ChildSceneFloor;

    public static void Active_ChildObject()
    {
        ChildSceneBox.SetActive(true);
        ChildSceneFloor.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.V))
        {
             SceneManager.LoadScene(1);
             ChildSceneChecked.Active_ChildObject();
        }
    }
}

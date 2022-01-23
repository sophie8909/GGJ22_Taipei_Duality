using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ActivityTrigger : MonoBehaviour
{
    [SerializeField] private List<GameObject> openObjList;
    [SerializeField] private List<GameObject> closeObjList;
    
    void Start()
    {
        Reset();
    }
    
    [Button]
    public void Reset()
    {
        foreach (var obj in openObjList)
            obj.SetActive(false); 
        foreach (var obj in closeObjList)
            obj.SetActive(true);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (var obj in openObjList)
            obj.SetActive(true); 
        foreach (var obj in closeObjList)
            obj.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> ListOfObject;

    public int amaunt = 20;

    private void Awake()
    {
        StartPoool();
    }


    public void StartPoool()
    {
        ListOfObject = new List<GameObject>();
        for (int i =0;i < amaunt; i++)
        {
            var obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            ListOfObject.Add(obj);

        }
        
    }
    public GameObject GetPoorObjects()
    {
        for (int i = 0; i < amaunt; i++)
        {
           
            if (!ListOfObject[i].activeInHierarchy)
            {
                return ListOfObject[i];

            }

        }
        return null;
    }
}


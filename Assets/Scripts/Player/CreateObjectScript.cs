using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjectScript : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 ForceDirection;
    public void SpawnItem()
    {
        var obj = Instantiate(prefab, transform);

        obj.GetComponent<Rigidbody>().AddForce(ForceDirection);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        { SpawnItem(); }
    }
}

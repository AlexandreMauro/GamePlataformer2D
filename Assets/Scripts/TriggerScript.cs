using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject fire;

    private void Awake()
    {
        fire.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        fire.SetActive(true);
        Debug.Log("Aperte E para descansar na fogueira");
    }

    private void OnTriggerExit(Collider other)
    {
        fire.SetActive(false);
    }


}

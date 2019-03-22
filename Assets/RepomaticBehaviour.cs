using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepomaticBehaviour : MonoBehaviour
{
    public GameObject lavasPrefab;
    public GameObject durumPrefab;
    private bool canStart = false;
    public Transform durumPoint;
    private GameObject durumInstance;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lavas")
        {
            canStart = true;
            durumInstance = Instantiate(durumPrefab, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (canStart)
        {
            durumInstance.transform.position = Vector3.MoveTowards(durumInstance.transform.position, durumPoint.position, .0002f);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canStart = false;
    }
    public void ThrowDurum()
    {
        durumInstance.AddComponent<Rigidbody>();
        durumInstance.GetComponent<Rigidbody>().AddForce(Vector3.up *3f, ForceMode.Impulse);
        durumInstance.GetComponent<Rigidbody>().AddForce(Vector3.left * 2f, ForceMode.Impulse);
    }
}

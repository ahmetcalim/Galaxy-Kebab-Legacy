using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepomaticBehaviour : MonoBehaviour
{
    public GameObject durumPrefab;
    private bool canStart = false;
    public Transform durumPoint;
    private GameObject durumInstance;
    public LavasGenerator lavasGenerator;
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
    public void ThrowDurum()
    {
        if (durumInstance != null)
        {

            if (durumInstance.transform.position.y >= durumPoint.position.y)
            {
                canStart = false;
                LavasGenerator.generatedLavasCount = 0;
                Destroy(lavasGenerator.currentLavas);
                durumInstance.AddComponent<Rigidbody>();
                durumInstance.GetComponent<Rigidbody>().AddForce(Vector3.up * 1.5f, ForceMode.Impulse);
                durumInstance.GetComponent<Rigidbody>().AddForce(Vector3.left * 1.5f, ForceMode.Impulse);
            }
        }
    }
}

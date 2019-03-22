using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavasGenerator : MonoBehaviour
{
    public GameObject lavasPrefab;
    public Transform lavasSpawnPoint;
    public static int generatedLavasCount;
    private GameObject currentLavas;
    public Transform arrivePoint;
    private bool canMove = false;
    public static bool lavasCanMove = true;
    public void GenerateLavas()
    {
        if (generatedLavasCount == 0)
        {
            generatedLavasCount++;
            currentLavas = Instantiate(lavasPrefab, lavasSpawnPoint.position, Quaternion.identity);
        }
    }
    public void SiparisTeslim()
    {
        if (currentLavas != null)
        {
            generatedLavasCount = 0;
            StartCoroutine(Move());
        }
    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(.01f);
       
            Debug.Log(lavasCanMove);
            currentLavas.transform.position = Vector3.MoveTowards(currentLavas.transform.position, arrivePoint.position, 0.001f);
            if (currentLavas.transform.position != arrivePoint.position)
            {
                StartCoroutine(Move());
            }
        
     
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonerBehaviour : MonoBehaviour
{
    public Transform endPoint;
    public float amount = 0f;
    private float amountMax = .8f;
    private float maxScaleX = 2f;
    public void UpdateScaleOfDoner()
    {
        if (DonerKnifeBehaviour.velocity <= amountMax)
        {

            endPoint.localPosition = new Vector3(endPoint.localPosition.x, endPoint.localPosition.y, DonerKnifeBehaviour.velocity);
            transform.localScale = new Vector3(transform.localScale.x, (maxScaleX - DonerKnifeBehaviour.distanceFromDoner) * 7f, transform.localScale.z);
        }
        else
        {
            if (GetComponent<Rigidbody>() == null)
            {
                DonerKnifeBehaviour.beginPointY = FindObjectOfType<DonerKnifeBehaviour>().transform.localPosition.y;
                DonerKnifeBehaviour.velocity = 0f;
                DonerKnifeBehaviour.currentDoner = Instantiate(FindObjectOfType<DonerController>().doner, new Vector3(FindObjectOfType<DonerKnifeBehaviour>().transform.localPosition.x, endPoint.position.y, FindObjectOfType<DonerKnifeBehaviour>().transform.localPosition.z) , transform.rotation);
                gameObject.AddComponent<Rigidbody>();
                gameObject.AddComponent<MeshCollider>();
                gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                gameObject.GetComponent<MeshCollider>().convex = true;
            }
        }
    }
}

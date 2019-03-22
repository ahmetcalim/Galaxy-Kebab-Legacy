using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiceContainerBehaviour : MonoBehaviour
{
    public enum SpiceType { salt, blackPepper, chiliPepper, mayonnaise, mustard, ketchup }
    public SpiceType spiceType;
    public float amountPerShake;
    public bool IsInHand { get; set; }
    public bool IsShaking { get; set; }
    public ParticleSystem particleSystem;
    public SkinnedMeshRenderer skinnedMesh;
    public void UseIngredient(float amount)
    {
        if (skinnedMesh.GetBlendShapeWeight(0) >= 10f)
        {
            Debug.Log(skinnedMesh.GetBlendShapeWeight(0));
            skinnedMesh.SetBlendShapeWeight(0, skinnedMesh.GetBlendShapeWeight(0) - amount);
        }
      
    }
    void Update()
    {
        if (IsInHand && IsShaking)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit))
            {
                if (hit.transform != null)
                {
                    IsShaking = false;
                    AddSpice();
                    UseIngredient(amountPerShake);
                }
                else
                {
                    Debug.Log("Dökülemiyor.");
                }
            }
        }
    }
    public void AddSpice()
    {
        
        
        switch (GetSpiceType())
        {
            case SpiceType.salt:
                Resource.salt -= amountPerShake;
                Debug.Log(Resource.salt);
                break;
            case SpiceType.blackPepper:
                Resource.blackPepper -= amountPerShake;
                Debug.Log(Resource.blackPepper);
                break;
            case SpiceType.chiliPepper:
                Resource.chiliPepper -= amountPerShake;
                Debug.Log(Resource.chiliPepper);
                break;
            case SpiceType.mayonnaise:
                Resource.mayonnaise -= amountPerShake;
                Debug.Log(Resource.mayonnaise);
                break;
            case SpiceType.mustard:
                Resource.mustard -= amountPerShake;
                Debug.Log(Resource.mustard);
                break;
            case SpiceType.ketchup:
                Resource.ketchup -= amountPerShake;
                Debug.Log(Resource.ketchup);
                break;
            default:
                break;
        }

        StartCoroutine(ActivateParticleForSeconds(1f));
    }
    private SpiceType GetSpiceType()
    {
        return spiceType;
    }
    IEnumerator ActivateParticleForSeconds(float sec)
    {
        particleSystem.Play();
        yield return new WaitForSeconds(sec);
        particleSystem.Stop();
    }
}

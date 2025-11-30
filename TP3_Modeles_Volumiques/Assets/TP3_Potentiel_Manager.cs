using NUnit.Framework.Internal;
using UnityEngine;

public class TP3_Potentiel_Manager : MonoBehaviour
{

    public int potentiel = 1;

    public bool reducePotentiel = false;

    private MeshRenderer mRenderer;
    private float elapsed = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(potentiel == 0) {
            if(mRenderer.enabled) { mRenderer.enabled = false; }
            GetComponent<BoxCollider>().enabled = false;
            reducePotentiel = false;
            elapsed = 0;
        }



        if (reducePotentiel)
        {
            elapsed += Time.deltaTime;
            if (elapsed > 0.5f)
            {
                potentiel--;
                elapsed = 0;
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<SphereCollider>())
        {
            reducePotentiel = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<SphereCollider>())
        {
            reducePotentiel = false;
        }
    }

}

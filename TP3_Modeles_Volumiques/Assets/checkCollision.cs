using UnityEngine;

public class checkCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isColliding = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        isColliding = true;

    }


    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }


    private void Update()
    {
        if (!isColliding)
        {
            Destroy(gameObject);
        }
    }


}

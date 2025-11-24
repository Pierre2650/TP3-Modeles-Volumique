using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TP3 : MonoBehaviour
{

    public GameObject Cube;
    public GameObject Sphere_Shape;
    public bool useColliders = false;
    private List<GameObject> OcTree = new List<GameObject>();
    public int deep = 2;
    public List<Vector3> spheres = new List<Vector3>();

    public float radius = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 newScale = Cube.transform.localScale ;
        Vector3 startPosReference = Cube.transform.position;
        divideCube(newScale, startPosReference, 0);
        Cube.GetComponent<MeshRenderer>().enabled = false;
    }

  
    private void divideCube(Vector3 newScale, Vector3 newStartPosition, int iteration)
    {


        newScale /= 2;

        if (iteration == deep) {


            for (int i = 0; i < 8; i += 4)
            {
                Vector3 spawnPosition = new Vector3(newStartPosition.x + newScale.x / 2, newStartPosition.y + newScale.y / 2, newStartPosition.z + newScale.z / 2);
                createVoxelShape(newScale, spawnPosition);

                spawnPosition = new Vector3(spawnPosition.x - newScale.x, spawnPosition.y, spawnPosition.z);
                createVoxelShape(newScale, spawnPosition);


                spawnPosition = new Vector3(newStartPosition.x + newScale.x / 2, newStartPosition.y + newScale.y / 2 - newScale.y, newStartPosition.z + newScale.z / 2);
                createVoxelShape(newScale, spawnPosition);
   

                spawnPosition = new Vector3(spawnPosition.x - newScale.x, spawnPosition.y, spawnPosition.z);
                createVoxelShape(newScale, spawnPosition);
   


                newScale = new Vector3(newScale.x, newScale.y, -newScale.z);

                
            }


        }
        else
        {
            

            //newStartPosition = new Vector3( newStartPosition.x + newScale.x / 2, newStartPosition.y + newScale.y / 2, newStartPosition.z + newScale.z / 2);

            

            for (int i = 0; i < 8; i += 4)
            {
                Vector3 spawnPosition = new Vector3(newStartPosition.x + newScale.x / 2, newStartPosition.y + newScale.y / 2, newStartPosition.z + newScale.z / 2);
                divideCube(newScale, spawnPosition, iteration + 1);

                spawnPosition = new Vector3(spawnPosition.x - newScale.x, spawnPosition.y, spawnPosition.z);
                divideCube(newScale, spawnPosition, iteration + 1);

                spawnPosition = new Vector3(newStartPosition.x + newScale.x / 2, newStartPosition.y + newScale.y / 2 - newScale.y, newStartPosition.z + newScale.z / 2);
                divideCube(newScale, spawnPosition, iteration + 1);

                spawnPosition = new Vector3(spawnPosition.x - newScale.x, spawnPosition.y, spawnPosition.z);
                divideCube(newScale, spawnPosition, iteration + 1);


                newScale = new Vector3(newScale.x, newScale.y, -newScale.z);


            }
        }


    }

    private void createVoxelShape(Vector3 scale, Vector3 position)
    {
        GameObject newCube = Instantiate(Cube, position, Quaternion.identity, Cube.transform.parent);
        newCube.transform.localScale = new Vector3(scale.x, scale.y, Mathf.Abs(scale.z));
        if (useColliders) { newCube.AddComponent<checkCollision>(); return; }

        bool destroy = true;

        foreach (Vector3 sph in spheres) {

            Vector3 sphereCenter = Cube.transform.TransformPoint(sph);
            Vector3 sphereSurfacePoint = sphereCenter + Vector3.forward * radius;

            Vector3 voxelPos = newCube.transform.position - sphereCenter;



            if (voxelPos.magnitude < radius)
            {
                destroy = false;
                break;
            

            }

        }

        if (destroy)
        {
            Destroy(newCube);
        }
        else
        {
            OcTree.Add(newCube);
        }




    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

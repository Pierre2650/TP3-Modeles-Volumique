using System.Collections.Generic;
using UnityEngine;

public class TP3 : MonoBehaviour
{

    public GameObject Cube;
    private List<GameObject[]> Tree = new List<GameObject[]>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        divideCube(Cube,0);


    }


    private void divideCube(GameObject aCube, int iteration)
    {
        if (iteration == 2) { return; }

        Vector3 newScale = aCube.transform.localScale / 2;
        Vector3 startPosReference = aCube.transform.position;
        GameObject[] Cubes = new GameObject[8];

        for (int i = 0; i < 8; i += 4)
        {
            Vector3 spawnPosition = new Vector3(startPosReference.x + newScale.x / 2, startPosReference.y + newScale.y / 2, startPosReference.z + newScale.z / 2);
            GameObject newCube = Instantiate(Cube, spawnPosition, Quaternion.identity, Cube.transform.parent);
            newCube.transform.localScale = newScale;
            Cubes[i] = newCube;
            divideCube(newCube,iteration+1);

            spawnPosition = new Vector3(spawnPosition.x - newScale.x, spawnPosition.y, spawnPosition.z);
            newCube = Instantiate(Cube, spawnPosition, Quaternion.identity, Cube.transform.parent);
            newCube.transform.localScale = newScale;
            Cubes[i+1] = newCube;
            divideCube(newCube, iteration + 1);

            spawnPosition = new Vector3(startPosReference.x + newScale.x / 2, startPosReference.y +  newScale.y / 2 - newScale.y, startPosReference.z + newScale.z / 2);
            newCube = Instantiate(Cube, spawnPosition, Quaternion.identity, Cube.transform.parent);
            newCube.transform.localScale = newScale;
            Cubes[i+2] = newCube;
            divideCube(newCube, iteration + 1);

            spawnPosition = new Vector3(spawnPosition.x - newScale.x, spawnPosition.y, spawnPosition.z);
            newCube = Instantiate(Cube, spawnPosition, Quaternion.identity, Cube.transform.parent);
            newCube.transform.localScale = newScale;
            Cubes[i+3] = newCube;
            divideCube(newCube, iteration + 1);

            newScale = new Vector3(newScale.x, newScale.y, -newScale.z);

            //iteration++; //temp
        }

        //Tree.Add(Cubes);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

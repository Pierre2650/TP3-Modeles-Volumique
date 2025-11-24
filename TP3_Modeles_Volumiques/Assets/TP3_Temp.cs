using System.Collections.Generic;
using UnityEngine;

public class TP3_Temp : MonoBehaviour
{
    public GameObject Cube;
    public int deep = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 newScale = Cube.transform.localScale / 2;
        Vector3 startPosReference = Cube.transform.position;
        divideCube2(Cube, 0);

    }

    private void divideCube2(GameObject aCube, int iteration)
    {




        if (iteration == deep)
        {
            return;
        }




        Vector3 newScale = aCube.transform.localScale / 2;
        Vector3 startPosReference = aCube.transform.position;
        GameObject[] Cubes = new GameObject[8];

        for (int i = 0; i < 8; i += 4)
        {
            Vector3 spawnPosition = new Vector3(startPosReference.x + newScale.x / 2, startPosReference.y + newScale.y / 2, startPosReference.z + newScale.z / 2);
            GameObject newCube = Instantiate(Cube, spawnPosition, Quaternion.identity, Cube.transform.parent);
            newCube.transform.localScale = newScale;
            Cubes[i] = newCube;
            divideCube2(newCube, iteration + 1);

            spawnPosition = new Vector3(spawnPosition.x - newScale.x, spawnPosition.y, spawnPosition.z);
            newCube = Instantiate(Cube, spawnPosition, Quaternion.identity, Cube.transform.parent);
            newCube.transform.localScale = newScale;
            Cubes[i + 1] = newCube;
            divideCube2(newCube, iteration + 1);

            spawnPosition = new Vector3(startPosReference.x + newScale.x / 2, startPosReference.y + newScale.y / 2 - newScale.y, startPosReference.z + newScale.z / 2);
            newCube = Instantiate(Cube, spawnPosition, Quaternion.identity, Cube.transform.parent);
            newCube.transform.localScale = newScale;
            Cubes[i + 2] = newCube;
            divideCube2(newCube, iteration + 1);

            spawnPosition = new Vector3(spawnPosition.x - newScale.x, spawnPosition.y, spawnPosition.z);
            newCube = Instantiate(Cube, spawnPosition, Quaternion.identity, Cube.transform.parent);
            newCube.transform.localScale = newScale;
            Cubes[i + 3] = newCube;
            divideCube2(newCube, iteration + 1);

            newScale = new Vector3(newScale.x, newScale.y, -newScale.z);

            //iteration++; //temp
        }

        //Tree.Add(Cubes);

    }
}


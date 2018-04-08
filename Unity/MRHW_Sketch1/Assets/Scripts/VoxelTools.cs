using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VoxelTools : MonoBehaviour
{

    private static GameObject cubePrefab;
    private static GameObject cubeContainer;
    private static int cubeCount = 0;
    private static List<GameObject> cubes;

    public static Color GetRandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        //make grey/sludge colors less likely
        for (int i = 0; i < Random.Range(1, 3); i++)
        {
            if (Random.Range(0, 10) > 1)
            {
                int a = Random.Range(0, 3);
                if (a == 0)
                    r = 0;
                if (a == 1)
                    g = 0;
                if (a == 2)
                    b = 0;
            }
        }

        return new Color(r, g, b);
    }

    public static GameObject MakeCube(float x, float y, float z)
    {
        return MakeCube(x, y, z, Color.red, 1);
    }

    public static GameObject MakeCube(float x, float y, float z, Color color)
    {
        return MakeCube(x, y, z, color, 1);
    }

    public static GameObject MakeCube(float x, float y, float z, Color color, float size)
    {
        return MakeCube(new Vector3(x, y, z), color, size);
    }

    private static GameObject GetCubePrefab()
    {
        if (cubePrefab == null)
            cubePrefab = Resources.Load("Cube") as GameObject;
        return cubePrefab;
    }

    public static GameObject MakeCube(Vector3 position, Color color, float size)
    {
        cubeCount++;
        if (cubeContainer == null)
        {
            cubeContainer = new GameObject("cube container");
            cubeContainer.transform.parent = GameObject.Find("ImageTarget").transform;
            cubes = new List<GameObject>();
        }

        GameObject cube = Instantiate(GetCubePrefab()) as GameObject;

        cubes.Add(cube);
        cube.transform.position = position/300;
        cube.transform.parent = cubeContainer.transform;
        cube.name = "cube " + cubeCount;

        cube.GetComponent<Renderer>().material.color = color;
        cube.transform.localScale = new Vector3(size, size, size);

        return cube;
    }

    public static void MakeAllCubesFall()
    {
        foreach (GameObject cube in cubes)
            if (cube.GetComponent<Rigidbody>() == null)
                cube.AddComponent<Rigidbody>();
    }
}
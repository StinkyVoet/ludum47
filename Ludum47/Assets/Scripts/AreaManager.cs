using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public GameObject[] areas;
    public Transform[] loadPoints;

    List<GameObject> gameAreas = new List<GameObject>();

    private void Start()
    {
        GenerateArea(0);
    }

    private void Update()
    {
        for (int i = 0; i < loadPoints.Length; i++)
        {
            if(transform.position.x > loadPoints[i].position.x)
            {
                UnloadArea(i);
                GenerateArea(i + 1);
            }
            if(transform.position.x <= loadPoints[i].position.x)
            {
                GenerateArea(i);
            }
        }
    }

    public void GenerateArea(int i)
    {
        if(gameAreas.Count < i + 1)
        {
            gameAreas.Add(Instantiate(areas[GetNumber(i)], new Vector3(0 + 20 * i, 0, 0), Quaternion.identity, loadPoints[0].parent.parent));
        }
        else
        {
            gameAreas[i].SetActive(true);
        }
        if (i + 1 > loadPoints.Length)
        {
            loadPoints[i] = Instantiate(loadPoints[i], new Vector2(10 + 20*i, 0), Quaternion.identity, loadPoints[0].parent);
        }
    }

    public void UnloadArea(int i)
    {
        gameAreas[i].SetActive(false);
    }

    private int GetNumber(int i)
    {
        while(i > areas.Length)
        {
            i -= areas.Length;
        }
        return i;
    }
}

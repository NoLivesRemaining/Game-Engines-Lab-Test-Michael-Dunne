using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightSpawner : MonoBehaviour
{
    public int numObjects = 10;
    public GameObject Lights;

    void Start()
    {

        Vector3 center = transform.position;
        for (int i = 0; i < numObjects; i++)
        {
            int a = i * 36;
            Vector3 pos = RandomCircle(center, 10.0f, a);
            Instantiate(Lights, pos, Quaternion.identity);
        }
    }
    Vector3 RandomCircle(Vector3 center, float radius, int a)
    {
        float ang = a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y +1;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
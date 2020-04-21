using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrive : MonoBehaviour
{
    int index;
    public List<GameObject> greenLights = new List<GameObject>();
    GameObject Target;
    float Speed = 5.0f;
    const float distance = 1.0f;
    bool HasTarget;

    private void Start()
    {
        HasTarget = false;

    }

    private void Update()
    {
        foreach (GameObject Greens in GameObject.FindGameObjectsWithTag("Green"))
        {
            greenLights.Add(Greens);
        }

        if (HasTarget == false)
        {
            FindTarget();
        }

        if (Target.tag == "Green")
        {
            transform.LookAt(Target.transform.position);
            if ((transform.position - Target.transform.position).magnitude > distance)
                transform.Translate(0.0f, 0.0f, Speed * Time.deltaTime);
        }
        else
        {
            HasTarget = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Target)
        {
            HasTarget = false;
        }
    }

    public void FindTarget()
    {
        index = Random.Range(0, greenLights.Count);
        Target = greenLights[index];
        HasTarget = true;
    }


}

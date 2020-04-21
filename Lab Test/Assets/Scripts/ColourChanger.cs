using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    public int State;
    public Material[] colour;
    Renderer render;
    private bool isCoroutineExecuting = false;

    private void Start()
    {
        State = Random.Range(1, 4);
        render = GetComponent<Renderer>();
        render.enabled = true;
        render.sharedMaterial = colour[State - 1];
    }

    private void Update()
    {
        ColourChange();
    }

    void ColourChange()
    {
        switch (State)
        {
            case 3:
                render.sharedMaterial = colour[2];
                gameObject.tag = "Not Green";
                StartCoroutine(ChangeColourRed());
                break;

            case 2:
                render.sharedMaterial = colour[1];
                gameObject.tag = "Not Green";
                StartCoroutine(ChangeColourYellow());
                break;

            case 1:
                render.sharedMaterial = colour[0];
                gameObject.tag = "Green";
                StartCoroutine(ChangeColourGreen());
                break;

            default:
                print("Wrong Int");
                break;
        }
    }

    public IEnumerator ChangeColourGreen()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(Random.Range(5, 10.0f));

        State = 2;
        isCoroutineExecuting = false;
    }

    public IEnumerator ChangeColourYellow()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(4);

        State = 3;
        isCoroutineExecuting = false;
    }

    public IEnumerator ChangeColourRed()
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(Random.Range(5, 10.0f));

        State = 1;
        isCoroutineExecuting = false;
    }
}

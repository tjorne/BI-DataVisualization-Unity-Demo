using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingAlgorithms : MonoBehaviour
{
    [SerializeField]
    private bool m_selectionSort;
    [SerializeField]
    private bool m_insertionSort;
    [SerializeField]
    private bool m_quickSort;
    [SerializeField]
    private bool m_bubbleSort;


    [SerializeField]
    int[] input;

    public GameObject dataCubePrefab;
    
    void Awake()
    {
        InitDataCubes();
        if (m_selectionSort)
            StartCoroutine(SelectionSort(400));
        else if (m_insertionSort)
            StartCoroutine(InsertionSort(400));
        else if (m_quickSort)
            StartCoroutine(QuickSort(400));
        else if (m_bubbleSort)
            StartCoroutine(BubbleSort(400));
    }
   
    private void InitDataCubes()
    {
        for (int i = 0; i < input.Length; i++)
        {
            var dataCube = Instantiate(dataCubePrefab, new Vector3(i + (0.25f * i), 0, 0), Quaternion.identity);
            dataCube.GetComponent<DataObject>().setValue(input[i] * 10);
            dataCube.transform.parent = transform;
        }
    }

    private void UpdateDataCubes()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        InitDataCubes();
    }

    IEnumerator SelectionSort(float ms)
    {
        int n = input.Length;

        int temp = 0;
        int smallest = 0;

        for (int i = 0; i < n - 1; i++)
        {

            smallest = i;
            for (int j = i + 1; j < n; j++)
            {
                if (input[j] < input[smallest])
                {
                    smallest = j;
                }
            }

            yield return new WaitForSeconds(ms / 1000);

            temp = input[smallest];
            input[smallest] = input[i];
            input[i] = temp;

            UpdateDataCubes();
        }
    }

    IEnumerator InsertionSort(float ms)
    {
        yield return new WaitForSeconds(ms / 1000);
    }
    
    IEnumerator QuickSort(float ms)
    {
        yield return new WaitForSeconds(ms / 1000);
    }

    IEnumerator BubbleSort(float ms)
    {
        bool changes = true;

        while(changes)
        {
            changes = false;
            for (int i = 0; i < input.Length-1; i++)
            {
                if (input[i] > input[i + 1])
                {
                    yield return new WaitForSeconds(ms / 1000);
                    changes = true;
                    var tmp = input[i];
                    input[i + 1] = input[i];
                    input[i] = tmp;
                }
            }
        }
    }
}

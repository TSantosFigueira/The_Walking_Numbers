using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolveOperations : MonoBehaviour {

    public int answer;

    [HideInInspector]
    public static List<GameObject> operations;

	void Start () {
        operations = new List<GameObject>();
	}
	
	void Update () {
        for (int i = 0; i < operations.Count; i++)
        {
            if(operations[i].GetComponent<MathOperationsManager>().answer == answer)
            {
                operations[i].gameObject.SetActive(false);
                operations.RemoveAt(i);
                answer = 0;
            }
        }
	}
}

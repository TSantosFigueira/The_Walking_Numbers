using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfacePool : MonoBehaviour {

    public GameObject poolObject;
    public int poolSize;
    public int maxPoolSize;

	void Start () {
        ObjectPoolingManager.Instance.CreatePool(poolObject, poolSize, maxPoolSize, transform);
	}
	
    // Retrieve object from pool example
	void Update () {
        //if (Input.GetButtonDown("Jump"))
        //{
        //    GameObject bullet = ObjectPoolingManager.Instance.GetObject("Cube");
        //    bullet.transform.position = transform.position;
        //    bullet.transform.rotation = Quaternion.identity;
        //    bullet.SetActive(true);
        //}
	}


}

/* 
 * Use the object pools to help reduce object instantiation time and performance 
 * with objects that are frequently created and used. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The object pool is a list of already instantiated game objects of the same type.
/// </summary>
public class ObjectsPool
{

    private List<GameObject> objectsPool; //!< List of pooled objects
    private GameObject originalObject;    //!< Reference to the original object to pool
    private int initialPoolSize;          //!< Default and initial pool size
    private int maxPoolSize;              //!< Maximum pool size
    private Transform parent;             //!< Parent reference to allocate instantiated objects

    /// <summary>
    /// Constructor for creating a new Object Pool.
    /// </summary>
    /// <param name="objectToPool">Game Object for this pool</param>
    /// <param name="initialPoolSize">Initial and default size of the pool.</param>
    /// <param name="maxPoolSize">Maximum number of objects this pool can contain.</param>
    /// <param name="parent">Where to instantiate game objects</param>
    public ObjectsPool(GameObject objectToPool, int initialPoolSize, int maxPoolSize, Transform parent)
    {
        objectsPool = new List<GameObject>();

        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject auxiliaryObject = GameObject.Instantiate(objectToPool, parent) as GameObject;
            auxiliaryObject.SetActive(false);
            objectsPool.Add(auxiliaryObject);
        }

        this.originalObject = objectToPool;
        this.initialPoolSize = initialPoolSize;
        this.maxPoolSize = maxPoolSize;
        this.parent = parent;
    }

    /// <summary>
    /// Returns an active object from the object pool without resetting any of its values.
    /// You will need to set its values and set it inactive again when you are done with it.
    /// </summary>
    /// <returns>Game Object of requested type if it is available, otherwise null.</returns>
    public GameObject GetObject()
    {
        for (int i = 0; i < objectsPool.Count; i++)
        {
            if (!objectsPool[i].activeSelf)
            {
                return objectsPool[i];
            }

            if (this.maxPoolSize > this.objectsPool.Count)
            {
                GameObject auxiliaryObject = GameObject.Instantiate(this.originalObject, this.parent) as GameObject;
                objectsPool.Add(auxiliaryObject);
                return auxiliaryObject;
            }
        }
        return null;
    }
}

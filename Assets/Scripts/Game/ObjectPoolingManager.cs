using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Manages pools
public class ObjectPoolingManager
{
    private static volatile ObjectPoolingManager instance; //!< the variable is declared to be volatile to ensure that assignment to the instance variable completes before the instance variable can be accessed.
    private Dictionary<string, ObjectsPool> objectPools;   //!< look up list of various object pools
    private static object syncRoot = new System.Object();  //!< object for locking

    //! Constructor for the class, ensures the object pool exists
    private ObjectPoolingManager()
    {
        this.objectPools = new Dictionary<string, ObjectsPool>();
    }

    //! Property for retrieving singleton
    public static ObjectPoolingManager Instance
    {
        get
        {
            if(instance == null)
            {
                lock (syncRoot)
                {
                    if(instance == null)
                    {
                        instance = new ObjectPoolingManager();
                    }
                }
            }
            return instance;
        }
    }

    //! Creates new object pool for the referenced object
    public bool CreatePool(GameObject objectToPool, int initialPoolSize, int maxPoolSize, Transform transform)
    {
        if (ObjectPoolingManager.Instance.objectPools.ContainsKey(objectToPool.name))
        {
            return false;
        }
        else
        {
            ObjectsPool nPool = new ObjectsPool(objectToPool, initialPoolSize, maxPoolSize, transform);
            ObjectPoolingManager.Instance.objectPools.Add(objectToPool.name, nPool);
            return true;
        }
    }

    //! Retrieves object from the pool
    public GameObject GetObject(string objName)
    {
        return ObjectPoolingManager.Instance.objectPools[objName].GetObject();
    }
}

	

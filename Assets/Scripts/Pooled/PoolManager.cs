using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] GameObject pooledPrefab;
    [SerializeField] private int size = 10;
    [SerializeField] private List<GameObject> pool;
    [SerializeField] private Transform spawnPool;

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(pooledPrefab);
            obj.transform.SetParent(spawnPool);
            obj.GetComponent<PooledObject>().Initialize(this);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }
    public GameObject Spawn()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                PooledObject pooledObject = obj.GetComponent<PooledObject>();
                pooledObject.ResetPooledObject();
               
                return obj;
            }
        }

        // If the pool is empty, instantiate a new object
        Debug.Log("Pool is empty, adding a new object to expand the pool.");
        GameObject newObj = Instantiate(pooledPrefab);
        newObj.GetComponent<PooledObject>().Initialize(this);
        pool.Add(newObj);
        return newObj;
    }

    public void Despawn(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int quantity;
}

public class Pool : MonoBehaviour
{
    public static Pool singletonPool;
    public List<PoolItem> items;
    public List<GameObject> pooledItens;

    private void Awake()
    {
        singletonPool = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledItens = new List<GameObject>();
        foreach(PoolItem item in items)
        {
            for(int i = 0; i < item.quantity; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItens.Add(obj);
            }
        }
    }


    public GameObject GetPoolItem(string tag)
    {
        for(int i = 0; i < pooledItens.Count; i++)
        {
            if (!pooledItens[i].activeInHierarchy && pooledItens[i].tag == tag)
            {
                return pooledItens[i];
            }
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

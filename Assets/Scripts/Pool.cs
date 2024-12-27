using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : ManualMonobehaviour
{
    
    public static Pool instance;
    private List<PoolObject> toPoolBuffer;
    private Dictionary<string, LinkedList<PoolObject>> pools;

    public override void Init()
    {
        instance = this;
        toPoolBuffer = new List<PoolObject>();
        pools = new Dictionary<string, LinkedList<PoolObject>>();
    }

    public struct PoolObject
    {
        public GameObject containdeObject;

        public PoolObject(GameObject _obj)
        {
            containdeObject = _obj;
        }
    }

    public static GameObject GetPool(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        if (!prefab)
        {
            Debug.LogError("Prefab is null");
        }
        var pools = instance.pools;
        if (!pools.ContainsKey(prefab.name.Replace("(Clone)", "")))
        {
            pools[prefab.name] = new LinkedList<PoolObject>();
        }
        PoolObject result;
        if (pools[prefab.name].Count > 0)
        {
            result = pools[prefab.name].First.Value;
            pools[prefab.name].RemoveFirst();
            result.containdeObject.transform.position = pos;
            result.containdeObject.transform.rotation = rot;
            result.containdeObject.SetActive(true);
            result.containdeObject.transform.parent = null;
            return result.containdeObject;
        }
        else
        {
            result.containdeObject = GameObject.Instantiate(prefab, pos, rot);
            result.containdeObject.name = prefab.name;
            result.containdeObject.transform.parent = null;
            return result.containdeObject;
        }
    }

    public static void ReturnToPool(PoolObject target)
    {
        instance.MoveToPool(target);
    }

    public static void ReturnToPool(GameObject target)
    {
        instance.MoveToPool(new PoolObject(target));
    }

    public static void ClearPool()
    {
        Dictionary<string, LinkedList<PoolObject>> pools = instance.pools;
        foreach (LinkedList<PoolObject> item in pools.Values)
            item.Clear();
        pools.Clear();
    }

    public void MoveToPool(PoolObject poolObj)
    {
        try
        {
            if (!poolObj.containdeObject)
            {
                Debug.LogWarning($"Warning: {poolObj.containdeObject.name} is destroyed/null!");
                return;
            }
            if (!pools.ContainsKey(poolObj.containdeObject.name.Replace("(Clone)", "")))
            {
                pools[poolObj.containdeObject.name] = new LinkedList<PoolObject>();
                Debug.LogWarning($"Return to pool non-pooled {poolObj.containdeObject.name}.");
                Destroy(poolObj.containdeObject);
            }
            else
            {
                pools[poolObj.containdeObject.name.Replace("(Clone)", "")].AddFirst(poolObj);
                poolObj.containdeObject.transform.SetParent(transform);
                poolObj.containdeObject.SetActive(false);
            }
        }
        catch (System.Exception E)
        {
            Debug.LogWarning($"Pooling error {poolObj.containdeObject.name}.");
            Debug.LogWarning(E);
            Destroy(poolObj.containdeObject);
        }
    }

}

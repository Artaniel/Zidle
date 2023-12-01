using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool instance;
    private List<PoolObject> toPoolBuffer;
    private Dictionary<string, LinkedList<PoolObject>> pools;

    void Awake()
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
            return result.containdeObject;
        }
        else
        {
            result.containdeObject = GameObject.Instantiate(prefab, pos, rot);
            result.containdeObject.name = prefab.name;
            return result.containdeObject;
        }
    }

    public static GameObject GetPool(GameObject prefab, Transform toTransform)
    {
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
        }
        else
        {
            result.containdeObject = Instantiate(prefab, toTransform);
            result.containdeObject.name = prefab.name;
        }
        Vector3 savedScale = result.containdeObject.transform.localScale;
        result.containdeObject.transform.SetParent(toTransform);
        result.containdeObject.transform.localPosition = Vector3.zero;
        result.containdeObject.transform.localRotation = Quaternion.identity;
        result.containdeObject.transform.localScale = savedScale;
        result.containdeObject.SetActive(true);
        return result.containdeObject;
    }

    public static void ReturnToPool(PoolObject target)
    {
        instance.toPoolBuffer.Add(target);
    }

    public static void ReturnToPool(GameObject target)
    {
        instance.toPoolBuffer.Add(new PoolObject(target));
    }

    public static void ClearPool()
    {
        Dictionary<string, LinkedList<PoolObject>> pools = instance.pools;
        foreach (LinkedList<PoolObject> item in pools.Values)
            item.Clear();
        pools.Clear();
    }

    void LateUpdate() // надо ли это вообще? выглядит как остатки от тамера
    {
        for (int i = 0; i < toPoolBuffer.Count; i++)
        {
            PoolObject poolItem = toPoolBuffer[i];
            MoveToPool(poolItem);
            toPoolBuffer.RemoveAt(i);                
        }
    }

    private void MoveToPool(PoolObject poolObj)
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
                poolObj.containdeObject.transform.SetParent(null);
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

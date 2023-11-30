using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTimer : MonoBehaviour
{
    public float time = 1f;
    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
            Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Vector4 borders;

    public Vector3 GetRandomPointInside() {
        return new Vector3(Random.Range(borders.x, borders.z) + transform.position.x,
            Random.Range(borders.y, borders.w) + transform.position.y,
            0);   
    }
}

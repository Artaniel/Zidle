using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Vector4 borders;

    public Vector3 GetRandomPointInside() {
        return transform.position + Random.Range(borders.x, borders.z) * transform.right + Random.Range(borders.y, borders.w) * transform.up;
    }
}

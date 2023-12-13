using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Vector4 borders;

    public Vector3 GetRandomPointInside() {
        return transform.position + Random.Range(borders.x, borders.z) * transform.right + Random.Range(borders.y, borders.w) * transform.up;
    }

    private void OnDrawGizmos()
    {
        Vector3 upLeftCorner = transform.position + new Vector3(borders.x, borders.y, 0);
        Vector3 upRightCorner = transform.position + new Vector3(borders.z, borders.y, 0);
        Vector3 downLeftCorner = transform.position + new Vector3(borders.x, borders.w, 0);
        Vector3 downRightCorner = transform.position + new Vector3(borders.z, borders.w, 0);
        Gizmos.DrawLine(upLeftCorner, upRightCorner);
        Gizmos.DrawLine(upRightCorner, downRightCorner);
        Gizmos.DrawLine(downRightCorner, downLeftCorner);
        Gizmos.DrawLine(downLeftCorner, upLeftCorner);
    }
}

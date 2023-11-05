using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    public float topY, botY, leftX, rightX;

    public Vector3 GetRandomPoint() {
        return new Vector3(Mathf.Lerp(leftX, rightX, Random.value), Mathf.Lerp(topY, botY, Random.value), 0);
    }

    private void OnDrawGizmos()
    {
        Vector3 cornerUL = new Vector3(leftX, topY, 0);
        Vector3 cornerUR = new Vector3(rightX, topY, 0);
        Vector3 cornerDL = new Vector3(leftX, botY, 0);
        Vector3 cornerDR = new Vector3(rightX, botY, 0);
        Gizmos.DrawLine(cornerUL, cornerUR);
        Gizmos.DrawLine(cornerUL, cornerDL);
        Gizmos.DrawLine(cornerDR, cornerUR);
        Gizmos.DrawLine(cornerDR, cornerDL);

    }
}

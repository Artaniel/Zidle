using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject buildingPrefab;
    public int buildingCount = 1;
    public Vector4 borders;
    private List<Building> buildingList;

    public void Init() {
        buildingList = new List<Building>();
        for (int i = 0; i < buildingCount; i++) {
            Building newBuilding = Instantiate(buildingPrefab).GetComponent<Building>();
            bool found = false;
            while (!found) { 
            newBuilding.transform.position = transform.position +
                Random.Range(borders.x - newBuilding.borders.x, borders.z - newBuilding.borders.z) * transform.right +
                Random.Range(borders.y - newBuilding.borders.y, borders.w - newBuilding.borders.w) * transform.up;
                found = true;
                foreach (Building building in buildingList)
                    if (IsIntersecting(building.transform.position, building.borders, newBuilding.transform.position, newBuilding.borders)) {
                        found = false;
                        break;
                    }
            }

            buildingList.Add(newBuilding);
        }
    }

    private bool IsIntersecting(Vector3 firstPostion, Vector4 firstBorders, Vector3 secondPosition, Vector4 secondBorders) {
        bool intersectingHorizontaly = !(
            firstPostion.x + firstBorders.x > secondPosition.x + secondBorders.z ||
            firstPostion.x + firstBorders.z < secondPosition.x + secondBorders.x);
        bool intersectingVerticaly = !(
            firstPostion.y + firstBorders.w > secondPosition.y + secondBorders.y ||
            firstPostion.y + firstBorders.y < secondPosition.y + secondBorders.w);
        return intersectingHorizontaly && intersectingVerticaly;
    }

    public Vector3 GetRandomIndors() {
        return buildingList[Random.Range(0, buildingList.Count)].GetRandomPointInside(); // or should it be -2? 
    }

    public Vector3 GetRandomPoint() {
        return new Vector3(Mathf.Lerp(borders.x, borders.z, Random.value), Mathf.Lerp(borders.y, borders.w, Random.value), 0);
    }

    private void OnDrawGizmos() {
        Vector3 upLeftCorner = new Vector3(borders.x, borders.y, 0);
        Vector3 upRightCorner = new Vector3(borders.z, borders.y, 0);
        Vector3 downLeftCorner = new Vector3(borders.x, borders.w, 0);
        Vector3 downRightCorner = new Vector3(borders.z, borders.w, 0);
        Gizmos.DrawLine(upLeftCorner, upRightCorner);
        Gizmos.DrawLine(upRightCorner, downRightCorner);
        Gizmos.DrawLine(downRightCorner, downLeftCorner);
        Gizmos.DrawLine(downLeftCorner, upLeftCorner);
    }
}

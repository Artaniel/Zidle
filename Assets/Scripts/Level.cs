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
            Building building = Instantiate(buildingPrefab).GetComponent<Building>();
            building.transform.position = transform.position +
                Random.Range(borders.x + building.borders.x, borders.z + building.borders.z) * transform.right +
                Random.Range(borders.y + building.borders.y, borders.w + building.borders.w) * transform.up;
            buildingList.Add(building);
        }
    }

    public Vector3 GetRandomIndors() {
        return buildingList[Random.Range(0, buildingList.Count - 1)].GetRandomPointInside(); // or should it be -2? 
    }

    public Vector3 GetRandomPoint() {
        return new Vector3(Mathf.Lerp(borders.x, borders.z, Random.value), Mathf.Lerp(borders.y, borders.w, Random.value), 0);
    }
}

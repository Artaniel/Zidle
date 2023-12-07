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
            //position
            buildingList.Add(building);
        }
    }
}

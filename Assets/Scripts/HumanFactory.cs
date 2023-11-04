using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanFactory : MonoBehaviour
{
    public GameObject humanPrefab;
    public float spawnNumber = 10;
    public List<Character> humanList;
    public Transform container;

    public void Init() {
        for (int i = 0; i < spawnNumber; i++) {
            Character human = Instantiate(humanPrefab, GetSpawnPosition(), Quaternion.identity, container).GetComponent<Character>();

        }
    }

    private Vector3 GetSpawnPosition() {
        return Vector3.zero; // temp, will need some kind of game field manager to get bordes
    }

}

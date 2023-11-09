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
        humanList = new List<Character>();
        for (int i = 0; i < spawnNumber; i++) {
            Character human = Instantiate(humanPrefab).GetComponent<Character>();
            human.transform.position = GetSpawnPosition();

            human.Init();
            humanList.Add(human);
        }
    }

    private Vector3 GetSpawnPosition() {
        return Boot.gameField.GetRandomPoint();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFactory : MonoBehaviour
{
    public List<Character> zombieList;
    public GameObject zombiePrefab;

    public void Init() {
        zombieList = new List<Character>();
    }

    public void SpawnNewZombie(Vector3 position) {
        Character zombie = Instantiate(zombiePrefab, position, Quaternion.identity).GetComponent<Character>();
        zombie.Init();
    }
}

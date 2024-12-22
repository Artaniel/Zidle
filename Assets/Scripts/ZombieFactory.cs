using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFactory : MonoBehaviour
{
    private Boot _boot;
    public List<Character> zombieList;
    public GameObject zombiePrefab;

    public void Init(Boot boot) {
        _boot = boot;
        zombieList = new List<Character>();
    }

    public void SpawnNewZombie(Vector3 position) {
        Character zombie = Instantiate(zombiePrefab, position, Quaternion.identity).GetComponent<Character>();
        zombie.Init();
    }
}

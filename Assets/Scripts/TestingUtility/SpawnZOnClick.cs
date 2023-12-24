using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnZOnClick : MonoBehaviour
{
    public GameObject prefab;

    private void Update() {
        if (Mouse.current.leftButton.wasPressedThisFrame) {
            if (Boot.economy.CanSpawn()) { 
                Boot.zombieFactory.SpawnNewZombie(Vector3.ProjectOnPlane(Camera.main.ScreenToWorldPoint(Mouse.current.position.value),Vector3.forward));
                Boot.economy.SpendEnergyOnZombie();
            }
        }
    }

}

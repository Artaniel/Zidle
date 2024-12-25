using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnZOnClick : ManualMonobehaviour
{
    public GameObject prefab;

    public override void ManualUpdate() {
        if (Mouse.current.leftButton.wasPressedThisFrame) {
            if (_boot.economy.CanSpawn()) {
                _boot.zombieFactory.SpawnNewZombie(Vector3.ProjectOnPlane(Camera.main.ScreenToWorldPoint(Mouse.current.position.value),Vector3.forward));
                _boot.economy.SpendEnergyOnZombie();
            }
        }
    }
}

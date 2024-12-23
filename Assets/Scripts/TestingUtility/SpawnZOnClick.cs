using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnZOnClick : MonoBehaviour
{
    private Boot _boot;
    public GameObject prefab;

    public void Init(Boot boot) {
        _boot = boot;
    }

    private void Update() {
        if (Mouse.current.leftButton.wasPressedThisFrame) {
            if (_boot.economy.CanSpawn()) {
                _boot.zombieFactory.SpawnNewZombie(Vector3.ProjectOnPlane(Camera.main.ScreenToWorldPoint(Mouse.current.position.value),Vector3.forward));
                _boot.economy.SpendEnergyOnZombie();
            }
        }
    }

}

using UnityEngine;
using TMPro;

public class VirusUI : ManualMonobehaviour
{
    private UI _ui;

    public TextMeshProUGUI infectionSpeedText;

    public void Init(Boot boot, UI ui) {
        Init(boot);
        _ui = ui;
    }

    public override void Init() {
        Refresh();
    }

    public void Refresh() {
        infectionSpeedText.text = $"Infection speed {_boot.economy.virus.incubationSpeed}";
    }

    public void XButtonPress() {
        gameObject.SetActive(false);
    }
}

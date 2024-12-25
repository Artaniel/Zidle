using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    private Boot _boot;
    public ShopUI shopUI;
    public TextMeshProUGUI uiResourcesText;

    public void Init(Boot boot) {
        _boot = boot;
        shopUI.Init(boot);
    }    
}

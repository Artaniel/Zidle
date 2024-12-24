using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private Boot _boot;
    public ShopUI shopUI;
    
    public void Init(Boot boot) {
        _boot = boot;
        shopUI.Init(boot);
    }    
}

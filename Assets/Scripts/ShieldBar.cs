using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider shieldBar;
    public VikingControl _vikingControl;

    //supposedly updates the shield bar, not working yet
    void Start()
    {
        _vikingControl = FindObjectOfType<VikingControl>();
        shieldBar = GetComponent<Slider>();
        shieldBar.maxValue = _vikingControl.maxShield;
        shieldBar.value = _vikingControl.maxShield;
    }

    public void SetHealth(int hp)
    {
        shieldBar.value = hp;
    }
}

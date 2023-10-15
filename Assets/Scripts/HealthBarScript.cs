using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] Slider silder_;
    // Start is called before the first frame update
    public void SetMaxHealth(int health) {
        silder_.maxValue = health;
        silder_.value = health;
    }

    public void SetHealth(int health) {
        silder_.value = health;
    }
}

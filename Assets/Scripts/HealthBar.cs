using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;

    [SerializeField] float healthDecreaseRate = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
            IncrementHealth(healthDecreaseRate);
    }

    public void IncrementHealth(float healthDecreaseRate)
    {
        slider.value -= healthDecreaseRate * Time.deltaTime;
    }
}

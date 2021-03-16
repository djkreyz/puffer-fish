using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    bool isPositionChanged;

    [SerializeField] float healthDecreaseRate = 0.1f;
    [SerializeField] float healthIncreaseRate = 10f;
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        isPositionChanged = FindObjectOfType<Bubble>().BubbleChangedPosition();
    }

    // Update is called once per frame
    void Update()
    {
        PositionChange();
    }

    public void DecreaseHealth(float healthDecreaseRate)
    {
        slider.value -= healthDecreaseRate * Time.deltaTime;
    }

    public void IncrementHealth(float healthIncreaseRate)
    {
        slider.value += healthIncreaseRate;
    }

    private void PositionChange()
    {
        if (!isPositionChanged)
        {
            DecreaseHealth(healthDecreaseRate);
        }
        else 
        {
            IncrementHealth(healthIncreaseRate);
            Debug.Log("I try to call it");
        }
    }
}

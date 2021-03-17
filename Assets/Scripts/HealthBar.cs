using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    bool isBubblePosChange;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        isBubblePosChange = FindObjectOfType<Bubble>().PlayerHealthScaling();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBubblePosChange == true)
        {
            Debug.Log("Hey");
            slider.value += 0.1f;
        }
    }
   
}

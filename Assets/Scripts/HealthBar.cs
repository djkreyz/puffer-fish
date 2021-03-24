using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    RectTransform rectTransform;
    bool bubble;
    float scaleX = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        bubble = FindObjectOfType<Bubble>().PlayerHealthScaling();
    }

    // Update is called once per frame
    void Update()
    {
        if (bubble == false)
        {
            scaleX -= 0.5f * Time.deltaTime;
            rectTransform.localScale = new Vector3 (scaleX,rectTransform.localScale.y,rectTransform.localScale.z);
        }
        if (bubble == true)
        {
            Debug.Log("Hey!");
            scaleX += 10;
            rectTransform.localScale = new Vector3(scaleX, rectTransform.localScale.y, rectTransform.localScale.z);
        }
    }
   
}

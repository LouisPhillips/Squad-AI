using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AIHealth : MonoBehaviour
{
    public GameObject ai;
    public Image fill;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fill_val = ai.GetComponent<AI>().health / 10;
        slider.value = fill_val;
    }
}

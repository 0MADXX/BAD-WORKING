using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private void OnEnable()
    {
        TIMEMANAGER.OnMinuteChanged += UpdateTime;
        TIMEMANAGER.OnHourChanged += UpdateTime;
    }


    private void OnDisable()
    {
        TIMEMANAGER.OnMinuteChanged -= UpdateTime;
        TIMEMANAGER.OnHourChanged -= UpdateTime;
    }

    private void UpdateTime()
    {
        timeText.text = $"{TIMEMANAGER.Hour:00}:{TIMEMANAGER.Minute:00}";
    }
}
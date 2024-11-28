using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class canvasScript : MonoBehaviour
{
    public Toggle[] checkboxes;
    public String[] randomTasks;
    // Start is called before the first frame update
    void Start()
    {
       foreach(Toggle checkbox in checkboxes) {
            Text textComponent = checkbox.GetComponentInChildren<Text>();
            TextMeshProUGUI tmpComponent = checkbox.GetComponentInChildren<TextMeshProUGUI>();

            if (textComponent != null) {
                textComponent.text = GetRandomTask();
            } else if (tmpComponent != null) {
                tmpComponent.text = GetRandomTask();
            }
       }
    }

    private string GetRandomTask() {
        if (randomTasks.Length == 0) return "No Task";
        int randomIndex = UnityEngine.Random.Range(0, randomTasks.Length);
        return randomTasks[randomIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
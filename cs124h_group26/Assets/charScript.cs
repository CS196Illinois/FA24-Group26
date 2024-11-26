using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class charScript : MonoBehaviour
{
    public Toggle CheckBox;
    public Vector3 targetPos;
    public float moveSpeed = 5f;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        CheckBox.onValueChanged.AddListener(OnToggleChanged);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void OnToggleChanged(bool isChecked) {
        if (isChecked) {
            transform.position = targetPos;
        }
    }
}

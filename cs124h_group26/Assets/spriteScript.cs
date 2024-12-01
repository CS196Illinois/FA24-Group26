using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class charScript : MonoBehaviour
{
    [System.Serializable]
    public class Task {
        public Toggle checkbox;
        public Vector3 position;
    }

    public Task[] tasks;

    public float moveSpeed;

    private Vector3 targetPosition;

    void Update () {
        bool anyChecked = false;

        foreach (Task task in tasks) {
            if (task.checkbox.isOn) {
                targetPosition = task.position;
                anyChecked = true;
            }
        }
        if (!anyChecked) {
            return;
        }
        MoveSpriteToTargetPos();
    }

    void MoveSpriteToTargetPos() {
        transform.position = Vector3.MoveTowards(transform.position, 
        targetPosition, moveSpeed * Time.deltaTime);
    }
    /* public Toggle CheckBox;
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
    } */
}


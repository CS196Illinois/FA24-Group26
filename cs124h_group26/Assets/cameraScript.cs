using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class cameraScript : MonoBehaviour
{
    /*public Toggle posToggle;
    public Vector3 newPos;
    public float watTime = 2f;
    public float moveDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        posToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isChecked) {
        if(isChecked) {
            StartCoroutine(MoveCameraAfterDelay());
        }
    }
    private IEnumerator MoveCameraAfterDelay() {
        yield return new WaitForSeconds(watTime);
        Vector3 startPos = transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < moveDuration){
            transform.position = Vector3.Lerp(startPos, newPos, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null; 
        }
        transform.position = newPos;
    }*/

    public Toggle[] checkboxes;
    public float moveSpeed = 7f;
    private Vector3[] targetPositions;
    int xPos = 300; 

    void Start() {
        targetPositions = new Vector3[checkboxes.Length];
        for(int i = 0; i < checkboxes.Length; i++) {
            if (i % 2 == 0) {
                targetPositions[i] = new Vector3(xPos + 200, 0, 500);
                int index = i;
                checkboxes[i].onValueChanged.AddListener(delegate { OnCheckboxChanged(index); });
            } else {
                targetPositions[i] = new Vector3(xPos - 400, 50, 500);
                int index = i;
                checkboxes[i].onValueChanged.AddListener(delegate { OnCheckboxChanged(index); });
            }
        }
    }

    void OnCheckboxChanged(int index) {
        if (checkboxes[index].isOn) {
            checkboxes[index].gameObject.SetActive(false);
            StartCoroutine(MoveCameraToTarget(targetPositions[index]));
        }
    }
    IEnumerator MoveCameraToTarget(Vector3 target) {
        Vector3 startPos = transform.position;
        float timeElapsed = 0;

        while (timeElapsed < 1f) {
            transform.position = Vector3.Lerp(startPos, target, timeElapsed);
            timeElapsed += Time.deltaTime * moveSpeed;
            yield return null;
        }
        transform.position = target;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
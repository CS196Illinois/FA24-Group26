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
    //array of checkboxes to loop through
    public Toggle[] checkboxes;
    public float moveSpeed;
    //array of positions linked to respective checkbox
    private Vector3[] targetPositions;
    int xPos = 300; 
    int zPos = 650; 

    void Start() {
        targetPositions = new Vector3[checkboxes.Length];
        //looping through checkboxes
        for(int i = 0; i < checkboxes.Length; i++) {
            //limiting to 4 treehouses, so once past the tasks
            //will just move back towards feild
            if (i < 3) {
                //even
                if (i % 2 == 0) {
                targetPositions[i] = new Vector3(xPos + 150, 0, zPos - 100);
                xPos = xPos + 150;
                zPos = zPos - 100;
                int index = i;
                checkboxes[i].onValueChanged.AddListener(delegate { OnCheckboxChanged(index); });
            } else {
                //odd
                targetPositions[i] = new Vector3(xPos - 350, 0, zPos - 100);
                xPos = xPos - 350;
                zPos = zPos - 100;
                int index = i;
                checkboxes[i].onValueChanged.AddListener(delegate { OnCheckboxChanged(index); });
            }
            } else {
                //final move to feild
                targetPositions[i] = new Vector3(xPos, 0, zPos - 200);
                zPos = zPos - 200;
            }
        }
    }

    //continuously checking if checkbox is checked
    void OnCheckboxChanged(int index) {
        if (checkboxes[index].isOn) {
            if (index == checkboxes.Length - 1) {
                checkboxes[index].gameObject.SetActive(false);
            } else {
                checkboxes[index].gameObject.SetActive(false);
                checkboxes[index + 1].gameObject.SetActive(true);
            }
            StartCoroutine(MoveCameraToTarget(targetPositions[index]));
        }
    }
    IEnumerator MoveCameraToTarget(Vector3 target) {
        Vector3 startPos = transform.position;
        float timeElapsed = 0;

        while (timeElapsed < 1f) {
            //lerp is frictional distance
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

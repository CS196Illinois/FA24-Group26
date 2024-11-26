using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class cameraScript : MonoBehaviour
{
    public Toggle posToggle;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

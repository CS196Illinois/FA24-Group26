using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hideScript : MonoBehaviour
{
    public GameObject sprite;
    public float hideDistance = 5.0f;
    public GameObject[] hideObjects;
    public GameObject show;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        float spriteCurrentPosition = sprite.transform.position.x;
        foreach (var hidingObject in hideObjects) {
            SpriteRenderer spriteRenderer 
            = hidingObject.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null) {
                if (sprite.transform.position.z < hidingObject.transform.position.z) {
                    //spriteRenderer.sortingOrder = -1;
                    hidingObject.SetActive(false);
                    spriteRenderer.color = new Color(1f,1f,1f,0f);
                } else {
                    spriteRenderer.sortingOrder = 0;
                    spriteRenderer.color = new Color(1f,1f,1f,1f);
                }
            }
        }
        if (sprite.transform.position.z > show.transform.position.z + 200) {
            show.SetActive(true);
        }
    }
}

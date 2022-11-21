using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaoMoHeadNormalAsCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaoMoHeadNormalAsCursor : MonoBehaviour
{
    bool isInPlayerControll = true;
    // Start is called before the first frame update
    void Start()
    {
        isInPlayerControll = true;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInPlayerControll)
            gameObject.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }

    public void MoveToCenter()
    {
        isInPlayerControll = false;
        gameObject.GetComponent<RectTransform>().position = new Vector3(Screen.width/2, Screen.height/2, 0);
    }
}

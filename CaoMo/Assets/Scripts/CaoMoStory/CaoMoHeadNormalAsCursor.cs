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
        {
            Cursor.visible = false;
            //gameObject.GetComponent<RectTransform>().position = Camera.main.WorldToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        }   
    }

    public void MoveToCenter()
    {
        isInPlayerControll = false;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, 0));
    }

    private void OnDestroy()
    {
        Cursor.visible = true;
    }
}

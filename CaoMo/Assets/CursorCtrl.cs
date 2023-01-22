using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorCtrl : MonoBehaviour
{
    public Sprite cursorSprite1;
    public Sprite cursorSprite2;
    public Image cursorImage;
    float time;
    // Start is called before the first frame update
    private void Awake()
    {
        time = 0;
        cursorImage = transform.GetComponent<Image>();
        cursorImage.sprite = cursorSprite1;
    }
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 1f)
        {
            cursorImage.sprite = (cursorImage.sprite == cursorSprite1) ? cursorSprite2 : cursorSprite1;
            time = 0;
        }
        gameObject.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        if(gameObject.activeSelf) Cursor.visible = false;
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        Cursor.visible = true;
    }
}

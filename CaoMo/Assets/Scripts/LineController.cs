using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LineController : MonoBehaviour
{
    public Vector2 anchorPoint;
    public bool isToRight = true;
    public GameObject lineText;
    public TextMeshProUGUI lineTextMesh;
    public string wordText;
    // Start is called before the first frame update
    void Awake()
    {
        // 先就右出对话框吧，左出以后再说
        //if (isToRight)
        //{
        //    transform.GetComponent<RectTransform>().pivot = new Vector2(0.1f, 0);
        //}
        //else
        //{
        //    transform.GetComponent<RectTransform>().pivot = new Vector2(0.9f, 0);
        //    transform.localScale = new Vector3(-1, 1, 1);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //if (isToRight)
        //{
        //    transform.GetComponent<RectTransform>().pivot = new Vector2(0.1f, 0);
        //}
        //else
        //{
        //    transform.GetComponent<RectTransform>().pivot = new Vector2(0.9f, 0);
        //    transform.localScale = new Vector3(-1, 1, 1);
        //}
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(1.3f * (70 +  lineTextMesh.GetRenderedValues().x), 1.3f * (70 + lineTextMesh.GetRenderedValues().y));
    }
    public void SetText(string t)
    {
        lineTextMesh.text = t;
        Refresh();
    }
    public void Refresh()
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(1.3f * (70 + lineTextMesh.GetRenderedValues().x), 1.3f * (70 + lineTextMesh.GetRenderedValues().y));
    }
}

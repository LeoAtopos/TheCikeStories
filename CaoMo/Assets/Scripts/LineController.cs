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
        Debug.Log(transform.GetComponent<RectTransform>().pivot);
        if (isToRight)
        {
            transform.GetComponent<RectTransform>().pivot = new Vector2(0.1f, 0);
        }
        else
        {
            transform.GetComponent<RectTransform>().pivot = new Vector2(0.9f, 0);
        }
        Debug.Log(transform.GetComponent<RectTransform>().pivot);
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(1.2f * (100 +  lineTextMesh.GetRenderedValues().x), 1.2f * (100 + lineTextMesh.GetRenderedValues().y));
    }
}

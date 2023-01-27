using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DioZiHandler111 : MonoBehaviour, IPointerClickHandler
{
    public HijackCtrl hC;
    public AudioSource dioSound;
    public void OnPointerClick(PointerEventData eventData)
    {
        hC.DaggerFlyAway();
        dioSound.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

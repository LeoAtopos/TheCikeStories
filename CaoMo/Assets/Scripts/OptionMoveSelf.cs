using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OptionMoveSelf : MonoBehaviour
{
    public float strength;
    public int vibrato;
    public float randomness;
    // Start is called before the first frame update
    void Start()
    {
        strength = 0.9f;
        vibrato = 1;
        randomness = 80;
        transform.DOShakePosition(600, strength, vibrato, randomness, false, false);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnEnable()
    {
        transform.DOShakePosition(600, strength, vibrato, randomness, false, false);
    }
    private void OnDisable()
    {
        transform.DOKill();
    }
}

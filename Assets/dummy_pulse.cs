using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummy_pulse : MonoBehaviour
{
    private float timer;

    public int Pulse { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Pulse = 90;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer>1) 
        { 
            timer -= 1;
            changePulse();
        }
    }

    private void changePulse()
    {
        Pulse = Pulse + UnityEngine.Random.Range(-3, 5);
        if (Pulse > 150)
            Pulse = 150;
        if (Pulse < 60)
            Pulse = 60;
        Debug.Log(Pulse);
    }
}

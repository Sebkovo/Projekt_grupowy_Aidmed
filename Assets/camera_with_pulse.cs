using Cinemachine;
using System;
using UnityEngine;

public class camera_with_pulse : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineTransposer transposer;
    private CinemachineBasicMultiChannelPerlin noise;
    private dummy_pulse pulse;
    private float timer;

    float pulseToDamping()
    {
        float p = pulse.Pulse;
        p = Math.Max(0,p - 80f);
        //Debug.Log(p / 90f * 3f);
        return p/90f * 2f;
        
    }

    void Awake()
    {
        pulse = GameObject.FindObjectOfType<dummy_pulse>();

        Camera.main.TryGetComponent<CinemachineBrain>(out var brain);
        if (brain == null)
        {
            Camera.main.gameObject.AddComponent<CinemachineBrain>();
        }
        
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        transposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        noise = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        noise.m_AmplitudeGain = pulseToDamping();
        //noise.m_FrequencyGain = pulseToDamping();
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            noise.m_AmplitudeGain = pulseToDamping();
            //noise.m_FrequencyGain = pulseToDamping();
            timer -= 1;
        }
    }
}

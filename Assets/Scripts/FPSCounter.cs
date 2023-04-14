using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public int AverageFPS { get; private set; }
    public int HighestFPS { get; private set; }
    public int LowestFPS { get; protected set; }

    [SerializeField] private int frameRange = 60;
    private int[] fpsBuffer;
    private int fpsBufferIndex;

    void Update()
    {
        if(fpsBuffer == null || frameRange != fpsBuffer.Length) {
            InitilizeBuffer();
        }

        UpdateBuffer();
        CalculateFPS();
    }

    private void InitilizeBuffer()
    {
        if(frameRange <= 0) {
            frameRange = 1;
        }

        fpsBuffer = new int[frameRange];
        fpsBufferIndex = 0;
    }

    private void UpdateBuffer()
    {
        fpsBuffer[fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);

        if(fpsBufferIndex >= frameRange) {
            fpsBufferIndex = 0;
        }
    }

    private void CalculateFPS()
    {
        var sum = 0;
        var lowest = int.MaxValue;
        var highest = 0;
        for (var i = 0; i < frameRange; i++) {
            var fps = fpsBuffer[i];
            sum += fps;

            if(fps > highest) {
                highest = fps;
            }
            if(fps < lowest) {
                lowest = fps;
            }
        }

        AverageFPS = sum / frameRange;
        HighestFPS = highest;
        LowestFPS = lowest;
    }
}

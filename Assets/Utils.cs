using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {

    public static float fBM(float x, float y, int oct, float persistance)
    {
        //对给定位置，在xy轴用频率和振幅计算oct次高度和，
        float total = 0;
        float frequency = 1;
        float amplitude = 1;
        float maxValue = 0;
        for (int i = 0; i < oct; i++)
        {
            total += Mathf.PerlinNoise(x * frequency, y * frequency) * amplitude;
            maxValue += amplitude;      //振幅累加，后需平均
            amplitude *= persistance;   //振幅衰减
            frequency *= 2;             //频率增强
        }

        return total / maxValue;
    }

    //区间映射,例如把[0,1]范围任意值映射到[0.1,0.3]范围。
    //  0|_______|1
    //0.1|__|0.3
    public static float Mapping(float value, float originalMin, float originalMax, float targetMin, float targetMax)
    {
        return (value - originalMin) * (targetMax - targetMin) / (originalMax - originalMin) + targetMin;
    }

    //Fisher-Yates Shuffle
    public static System.Random r = new System.Random();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = r.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

}

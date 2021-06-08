using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct MonsterAnimators
{
    public enum Color
    {
        White = 1, Red, Pink, Yellow, Lemon, Orange, Blue = 8, SkyBlue, Puple, Green = 12, Black = 16, Gray,
        Wine, Olive = 20, Navy = 24
    }

    public Color color;
    public AnimatorOverrideController[] animatorControllers;
}

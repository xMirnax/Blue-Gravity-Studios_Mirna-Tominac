using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Clothing", menuName = "Cloth")]
public class ClothItem : ItemData
{
    public Sprite sprite;
    public ClothPart clothPart;
}

public enum ClothPart
{
    Hood,
    LeftElbow,
    LeftShoulder,
    RightElbow,
    RightShoulder,
    Torso,
    LeftBoot,
    LeftLeg,
    RightBoot,
    RightLeg,
    Pelvis
}
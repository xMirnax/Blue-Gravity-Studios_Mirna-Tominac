using System.Collections.Generic;
using UnityEngine;

public class PlayerClothingManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _hood;
    [SerializeField] private SpriteRenderer _leftElbow;
    [SerializeField] private SpriteRenderer _leftShoulder;
    [SerializeField] private SpriteRenderer _rightElbow;
    [SerializeField] private SpriteRenderer _rightShoulder;
    [SerializeField] private SpriteRenderer _torso;
    [SerializeField] private SpriteRenderer _leftBoot;
    [SerializeField] private SpriteRenderer _leftLeg;
    [SerializeField] private SpriteRenderer _rightBoot;
    [SerializeField] private SpriteRenderer _rightLeg;
    [SerializeField] private SpriteRenderer _pelvis;
    
    private Dictionary<ClothPart, SpriteRenderer> _bodyPartRenderers;

    private void Awake()
    {
        _bodyPartRenderers = new Dictionary<ClothPart, SpriteRenderer>
        {
            { ClothPart.Hood, _hood },
            { ClothPart.LeftElbow, _leftElbow },
            { ClothPart.LeftShoulder, _leftShoulder },
            { ClothPart.RightElbow, _rightElbow },
            { ClothPart.RightShoulder, _rightShoulder },
            { ClothPart.Torso, _torso },
            { ClothPart.LeftBoot, _leftBoot },
            { ClothPart.LeftLeg, _leftLeg },
            { ClothPart.RightBoot, _rightBoot },
            { ClothPart.RightLeg, _rightLeg },
            { ClothPart.Pelvis, _pelvis }
        };
    }

    public void ChangeClothing(ClothItem newCloth)
    {
        if (newCloth == null)
        {
            Debug.LogWarning("New cloth item is null.");
            return;
        }
        
        if (_bodyPartRenderers.TryGetValue(newCloth.clothPart, out var bodyPartRenderer))
        {
            bodyPartRenderer.sprite = newCloth.sprite;
        }
        else
        {
            Debug.LogWarning($"ClothPart {newCloth.clothPart} is not mapped to any SpriteRenderer.");
        }
    }
}

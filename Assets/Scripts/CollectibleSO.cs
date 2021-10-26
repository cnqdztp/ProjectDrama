using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="SO/Collectible")]
public class CollectibleSO : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public string itemDescription;
}

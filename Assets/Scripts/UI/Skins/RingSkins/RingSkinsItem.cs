using UnityEngine;

[CreateAssetMenu(fileName = "SkinsRingItem", menuName = "GameShop/SkinsRingItem")]
public class RingSkinsItem : ShopItem
{
    [field: SerializeField] public SkinsRing SkinType { get; private set; }
}

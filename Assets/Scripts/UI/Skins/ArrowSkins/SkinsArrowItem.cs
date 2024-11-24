using UnityEngine;

[CreateAssetMenu(fileName = "SkinsArrowItem", menuName = "GameShop/SkinsArrowItem")]
public class SkinsArrowItem : ShopItem
{
    [field: SerializeField] public SkinsArrow SkinType { get; private set; }
}

using UnityEngine;

[CreateAssetMenu(fileName = "SkinsBackgroundItem", menuName = "GameShop/SkinsBackgroundItem")]
public class SkinsBackgroundItem : ShopItem
{
    [field: SerializeField] public SkinsBackground SkinType { get; private set; }
}

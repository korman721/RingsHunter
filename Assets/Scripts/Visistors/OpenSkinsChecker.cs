using System.Linq;

public class OpenSkinsChecker : IShopItemVisitor
{
    private IPersistentData _persistentData;
    public bool IsOpened { get; private set; }

    public OpenSkinsChecker(IPersistentData persistentData) => _persistentData = persistentData;

    public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

    public void Visit(SkinsArrowItem skinsArrowItem) => IsOpened = _persistentData.PlayerData.OpenArrowSkins.Contains(skinsArrowItem.SkinType);
    public void Visit(SkinsBackgroundItem backgroundSkinItem) => IsOpened = _persistentData.PlayerData.OpenBackgroundSkins.Contains(backgroundSkinItem.SkinType);
    public void Visit(RingSkinsItem ringSkinsItem) => IsOpened = _persistentData.PlayerData.OpenRingSkins.Contains(ringSkinsItem.SkinType);
}

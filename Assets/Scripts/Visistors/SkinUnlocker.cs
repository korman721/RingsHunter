public class SkinUnlocker : IShopItemVisitor
{
    private IPersistentData _persistentData;

    public SkinUnlocker(IPersistentData persistentData) => _persistentData = persistentData;

    public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

    public void Visit(SkinsArrowItem skinsArrowItem) => _persistentData.PlayerData.OpenArrowSkin(skinsArrowItem.SkinType);

    public void Visit(SkinsBackgroundItem backgroundSkinItem) => _persistentData.PlayerData.OpenBackgroundSkin(backgroundSkinItem.SkinType);

    public void Visit(RingSkinsItem ringSkinItem) => _persistentData.PlayerData.OpenRingSkin(ringSkinItem.SkinType);
}

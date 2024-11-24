public class SkinSelector : IShopItemVisitor
{
    private IPersistentData _persistentData;
    public SkinSelector(IPersistentData persistentData) => _persistentData = persistentData;

    public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

    public void Visit(SkinsArrowItem skinsArrowItem) => _persistentData.PlayerData.SelectedArrowSkin = skinsArrowItem.SkinType;
    public void Visit(SkinsBackgroundItem skinsBackgroundItem) => _persistentData.PlayerData.SelectedBackground = skinsBackgroundItem.SkinType;
    public void Visit(RingSkinsItem ringSkinsItem) => _persistentData.PlayerData.SelectedRing = ringSkinsItem.SkinType;

}

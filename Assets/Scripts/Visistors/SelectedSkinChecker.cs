public class SelectedSkinChecker : IShopItemVisitor
{
    private IPersistentData _persistentData;
    public bool IsSelected { get; private set; }
    public SelectedSkinChecker(IPersistentData persistentData) => _persistentData = persistentData;
    public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

    public void Visit(SkinsArrowItem skinsArrowItem) => IsSelected = _persistentData.PlayerData.SelectedArrowSkin == skinsArrowItem.SkinType;
    public void Visit(SkinsBackgroundItem backgroundSkinItem) => IsSelected = _persistentData.PlayerData.SelectedBackground == backgroundSkinItem.SkinType;
    public void Visit(RingSkinsItem ringSkinsItem) => IsSelected = _persistentData.PlayerData.SelectedRing == ringSkinsItem.SkinType;
}

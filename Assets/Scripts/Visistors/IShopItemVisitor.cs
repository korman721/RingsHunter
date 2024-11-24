public interface IShopItemVisitor
{
    void Visit(ShopItem shopItem);
    void Visit(SkinsArrowItem arrowSkinItem);
    void Visit(SkinsBackgroundItem backgroundSkinItem);
    void Visit(RingSkinsItem ringSkinItem);
}

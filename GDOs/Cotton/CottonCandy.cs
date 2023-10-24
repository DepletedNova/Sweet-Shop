using KitchenCandy.GDOs.Stick;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenCandy.GDOs.Cotton
{
    public class CottonCandy : CustomItemGroup
    {
        public override string UniqueNameID => "Cotton Candy";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.Small;
        public override Item DirtiesTo => GetCastedGDO<Item, CandyStick>();

        public override GameObject Prefab => GetPrefab("Cotton Candy");
        public override void OnRegister(ItemGroup GDO)
        {
            GDO.EatingTime = 1.5f;

            Prefab.ApplyMaterialToChild("Stick", "Plastic");
            Prefab.ApplyMaterialToChild("Candy", "Candy - Cotton");
        }
    }
}

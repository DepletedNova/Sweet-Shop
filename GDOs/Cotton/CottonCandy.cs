using KitchenCandy.GDOs.Box;
using KitchenCandy.GDOs.Stick;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenCandy.GDOs.Cotton
{
    public class CottonCandy : CustomItem
    {
        public override string UniqueNameID => "Cotton Candy";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Item DirtiesTo => GetCastedGDO<Item, CandyRubbish>();

        public override GameObject Prefab => GetPrefab("Cotton Candy");
        public override void OnRegister(Item GDO)
        {
            Prefab.ApplyMaterialToChild("Stick", "Plastic");
            Prefab.ApplyMaterialToChild("Candy", "Candy - Cotton");
        }
    }
}

using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenCandy.GDOs.Pops
{
    public class Lollipop : CustomItem
    {
        public override string UniqueNameID => "Lollipop";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override GameObject Prefab => GetPrefab("Lollipop");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Candy", "Candy - Blue", "Candy - Pink");
            prefab.ApplyMaterialToChild("Stick", "Plastic");
        }
    }
}

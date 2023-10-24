using KitchenCandy.GDOs.Candy;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Hard
{
    public class HardCandy : CustomItem
    {
        public override string UniqueNameID => "Hard Candy";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override GameObject Prefab => GetPrefab("Hard Candy");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Hard Candy", "Candy - Colorful");
        }
    }
}

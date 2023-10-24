using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenCandy.GDOs.Candy
{
    public class CooledCandyMix : CustomItem
    {
        public override string UniqueNameID => "Cooled Candy Mix";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override GameObject Prefab => GetPrefab("Cooled Candy Mix");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Bowl", "Metal - Brass");
            prefab.ApplyMaterialToChild("Candy", "Candy - Colorful");
        }
    }
}

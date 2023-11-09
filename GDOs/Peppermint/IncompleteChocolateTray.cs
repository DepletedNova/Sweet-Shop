using KitchenCandy.GDOs.Hard;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenCandy.GDOs.Peppermint
{
    internal class IncompleteChocolateTray : CustomItem
    {
        public override string UniqueNameID => "Incomplete Chocolate Tray";
        public override Item DisposesTo => GetCastedGDO<Item, HardCandyTray>();
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override GameObject Prefab => GetPrefab("Incomplete Chocolate Tray");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Tray", "Metal - Brass");
            prefab.ApplyMaterialToChildren("Chocolate", "Chocolate - Darker");
        }
    }
}

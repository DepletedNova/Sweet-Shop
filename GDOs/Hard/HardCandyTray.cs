using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenCandy.GDOs.Hard
{
    public class HardCandyTray : CustomItem
    {
        public override string UniqueNameID => "Hard Candy Tray";
        public override bool IsIndisposable => true;
        public override Appliance DedicatedProvider => GetCastedGDO<Appliance, HardCandyTraySource>();
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override GameObject Prefab => GetPrefab("Hard Candy Tray");
        public override void SetupPrefab(GameObject prefab) => prefab.ApplyMaterialToChild("Tray", "Metal - Brass");
    }
}

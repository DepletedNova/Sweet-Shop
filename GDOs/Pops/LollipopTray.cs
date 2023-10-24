using KitchenCandy.GDOs.Pops;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenCandy.GDOs.Pop
{
    public class LollipopTray : CustomItem
    {
        public override string UniqueNameID => "Lollipop Tray";
        public override bool IsIndisposable => true;
        public override Appliance DedicatedProvider => GetCastedGDO<Appliance, LollipopTraySource>();
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override GameObject Prefab => GetPrefab("Lollipop Tray");
        public override void SetupPrefab(GameObject prefab) => prefab.ApplyMaterialToChild("Tray", "Metal - Brass");
    }
}

using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenCandy.GDOs.Stick
{
    public class CandyStick : CustomItem
    {
        public override string UniqueNameID => "Candy Stick";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Appliance DedicatedProvider => GetCastedGDO<Appliance, CandyStickSource>();

        public override GameObject Prefab => GetPrefab("Stick");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Stick", "Plastic");
        }
    }
}

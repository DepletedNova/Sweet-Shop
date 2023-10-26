using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace KitchenCandy.GDOs.Box
{
    public class CandyRubbish : CustomItem
    {
        public override string UniqueNameID => "Candy Rubbish";
        public override Appliance DedicatedProvider => GetCastedGDO<Appliance, CandyBoxSource>();
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override GameObject Prefab => GetPrefab("Rubbish Wrappings");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Rubbish", "Candy - Blue");
        }
    }
}

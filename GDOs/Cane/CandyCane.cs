using KitchenCandy.GDOs.Stick;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Cane
{
    public class CandyCane : CustomItem
    {
        public override string UniqueNameID => "Candy Cane";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Appliance DedicatedProvider => GetCastedGDO<Appliance, CandyCaneSource>();
        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Process = GetGDO<Process>(ProcessReferences.Chop),
                Duration = 1f,
                Result = GetCastedGDO<Item, CrushedCandyCane>()
            }
        };

        public override GameObject Prefab => GetPrefab("Candy Cane");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Cane", "Plastic - White", "Plastic - Red");
        }
    }
}

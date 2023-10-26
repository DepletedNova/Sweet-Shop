using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace KitchenCandy.GDOs.Box
{
    public class EmptyCandyBox : CustomItem
    {
        public override string UniqueNameID => "Empty Candy Box";
        public override Appliance DedicatedProvider => GetCastedGDO<Appliance, CandyBoxSource>();
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Process = GetGDO<Process>(ProcessReferences.Knead),
                RequiresWrapper = true,
                Result = GetCastedGDO<Item, ClosedCandyBox>()
            }
        };

        public override GameObject Prefab => GetPrefab("Empty Candy Box");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Roll", "Candy - Pink", "Wood - Corkboard");
        }
    }
}

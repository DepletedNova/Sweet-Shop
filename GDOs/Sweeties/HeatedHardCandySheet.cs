using KitchenCandy.GDOs.Candy;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Hard
{
    public class HeatedHardCandySheet : CustomItemGroup
    {
        public override string UniqueNameID => "Heated Hard Candy Sheet";
        public override Item DisposesTo => GetCastedGDO<Item, HardCandyTray>();
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, HeatedCandyMix>(),
                    GetCastedGDO<Item, HardCandyTray>()
                },
                Max = 2,
                Min = 2
            }
        };

        public override List<Item.ItemProcess> Processes => new()
        {
            AutomaticItemProcess
        };

        public override Item.ItemProcess AutomaticItemProcess => new()
        {
            Process = GetGDO<Process>(ProcessReferences.SteepTea),
            Result = GetCastedGDO<Item, HardCandySheet>(),
            Duration = 6.5f
        };

        public override GameObject Prefab => GetPrefab("Heated Hard Candy Sheet");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Tray", "Metal");
            prefab.ApplyMaterialToChild("Hard Candy", "Candy - Heated");
        }
    }
}

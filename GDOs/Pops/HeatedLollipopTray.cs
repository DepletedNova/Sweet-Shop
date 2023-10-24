using Kitchen;
using KitchenCandy.GDOs.Candy;
using KitchenCandy.GDOs.Hard;
using KitchenCandy.GDOs.Pop;
using KitchenCandy.GDOs.Stick;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Pops
{
    public class HeatedLollipopTray : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "Heated Lollipop Tray";
        public override Item DisposesTo => GetCastedGDO<Item, LollipopTray>();
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, LollipopTray>(),
                    GetCastedGDO<Item, CandyStick>(),
                },
                IsMandatory = true,
                Max = 2,
                Min = 2
            },
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, HeatedCandyMix>(),
                },
                Max = 1,
                Min = 1
            }
        };

        public override List<Item.ItemProcess> Processes => new()
        {
            AutomaticItemProcess
        };

        public override Item.ItemProcess AutomaticItemProcess => new()
        {
            Process = GetGDO<Process>(ProcessReferences.SteepTea),
            Result = GetCastedGDO<Item, FilledLollipopTray>(),
            Duration = 10f
        };

        public override GameObject Prefab => GetPrefab("Heated Lollipop Tray");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Tray", "Metal - Brass");
            prefab.ApplyMaterialToChildren("Stick", "Plastic");
            prefab.ApplyMaterialToChildren("Candy", "Candy - Heated");

            prefab.TryAddComponent<ItemGroupView>().ComponentGroups = new()
            {
                new()
                {
                    Item = GetCastedGDO<Item, HeatedCandyMix>(),
                    Objects = new()
                    {
                        prefab.GetChild("Candy"),
                        prefab.GetChild("Candy (1)")
                    },
                    DrawAll = true
                }
            };
        }
    }
}

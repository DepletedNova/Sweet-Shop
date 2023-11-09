using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenCandy.GDOs.Hard;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Peppermint
{
    public class CoolingChocolateTray : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "Cooling Chocolate Tray";
        public override Item DisposesTo => GetCastedGDO<Item, HardCandyTray>();
        public override Appliance DedicatedProvider => GetCastedGDO<Appliance, HardCandyTraySource>();
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, HardCandyTray>(),
                    GetCastedGDO<Item, Ganache>(),
                },
                Max = 2,
                Min = 2,
                IsMandatory = true,
            },
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.ChocolateMelted)
                },
                Min = 1,
                Max = 1
            }
        };

        public override List<Item.ItemProcess> Processes => new()
        {
            AutomaticItemProcess
        };

        public override Item.ItemProcess AutomaticItemProcess => new()
        {
            Process = GetGDO<Process>(ProcessReferences.SteepTea),
            Result = GetCastedGDO<Item, IncompleteChocolateTray>(),
            Duration = 7.5f
        };

        public override GameObject Prefab => GetPrefab("Cooling Chocolate Tray");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Tray", "Metal - Brass");
            prefab.ApplyMaterialToChildren("Chocolate", "Chocolate Light");
            prefab.ApplyMaterialToChildren("Coating", "Chocolate - Darker");

            prefab.TryAddComponent<ItemGroupView>().ComponentGroups = new()
            {
                new()
                {
                    Item = GetGDO<Item>(ItemReferences.ChocolateMelted),
                    Objects = new()
                    {
                        prefab.GetChild("Coating (0)"),
                        prefab.GetChild("Coating (1)"),
                        prefab.GetChild("Coating (2)"),
                        prefab.GetChild("Coating (3)"),
                    },
                    DrawAll = true,
                }
            };
        }
    }
}

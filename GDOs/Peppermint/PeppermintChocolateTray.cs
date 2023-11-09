using Kitchen;
using KitchenCandy.GDOs.Cane;
using KitchenCandy.GDOs.Hard;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Peppermint
{
    public class PeppermintChocolateTray : CustomItemGroup
    {
        public override string UniqueNameID => "Peppermint Chocolate Tray";
        public override Item DisposesTo => GetCastedGDO<Item, HardCandyTray>();
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, IncompleteChocolateTray>(),
                    GetCastedGDO<Item, CrushedCandyCane>(),
                },
                Max = 2,
                Min = 2
            },
        };

        public override int SplitCount => 4;
        public override float SplitSpeed => 1.75f;
        public override Item SplitSubItem => GetCastedGDO<Item, PeppermintChocolate>();
        public override List<Item> SplitDepletedItems => new() { DisposesTo };

        public override GameObject Prefab => GetPrefab("Peppermint Chocolate Tray");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Tray", "Metal - Brass");

            for (int i = 0; i < 4; i++)
            {
                var child = prefab.GetChild($"Chocolate ({i})");
                child.ApplyMaterial("Chocolate - Darker");
                child.ApplyMaterialToChild("Peppermints", "Plastic - Red", "Plastic - White");
            }

            ReflectionUtils.GetField<ObjectsSplittableView>("Objects").SetValue(
                prefab.TryAddComponent<ObjectsSplittableView>(),
                new List<GameObject>()
            {
                prefab.GetChild("Chocolate (0)"),
                prefab.GetChild("Chocolate (1)"),
                prefab.GetChild("Chocolate (2)"),
                prefab.GetChild("Chocolate (3)")
            });
        }
    }
}

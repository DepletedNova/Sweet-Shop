using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenCandy.GDOs.Stick;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Caramel_Apple
{
    public class CaramelApple : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "Caramel Apple";
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.SideMedium;
        public override Item DirtiesTo => GetCastedGDO<Item, RubbishCandyStick>();
        public override Factor EatingTime => 2f;
        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, CandyStick>(),
                    GetGDO<Item>(ItemReferences.Apple),
                    GetCastedGDO<Item, Caramel>(),
                },
                Max = 3,
                Min = 3,
                IsMandatory = true,
            },
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.NutsChopped),
                },
                Max = 1,
                Min = 0
            }
        };

        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetGDO<Item>(ItemReferences.NutsChopped),
                Text = "Nu"
            }
        };

        public override GameObject Prefab => GetPrefab("Candy Apple");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Stick", "Plastic");
            prefab.ApplyMaterialToChild("Apple", "AppleRed");
            prefab.ApplyMaterialToChild("Caramel", "Caramel");

            prefab.TryAddComponent<ItemGroupView>().ComponentGroups = new()
            {
                new()
                {
                    Item = GetGDO<Item>(ItemReferences.NutsChopped),
                    GameObject = prefab.ApplyMaterialToChild("Nuts", "Cashew")
                }
            };
        }
    }
}

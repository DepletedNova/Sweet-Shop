using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Candy
{
    public class CandyMix : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "Candy Mix";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                IsMandatory = true,
                Items = new() { GetGDO<Item>(ItemReferences.Sugar) },
                Max = 1,
                Min = 1
            },
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.Water),
                    GetCastedGDO<Item, SyrupIngredient>()
                },
                Max = 2,
                Min = 2
            }
        };

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Process = GetGDO<Process>(ProcessReferences.Cook),
                Duration = 5f,
                Result = GetCastedGDO<Item, HeatedCandyMix>()
            }
        };

        public override GameObject Prefab => GetPrefab("Candy Mix");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Bowl", "Metal");
            prefab.ApplyMaterialToChild("Syrup", "Cooked Batter");
            prefab.ApplyMaterialToChild("Sugar", "Sugar");
            prefab.ApplyMaterialToChild("Water", "Water");

            prefab.TryAddComponent<ItemGroupView>().ComponentGroups = new()
            {
                new()
                {
                    Item = GetGDO<Item>(ItemReferences.Water),
                    GameObject = prefab.GetChild("Water")
                },
                new()
                {
                    Item = GetCastedGDO<Item, SyrupIngredient>(),
                    GameObject = prefab.GetChild("Syrup")
                }
            };
        }
    }
}

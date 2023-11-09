using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenCandy.GDOs.Box;
using KitchenCandy.GDOs.Candy;
using KitchenCandy.Systems;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using System.IO;
using Unity.Entities;
using UnityEngine;

namespace KitchenCandy.GDOs.Hard
{
    public class HardCandyDish : CustomDish
    {
        public override string UniqueNameID => "Hard Candy Dish";
        public override GameObject DisplayPrefab => GetPrefab("Candy - Display");
        public override GameObject IconPrefab => GetPrefab("Candy - Display");
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => true;
        public override bool IsAvailableAsLobbyOption => true;
        public override DishType Type => DishType.Base;
        public override bool RequiredNoDishItem => true;
        public override List<string> StartingNameSet => new()
        {
            "Chewy Delights",
            "Sugar Rush",
            "Toffee Temptations",
            "Candy Concoctions",
            "Simmering Sweets"
        };

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;

        public override List<Dish.MenuItem> ResultingMenuItems => new()
        {
            new()
            {
                Item = GetCastedGDO<ItemGroup, CandyBox>(),
                Phase = MenuPhase.Main,
                Weight = 1f
            }
        };
        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new()
        {
            new()
            {
                MenuItem = GetCastedGDO<ItemGroup, CandyBox>(),
                Ingredient = GetCastedGDO<Item, HardCandy>()
            }
        };

        public override HashSet<Process> RequiredProcesses => new()
        {
            GetGDO<Process>(ProcessReferences.Cook),
            GetGDO<Process>(ProcessReferences.Chop),
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            GetCastedGDO<Item, HardCandyTray>(),
            GetCastedGDO<Item, EmptyCandyBox>(),
            GetCastedGDO<Item, Syrup>(),
            GetGDO<Item>(ItemReferences.Water),
            GetGDO<Item>(ItemReferences.Sugar),
        };

        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Create Candy and place in tray. Let tray cool and then smash the candy into chunks. Portion chunks into wrapping then close wrapping and serve." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, CreateUnlockInfo("Sweeties", "Adds Sweeties as a main", "Candy :3"))
        };

        public override int Difficulty => 3;
        public override List<Dish> AlsoAddRecipes => new()
        {
            GetCastedGDO<Dish, CandyRecipe>()
        };

        public override void OnRegister(Dish gdo)
        {
            var wrapping = IconPrefab.GetChild("Wrapped");
            wrapping.ApplyMaterialToChildren("Pink", "Candy - Pink");
            wrapping.ApplyMaterialToChildren("Blue", "Candy - Blue");

            IconPrefab.ApplyMaterialToChild("Lollipop/Stick", "Plastic");
            IconPrefab.ApplyMaterialToChild("Lollipop/Candy", "Candy - Blue", "Candy - Pink");

            IconPrefab.ApplyMaterialToChild("Cotton Candy/Stick", "Plastic");
            IconPrefab.ApplyMaterialToChild("Cotton Candy/Candy", "Candy - Cotton");

            SweetiesReplaceBin.SweetiesID = gdo.ID;
        }
    }
}

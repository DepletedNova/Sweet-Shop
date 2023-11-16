using IngredientLib.Ingredient.Items;
using KitchenCandy.GDOs.Box;
using KitchenCandy.GDOs.Hard;
using KitchenCandy.GDOs.Pop;
using KitchenCandy.GDOs.Stick;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Pops
{
    public class LollipopDish : CustomDish
    {
        public override string UniqueNameID => "Lollipop Dish";
        public override GameObject DisplayPrefab => GetPrefab("Lollipop");
        public override GameObject IconPrefab => GetPrefab("Lollipop");
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => true;
        public override DishType Type => DishType.Extra;
        public override bool RequiredNoDishItem => true;

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;

        public override List<Unlock> HardcodedRequirements => new()
        {
            GetCastedGDO<Unlock, HardCandyDish>()
        };

        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new()
        {
            new()
            {
                MenuItem = GetCastedGDO<ItemGroup, CandyBox>(),
                Ingredient = GetCastedGDO<Item, Lollipop>()
            }
        };

        public override HashSet<Process> RequiredProcesses => new()
        {
            GetGDO<Process>(ProcessReferences.Cook)
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            GetCastedGDO<Item, LollipopTray>(),
            GetCastedGDO<Item, CandyStick>(),
            GetCastedGDO<Item, EmptyCandyBox>(),
            GetCastedGDO<Item, Syrup>(),
            GetGDO<Item>(ItemReferences.Water),
            GetGDO<Item>(ItemReferences.Sugar),
        };

        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Place sticks into lollipop tray. Create Candy and place in tray. Let tray tray cool and portion lollipops into wrapping then close wrapping and serve." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, CreateUnlockInfo("Lollipops", "Adds lollipops as a dessert", "Pops!"))
        };

        public override int Difficulty => 3;
    }
}

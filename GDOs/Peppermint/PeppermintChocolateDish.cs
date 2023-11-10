using IngredientLib.Ingredient.Items;
using KitchenCandy.GDOs.Box;
using KitchenCandy.GDOs.Cane;
using KitchenCandy.GDOs.Hard;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Peppermint
{
    public class PeppermintChocolateDish : CustomDish
    {
        public override string UniqueNameID => "Peppermint Chocolate Dish";
        public override GameObject DisplayPrefab => GetPrefab("Peppermint Chocolate");
        public override GameObject IconPrefab => GetPrefab("Peppermint Chocolate");
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => true;
        public override DishType Type => DishType.Main;
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
                Ingredient = GetCastedGDO<Item, PeppermintChocolate>()
            }
        };

        public override HashSet<Process> RequiredProcesses => new()
        {
            GetGDO<Process>(ProcessReferences.Cook),
            GetGDO<Process>(ProcessReferences.Chop)
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            GetCastedGDO<Item, CoolingChocolateTray>(),
            GetCastedGDO<Item, EmptyCandyBox>(),
            GetCastedGDO<Item, WhippingCream>(),
            GetCastedGDO<Item, CandyCane>(),
            GetGDO<Item>(ItemReferences.Chocolate),
        };

        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Melt chocolate, add heavy cream, and add to tray. Melt chocolate and add to tray. Chop up candy canes and add to tray after sufficiently cooled. " +
                "Portion, add and close wrapper and serve." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, CreateUnlockInfo("Peppermint Chocolate", "Adds peppermint chocolate as a main", "Like 3 Musketeers!"))
        };

        public override int Difficulty => 2;
    }
}

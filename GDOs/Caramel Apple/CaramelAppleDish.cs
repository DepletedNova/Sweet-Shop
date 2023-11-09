using KitchenCandy.GDOs.Hard;
using KitchenCandy.GDOs.Stick;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Caramel_Apple
{
    internal class CaramelAppleDish : CustomDish
    {
        public override string UniqueNameID => "Caramel Apple Dish";
        public override GameObject DisplayPrefab => GetPrefab("Caramel Apple");
        public override GameObject IconPrefab => GetPrefab("Caramel Apple");
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

        public override List<Dish.MenuItem> ResultingMenuItems => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, CaramelApple>(),
                Weight = 1,
                Phase = MenuPhase.Main
            }
        };

        public override HashSet<Process> RequiredProcesses => new()
        {
            GetGDO<Process>(ProcessReferences.Cook),
            GetGDO<Process>(ProcessReferences.Chop)
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            GetCastedGDO<Item, CandyStick>(),
            GetGDO<Item>(ItemReferences.Apple),
            GetGDO<Item>(ItemReferences.Sugar),
            GetGDO<Item>(ItemReferences.NutsIngredient),
        };

        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Add an apple to a stick. Heat up sugar and add to apple. Add once-chopped nuts if ordered." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, CreateUnlockInfo("Caramel Apple", "Adds Caramel Apple as a main", ""))
        };

        public override int Difficulty => 1;
    }
}

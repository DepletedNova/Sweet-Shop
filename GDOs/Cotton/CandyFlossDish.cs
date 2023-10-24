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

namespace KitchenCandy.GDOs.Cotton
{
    public class CandyFlossDish : CustomDish
    {
        public override string UniqueNameID => "Candy Floss Dish";
        public override GameObject DisplayPrefab => GetPrefab("Cotton Candy");
        public override GameObject IconPrefab => GetPrefab("Cotton Candy");
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => true;
        public override DishType Type => DishType.Main;
        public override bool RequiredNoDishItem => true;

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;

        public override List<Dish.MenuItem> ResultingMenuItems => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, CottonCandy>(),
                Phase = MenuPhase.Main,
                Weight = 1f
            }
        };

        public override List<Unlock> HardcodedRequirements => new()
        {
            GetCastedGDO<Unlock, HardCandyDish>()
        };

        public override HashSet<Process> RequiredProcesses => new()
        {
            GetGDO<Process>(ProcessReferences.Cook),
            GetCastedGDO<Process, CottonCandyProcess>()
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            GetCastedGDO<Item, HardCandyTray>(),
            GetCastedGDO<Item, CandyStick>(),
            GetCastedGDO<Item, Syrup>(),
            GetGDO<Item>(ItemReferences.Water),
            GetGDO<Item>(ItemReferences.Sugar),
        };

        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Create Hard Candy and add it to the Flosser (not wrapped). Add a stick to the Flosser as well and interact. Extract completed Candy Floss and serve." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, CreateUnlockInfo("Candy Floss", "Adds candy floss as a main", "Fluffy!"))
        };

        public override void OnRegister(Dish gdo)
        {
            gdo.Difficulty = 2;
        }
    }
}

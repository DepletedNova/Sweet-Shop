using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Candy
{
    public class CandyRecipe : CustomDish
    {
        public override string UniqueNameID => "Candy Recipe Only";
        public override GameObject DisplayPrefab => GetPrefab("Candy - Display");
        public override GameObject IconPrefab => GetPrefab("Candy - Display");
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => false;

        public override DishType Type => DishType.Base;

        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Add sugar, water, and syrup together and cook. Take off heat and use in other recipes. The heated candy mix must be used quickly otherwise it'll cool and become unusable." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, CreateUnlockInfo("Candy", "Candy Recipe", "How'd you get here?"))
        };

        public override void OnRegister(Dish gdo)
        {
            gdo.HideInfoPanel = true;
        }
    }
}

using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Box
{
    public class CandyBoxSource : CustomAppliance
    {
        public override string UniqueNameID => "Candy Box Source";
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            (Locale.English, CreateApplianceInfo("Candy Wrappings", "Provides wrappings for candy", new List<Appliance.Section>(), new()))
        };
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;

        public override List<IApplianceProperty> Properties => new()
        {
            GetUnlimitedCItemProvider(GetCustomGameDataObject<EmptyCandyBox>().ID)
        };

        public override GameObject Prefab => GetPrefab("Candy Box Source");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Frame", "Metal");

            var boxes = prefab.GetChild("Wrapping");
            boxes.ApplyMaterialToChild("Roll", "Candy - Pink", "Wood - Corkboard");
            boxes.ApplyMaterialToChild("Wrap", "Candy - Blue");
        }
    }
}

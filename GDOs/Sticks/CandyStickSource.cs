using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Stick
{
    public class CandyStickSource : CustomAppliance
    {
        public override string UniqueNameID => "Candy Stick Source";
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            (Locale.English, CreateApplianceInfo("Sticks", "Provides sticks for candy", new List<Appliance.Section>(), new()))
        };
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;

        public override List<IApplianceProperty> Properties => new()
        {
            GetUnlimitedCItemProvider(GetCustomGameDataObject<CandyStick>().ID)
        };

        public override GameObject Prefab => GetPrefab("Candy Stick Source");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Frame", "Metal");

            prefab.GetChild("Sticks").ApplyMaterialToChildren("Stick", "Plastic");
            prefab.ApplyMaterialToChild("Jar", "Painting - Blue 3", "Candy - Colorful");
        }
    }
}

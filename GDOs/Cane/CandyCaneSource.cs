using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace KitchenCandy.GDOs.Cane
{
    public class CandyCaneSource : CustomAppliance
    {
        public override string UniqueNameID => "Candy Cane Source";
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            (Locale.English, CreateApplianceInfo("Candy Canes", "Provides candy canes", new List<Appliance.Section>(), new()))
        };
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;

        public override List<IApplianceProperty> Properties => new()
        {
            GetUnlimitedCItemProvider(GetCustomGameDataObject<CandyCane>().ID)
        };

        public override GameObject Prefab => GetPrefab("Candy Cane Source");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Table", "Wood - Default");
            prefab.ApplyMaterialToChild("Cloth", "Cloth - Cheap");

            prefab.ApplyMaterialToChild("Holder", "Metal - Brass");
            prefab.ApplyMaterialToChildren("Cane", "Plastic - White", "Plastic - Red");
        }
    }
}

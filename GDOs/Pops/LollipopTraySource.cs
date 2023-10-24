using Kitchen;
using KitchenCandy.GDOs.Pop;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Pops
{
    public class LollipopTraySource : CustomAppliance
    {
        public override string UniqueNameID => "Lollipop Tray Source";
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            (Locale.English, CreateApplianceInfo("Lollipop Tray", "Provides a Lollipop Tray", new List<Appliance.Section>(), new()))
        };
        public override GameObject Prefab => GetPrefab("Lollipop Tray Source");
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override PriceTier PriceTier => PriceTier.Expensive;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;

        public override List<IApplianceProperty> Properties => new()
        {
            new CItemHolder(),
            GetCItemProvider(GetCustomGameDataObject<LollipopTray>().ID, 1, 1, false, false, true, false, false, true, false)
        };
        public override List<Appliance.ApplianceProcesses> Processes => new()
        {
            new()
            {
                Process = GetGDO<Process>(ProcessReferences.Chop),
                Speed = 0.7f,
                Validity = ProcessValidity.Generic
            },
            new()
            {
                Process = GetGDO<Process>(ProcessReferences.Knead),
                Speed = 0.75f,
                Validity = ProcessValidity.Generic
            },
        };

        public override void SetupPrefab(GameObject prefab)
        {
            var counter = prefab.GetChild("Counter");
            var paintedWood = MaterialUtils.GetMaterialArray("Wood 4 - Painted");
            var defaultWood = MaterialUtils.GetMaterialArray("Wood - Default");
            counter.ApplyMaterialToChild("Counter", paintedWood);
            counter.ApplyMaterialToChild("Counter Doors", paintedWood);
            counter.ApplyMaterialToChild("Counter Surface", defaultWood);
            counter.ApplyMaterialToChild("Counter Top", defaultWood);
            counter.ApplyMaterialToChild("Handles", "Knob");

            prefab.ApplyMaterialToChild("HoldPoint/Lollipop Tray/Tray", "Metal - Brass");

            var sourceView = prefab.TryAddComponent<LimitedItemSourceView>();
            sourceView.HeldItemPosition = prefab.TryAddComponent<HoldPointContainer>().HoldPoint = prefab.transform.Find("HoldPoint");
            ReflectionUtils.GetField<LimitedItemSourceView>("Items").SetValue(sourceView, new List<GameObject>()
            {
                prefab.GetChild("HoldPoint/Lollipop Tray")
            });

        }
    }
}

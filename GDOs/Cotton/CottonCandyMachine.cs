using JetBrains.Annotations;
using Kitchen;
using KitchenCandy.GDOs.Hard;
using KitchenCandy.GDOs.Pops;
using KitchenCandy.GDOs.Stick;
using KitchenCandy.View;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Cotton
{
    public class CottonCandyMachine : CustomAppliance
    {
        public override string UniqueNameID => "Cotton Candy Machine";
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            (Locale.English, CreateApplianceInfo("Candy Flosser", "I don't think that's what it's called", new List<Appliance.Section>(), new()))
        };
        public override List<Process> RequiresProcessForShop => new() { GetCastedGDO<Process, CottonCandyProcess>() };
        public override bool IsPurchasable => true;
        public override PriceTier PriceTier => PriceTier.Medium;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking;

        public override List<Appliance.ApplianceProcesses> Processes => new() { new() { Process = GetCastedGDO<Process, CottonCandyProcess>() } };
        public override List<Appliance> Upgrades => new() { GetCastedGDO<Appliance, AutoFlosser>() };

        public override List<IApplianceProperty> Properties => new()
        {
            new CItemHolder(),
            new CItemHolderPreventMergeIntoHeld(),
            new CTakesDuration
            {
                Mode = InteractionMode.Items,
                Manual = true,
                Total = 4f,
                PreserveProgress = true,
                IsLocked = true
            },
            new CCottonCandyMachine
            {
                InputCandyID = GetCustomGameDataObject<HardCandy>().ID,
                InputStickID = GetCustomGameDataObject<CandyStick>().ID,
                OutputID = GetCustomGameDataObject<CottonCandy>().ID,
                ProcessID = GetCustomGameDataObject<CottonCandyProcess>().ID
            }
        };

        public override GameObject Prefab => GetPrefab("Cotton Candy Machine");
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

            prefab.ApplyMaterialToChild("Machine", "Plastic - Blue", "Metal", "Hob Black");
            var indicator = prefab.ApplyMaterialToChild("Indicator", "Indicator Light");
            var candy = prefab.ApplyMaterialToChild("Spinner/Candy", "Candy - Cotton");
            var stick = prefab.ApplyMaterialToChild("Spinner/Stick", "Plastic");
            var holdPoint = prefab.transform.Find("HoldPoint");

            var view = prefab.TryAddComponent<CottonCandyView>();

            view.IndicatorRenderer = indicator.GetComponent<MeshRenderer>();
            view.ActiveIndicator = MaterialUtils.GetExistingMaterial("Indicator Light On");
            view.InactiveIndicator = MaterialUtils.GetExistingMaterial("Indicator Light");

            view.Spinner = prefab.GetChild("Spinner").transform;
            view.Candy = candy;
            view.Stick = stick;
            view.HoldPoint = holdPoint.gameObject;

            prefab.TryAddComponent<HoldPointContainer>().HoldPoint = holdPoint;
        }
    }
}

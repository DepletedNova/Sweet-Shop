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
    public class AutoFlosser : CustomAppliance
    {
        public override string UniqueNameID => "Auto Flosser";
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            (Locale.English, CreateApplianceInfo("Auto Flosser", "This can't be a real word", new List<Appliance.Section>() { new() { 
                    Title = "<sprite name=\"upgrade\" color=#A8FF1E> Automated", 
                    Description = "Performs <sprite name=\"cotton_candy_0\"> <color=#ff1111>33%</color> slower automatically" } }, new()))
        };
        public override List<Process> RequiresProcessForShop => new() { GetCastedGDO<Process, CottonCandyProcess>() };
        public override bool IsPurchasableAsUpgrade => true;
        public override PriceTier PriceTier => PriceTier.Expensive;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Automation;

        public override List<Appliance.ApplianceProcesses> Processes => new() { new() { Process = GetCastedGDO<Process, CottonCandyProcess>() } };

        public override List<IApplianceProperty> Properties => new()
        {
            new CItemHolder(),
            new CItemHolderPreventMergeIntoHeld(),
            new CTakesDuration
            {
                Mode = InteractionMode.Items,
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

        public override GameObject Prefab => GetPrefab("Auto Flosser");
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

            prefab.ApplyMaterialToChild("Machine", "Plastic - Red", "Metal", "Hob Black");
            prefab.ApplyMaterialToChild("Rail", "Metal Dark");
            prefab.ApplyMaterialToChild("Spinner/Holder", "Metal Dark");
            var candy = prefab.ApplyMaterialToChild("Spinner/Candy", "Candy - Cotton");
            var stick = prefab.ApplyMaterialToChild("Spinner/Stick", "Plastic");
            var holdPoint = prefab.transform.Find("HoldPoint");

            var view = prefab.TryAddComponent<CottonCandyView>();

            view.HardCandy = prefab.ApplyMaterialToChild("Candy", "Candy - Colorful");

            view.Spinner = prefab.GetChild("Spinner").transform;
            view.Candy = candy;
            view.Stick = stick;
            view.HoldPoint = holdPoint.gameObject;

            view.MaxAcceleration = 200f;

            prefab.TryAddComponent<HoldPointContainer>().HoldPoint = holdPoint;
        }
    }
}

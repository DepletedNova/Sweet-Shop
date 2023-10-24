using KitchenCandy.GDOs.Candy;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Hard
{
    public class HardCandySheet : CustomItem
    {
        public override string UniqueNameID => "Hard Candy Sheet";
        public override Item DisposesTo => GetCastedGDO<Item, HardCandyTray>();
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Process = GetGDO<Process>(ProcessReferences.Chop),
                Result = GetCastedGDO<Item, CrackedHardCandySheet>(),
                Duration = 2f
            }
        };

        public override GameObject Prefab => GetPrefab("Hard Candy Sheet");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Tray", "Metal - Brass");
            prefab.ApplyMaterialToChild("Hard Candy", "Candy - Colorful");
        }
    }
}

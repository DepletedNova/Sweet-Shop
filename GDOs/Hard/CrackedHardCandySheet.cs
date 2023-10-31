using Kitchen;
using KitchenCandy.GDOs.Candy;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Hard
{
    public class CrackedHardCandySheet : CustomItem
    {
        public override string UniqueNameID => "Cracked Hard Candy Sheet";
        public override Item DisposesTo => GetCastedGDO<Item, HardCandyTray>();
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override int SplitCount => 4;
        public override float SplitSpeed => 2f;
        public override Item SplitSubItem => GetCastedGDO<Item, HardCandy>();
        public override List<Item> SplitDepletedItems => new() { DisposesTo };

        public override GameObject Prefab => GetPrefab("Cracked Hard Candy Sheet");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Tray", "Metal - Brass");

            prefab.ApplyMaterialToChildren("Candy", "Candy - Colorful");

            ReflectionUtils.GetField<ObjectsSplittableView>("Objects").SetValue(
                prefab.TryAddComponent<ObjectsSplittableView>(), 
                new List<GameObject>()
            {
                prefab.GetChild("Candy (0)"),
                prefab.GetChild("Candy (1)"),
                prefab.GetChild("Candy (2)"),
                prefab.GetChild("Candy (3)")
            });
        }
    }
}

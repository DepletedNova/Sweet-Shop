using Kitchen;
using KitchenCandy.GDOs.Hard;
using KitchenCandy.GDOs.Pop;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Pops
{
    public class FilledLollipopTray : CustomItem
    {
        public override string UniqueNameID => "Filled Lollipop Tray";
        public override Item DisposesTo => GetCastedGDO<Item, LollipopTray>();
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override int SplitCount => 2;
        public override Item SplitSubItem => GetCastedGDO<Item, Lollipop>();
        public override List<Item> SplitDepletedItems => new() { DisposesTo };

        public override GameObject Prefab => GetPrefab("Filled Lollipop Tray");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Tray", "Metal - Brass");

            prefab.ApplyMaterialToChild("Lollipop/Stick", "Plastic");
            prefab.ApplyMaterialToChild("Lollipop/Candy", "Candy - Blue", "Candy - Pink");
            prefab.ApplyMaterialToChild("Lollipop (0)/Stick", "Plastic");
            prefab.ApplyMaterialToChild("Lollipop (0)/Candy", "Candy - Blue", "Candy - Pink");

            ReflectionUtils.GetField<ObjectsSplittableView>("Objects").SetValue(
                prefab.TryAddComponent<ObjectsSplittableView>(),
                new List<GameObject>()
            {
                prefab.GetChild("Lollipop"),
                prefab.GetChild("Lollipop (0)"),
            });
        }
    }
}

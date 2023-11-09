using Kitchen;
using KitchenCandy.GDOs.Hard;
using KitchenCandy.GDOs.Stick;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Caramel_Apple
{
    public class AppleOnStick : CustomItemGroup
    {
        public override string UniqueNameID => "Apple On Stick";
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, CandyStick>(),
                    GetGDO<Item>(ItemReferences.Apple)
                },
                Max = 2,
                Min = 2,
            },
        };

        public override GameObject Prefab => GetPrefab("Apple On Stick");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Stick", "Plastic");
            prefab.ApplyMaterialToChild("Apple", "AppleRed");
        }
    }
}

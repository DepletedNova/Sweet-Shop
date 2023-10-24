using Kitchen;
using KitchenCandy.GDOs.Hard;
using KitchenCandy.GDOs.Pops;
using KitchenCandy.GDOs.Stick;
using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Box
{
    public class CandyBox : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "Candy Box";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override GameObject Prefab => GetPrefab("Candy Box");
        public override bool ApplyProcessesToComponents => true;

        public override Item DirtiesTo => GetCastedGDO<Item, EmptyCandyBox>();
        public override ItemValue ItemValue => ItemValue.Small;
        public override void OnRegister(ItemGroup GDO)
        {
            GDO.EatingTime = 2f;
        }

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, ClosedCandyBox>(),
                },
                Min = 1, Max = 1, OrderingOnly = true
            },
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, HardCandy>(),
                    GetCastedGDO<Item, Lollipop>()
                },
                Min = 1, Max = 1, OrderingOnly = true,
                RequiresUnlock = true,
            }
        };
    }
}

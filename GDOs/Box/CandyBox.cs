﻿using Kitchen;
using KitchenCandy.GDOs.Hard;
using KitchenCandy.GDOs.Peppermint;
using KitchenCandy.GDOs.Pops;
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

        public override Item DirtiesTo => GetCastedGDO<Item, CandyRubbish>();
        public override ItemValue ItemValue => ItemValue.Small;
        public override Factor EatingTime => 1.5f;

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
                    GetCastedGDO<Item, Lollipop>(),
                    GetCastedGDO<Item, PeppermintChocolate>()
                },
                Min = 1, Max = 1, OrderingOnly = true,
                RequiresUnlock = true,
            }
        };
    }
}

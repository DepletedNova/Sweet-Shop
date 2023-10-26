using Kitchen;
using KitchenCandy.GDOs.Hard;
using KitchenCandy.GDOs.Pops;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Box
{
    public class FilledCandyBox : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "Open Filled Candy Box";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, EmptyCandyBox>(),
                },
                Min = 1,
                Max = 1,
                IsMandatory = true
            },
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, HardCandy>(),
                    GetCastedGDO<Item, Lollipop>()
                },
                Min = 1, Max = 1,
            }
        };

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Process = GetGDO<Process>(ProcessReferences.Knead),
                Duration = 0.25f,
                Result = GetCastedGDO<Item, CandyBox>()
            }
        };

        public override GameObject Prefab => GetPrefab("Candy Box");
        public override void SetupPrefab(GameObject prefab)
        {
            var view = prefab.TryAddComponent<ItemGroupView>();
            var compGroups = new List<ItemGroupView.ComponentGroup>();

            #region Hard Candy
            var HC = prefab.GetChild("Hard Candy");
            HC.GetChild("Wrapped").ApplyMaterialToChildren("Pink", "Candy - Pink");
            HC.GetChild("Wrapped").ApplyMaterialToChildren("Blue", "Candy - Blue");
            HC.ApplyMaterialToChild("Unwrapped/Candy", "Candy - Colorful");
            HC.ApplyMaterialToChild("Unwrapped/Wrapping", "Candy - Pink");

            compGroups.Add(new()
            {
                Item = GetCastedGDO<Item, HardCandy>(),
                GameObject = HC
            });
            #endregion

            #region Lollipops
            var LP = prefab.GetChild("Lollipops");
            LP.ApplyMaterialToChild("Unwrapped", "Candy - Blue");
            LP.ApplyMaterialToChild("Wrapped", "Candy - Blue");
            LP.ApplyMaterialToChild("Stick", "Plastic");
            LP.ApplyMaterialToChild("Candy", "Candy - Blue", "Candy - Pink");

            compGroups.Add(new()
            {
                Item = GetCastedGDO<Item, Lollipop>(),
                GameObject = LP
            });
            #endregion

            List<GameObject> openLids = new()
            {
                HC.GetChild("Unwrapped"),
                LP.GetChild("Unwrapped")
            };

            List<GameObject> closedLids = new()
            {
                HC.GetChild("Wrapped"),
                LP.GetChild("Wrapped")
            };

            #region Finishing touches
            compGroups.Add(new()
            {
                Item = GetCastedGDO<Item, EmptyCandyBox>(),
                DrawAll = true,
                Objects = openLids
            });

            compGroups.Add(new()
            {
                Item = GetCastedGDO<Item, ClosedCandyBox>(),
                DrawAll = true,
                Objects = closedLids
            });

            view.ComponentGroups = compGroups;
            #endregion
        }
    }
}

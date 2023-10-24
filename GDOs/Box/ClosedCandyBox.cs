using KitchenLib.Customs;
using UnityEngine;

namespace KitchenCandy.GDOs.Box
{
    public class ClosedCandyBox : CustomItem
    {
        public override string UniqueNameID => "Closed Candy Box";
        public override GameObject Prefab => GetPrefab("Empty Candy Box");
    }
}

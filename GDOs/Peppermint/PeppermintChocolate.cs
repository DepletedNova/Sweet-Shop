using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenCandy.GDOs.Peppermint
{
    public class PeppermintChocolate : CustomItem
    {
        public override string UniqueNameID => "Peppermint Chocolate";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override GameObject Prefab => GetPrefab("Peppermint Chocolate");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Chocolate", "Chocolate - Darker");
            prefab.ApplyMaterialToChild("Peppermints", "Plastic - Red", "Plastic - White");
        }
    }
}

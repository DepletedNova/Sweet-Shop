using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenCandy.GDOs.Stick
{
    public class RubbishCandyStick : CustomItem
    {
        public override string UniqueNameID => "Rubbish Candy Stick";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override GameObject Prefab => GetPrefab("Rubbish Stick");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Stick", "Plastic");
        }
    }
}

using KitchenCandy.GDOs.Stick;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenCandy.GDOs.Cane
{
    public class CrushedCandyCane : CustomItem
    {
        public override string UniqueNameID => "Crushed Candy Cane";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override GameObject Prefab => GetPrefab("Crushed Candy Cane");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Red", "Plastic - Red");
            prefab.ApplyMaterialToChild("White", "Plastic - White");
        }
    }
}

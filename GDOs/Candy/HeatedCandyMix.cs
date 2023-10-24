using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenCandy.GDOs.Candy
{
    public class HeatedCandyMix : CustomItem
    {
        public override string UniqueNameID => "Heated Candy Mix";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override List<Item.ItemProcess> Processes => new()
        {
            AutomaticItemProcess,
            new()
            {
                Process = GetGDO<Process>(ProcessReferences.Cook),
                Result = GetGDO<Item>(ItemReferences.BurnedFood),
                Duration = 2.5f,
                IsBad = true
            }
        };

        public override Item.ItemProcess AutomaticItemProcess => new()
        {
            Process = GetGDO<Process>(ProcessReferences.SteepTea),
            Result = GetCastedGDO<Item, CooledCandyMix>(),
            Duration = 20f,
            IsBad = true
        };

        public override GameObject Prefab => GetPrefab("Heated Candy Mix");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Bowl", "Metal");
            prefab.ApplyMaterialToChild("Candy", "Candy - Heated");
        }
    }
}

using Kitchen;
using KitchenLib.References;
using Unity.Collections;
using Unity.Entities;

namespace KitchenCandy.Systems
{
    public class SweetiesReplaceBin : NightSystem
    {
        internal static int SweetiesID = 0;

        EntityQuery Appliances;
        EntityQuery Cards;
        protected override void Initialise()
        {
            base.Initialise();
            Appliances = GetEntityQuery(typeof(CAppliance), typeof(CPosition), typeof(CApplianceBin));
            Cards = GetEntityQuery(typeof(CProgressionUnlock));
        }

        protected override void OnUpdate()
        {
            bool found = false;
            using (var cards = Cards.ToComponentDataArray<CProgressionUnlock>(Allocator.Temp))
            {
                for (int i = 0; i < cards.Length; i++)
                {
                    if (cards[i].ID == SweetiesID)
                    {
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
                return;

            using var entities = Appliances.ToEntityArray(Allocator.Temp);
            using var appliances = Appliances.ToComponentDataArray<CAppliance>(Allocator.Temp);
            for (int i = 0; i < entities.Length; i++)
            {
                if (appliances[i].ID != ApplianceReferences.BinStarting)
                    continue;

                var entity = entities[i];
                var pos = GetComponent<CPosition>(entity);

                var appliance = EntityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition));
                Set(appliance, new CCreateAppliance { ID = ApplianceReferences.Bin });
                Set(appliance, pos);

                EntityManager.DestroyEntity(entity);
            }
        }
    }
}

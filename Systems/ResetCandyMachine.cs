using Kitchen;
using Unity.Collections;
using Unity.Entities;

namespace KitchenCandy.Systems
{
    public class ResetCandyMachine : StartOfNightSystem
    {
        private EntityQuery Machines;
        protected override void Initialise()
        {
            base.Initialise();
            Machines = GetEntityQuery(typeof(CItemHolder), typeof(CTakesDuration), typeof(CCottonCandyMachine));
            RequireForUpdate(Machines);
        }

        protected override void OnUpdate()
        {
            using var entities = Machines.ToEntityArray(Allocator.Temp);
            for (int i = 0; i < entities.Length; i++)
            {
                var entity = entities[i];
                var machine = GetComponent<CCottonCandyMachine>(entity);
                var duration = GetComponent<CTakesDuration>(entity);

                machine.HasCandy = false;
                machine.HasStick = false;
                machine.HasCottonCandy = false;
                machine.Cycling = false;

                duration.IsLocked = true;
                duration.Remaining = duration.Total;

                Set(entity, machine);
                Set(entity, duration);

                if (Has<CItemHolderPreventTransfer>(entity))
                    EntityManager.RemoveComponent<CItemHolderPreventTransfer>(entity);
                if (Has<CDisplayDuration>(entity))
                    EntityManager.RemoveComponent<CDisplayDuration>(entity);
                if (Has<CItemHolderOnlySpecificItem>(entity))
                    EntityManager.RemoveComponent<CItemHolderOnlySpecificItem>(entity);
            }
        }
    }
}

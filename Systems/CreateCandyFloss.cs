using Kitchen;
using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace KitchenCandy.Systems
{
    public class CreateCandyFloss : GameSystemBase
    {
        private EntityQuery Query;
        protected override void Initialise()
        {
            base.Initialise();
            Query = GetEntityQuery(typeof(CCottonCandyMachine), typeof(CTakesDuration), typeof(CDisplayDuration), typeof(CItemHolder));
        }

        protected override void OnUpdate()
        {
            using var entities = Query.ToEntityArray(Allocator.Temp);
            for (int i = 0; i < entities.Length; i++)
            {
                var entity = entities[i];
                var machine = GetComponent<CCottonCandyMachine>(entity);
                var duration = GetComponent<CTakesDuration>(entity);

                if (!machine.Cycling || !duration.Active || duration.Remaining > 0f)
                    continue;

                machine.Cycling = false;
                machine.HasCottonCandy = true;
                duration.IsLocked = true;

                Set(entity, machine);
                Set(entity, duration);

                EntityManager.RemoveComponent<CDisplayDuration>(entity);

                if (Has<CItemHolderPreventTransfer>(entity))
                    EntityManager.RemoveComponent<CItemHolderPreventTransfer>(entity);
                if (Has<CItemHolderOnlySpecificItem>(entity))
                    EntityManager.RemoveComponent<CItemHolderOnlySpecificItem>(entity);

                var ctx = new EntityContext(EntityManager);
                var item = ctx.CreateItem(machine.OutputID);
                ctx.UpdateHolder(item, entity);
                ctx.Dispose();

                CSoundEvent.Create(EntityManager, SoundEvent.ProcessComplete);
            }
        }
    }
}

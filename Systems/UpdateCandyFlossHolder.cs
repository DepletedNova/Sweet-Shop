using Kitchen;
using System.Xml.Schema;
using Unity.Collections;
using Unity.Entities;

namespace KitchenCandy.Systems
{
    public class UpdateCandyFlossHolder : GameSystemBase
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
                var holder = GetComponent<CItemHolder>(entity);
                var duration = GetComponent<CTakesDuration>(entity);
                var hasItem = holder.HeldItem != Entity.Null;

                if (hasItem && Require(holder, out CItem item))
                {
                    if (Has<CDisplayDuration>(entity))
                        EntityManager.RemoveComponent<CDisplayDuration>(entity);

                    if (machine.HasCottonCandy)
                        continue;

                    if (item.ID == machine.InputCandyID || item.ID == machine.InputStickID)
                    {
                        EntityManager.DestroyEntity(holder);

                        var isCandy = item.ID == machine.InputCandyID;
                        machine.HasCandy |= isCandy;
                        machine.HasStick |= !isCandy;

                        Set(entity, new CItemHolderOnlySpecificItem { ItemID = isCandy ? machine.InputStickID : machine.InputCandyID });
                    }
                    
                    if (machine.HasCandy && machine.HasStick)
                    {
                        machine.Cycling = true;
                        duration.IsLocked = false;
                        duration.Remaining = duration.Total;
                        Set(entity, new CItemHolderPreventTransfer { PreventInsertingInto = true, PreventTakingFrom = true });
                        Set(entity, new CDisplayDuration { Process = machine.ProcessID, ShowWhenEmpty = true });
                        Set(entity, new CItemHolderOnlySpecificItem { ItemID = 0 });
                    }

                    Set(entity, machine);
                    Set(entity, duration);

                    continue;
                }

                if (machine.HasCottonCandy && !hasItem)
                {
                    machine.HasCandy = false;
                    machine.HasStick = false;
                    machine.HasCottonCandy = false;
                    Set(entity, machine);
                }
            }
        }
    }
}

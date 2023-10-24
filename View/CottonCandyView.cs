using Kitchen;
using MessagePack;
using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace KitchenCandy.View
{
    public class CottonCandyView : UpdatableObjectView<CottonCandyView.ViewData>
    {
        public float MaxAcceleration = 200f;

        // Renderer
        public MeshRenderer IndicatorRenderer;
        public Material InactiveIndicator;
        public Material ActiveIndicator;

        // Spinner
        public Transform Spinner;
        public GameObject Candy;
        public GameObject Stick;
        public GameObject HoldPoint;

        private ViewData Data = new();
        private float CurrentAcceleration = 0f;

        protected override void UpdateData(ViewData data)
        {
            if (data.HasStick)
                Stick.SetActive(true);
            else
                Stick.SetActive(false);

            if (data.HasCandy && !Data.HasCandy)
            {
                Candy.transform.localScale = new(0f, 0f, 0.35f);
                IndicatorRenderer.material = ActiveIndicator;
            }
            else if (!data.HasCandy)
                IndicatorRenderer.material = InactiveIndicator;

            if (data.HasStick && data.HasCandy)
            {
                if (!Data.HasCandy || !Data.HasStick)
                    Candy.transform.localScale = new(0f, 0f, 0.35f);
                Candy.SetActive(true);
            }
            else
                Candy.SetActive(false);

            if (data.ShowHoldPoint)
                HoldPoint.SetActive(true);
            else
                HoldPoint.SetActive(false);


            Data = data;
        }

        private void Update()
        {
            if (Data.Active && CurrentAcceleration != MaxAcceleration)
                CurrentAcceleration = Mathf.Min(CurrentAcceleration + 50f * Time.deltaTime, MaxAcceleration);
            else if (!Data.Active && CurrentAcceleration > 0f)
                CurrentAcceleration = Mathf.Max(CurrentAcceleration - 100f * Time.deltaTime, 0f);

            if (CurrentAcceleration > 0f)
                Spinner.Rotate(new Vector3(0, CurrentAcceleration * Time.deltaTime, 0));

            var progress = -Data.Progress + 1.0f;
            if (progress > 0f)
                Candy.transform.localScale = new(0.7f * progress, 0.7f * progress, 0.7f * (progress / 2 + 0.5f));
        }

        [MessagePackObject]
        public struct ViewData : ISpecificViewData, IViewData.ICheckForChanges<ViewData>
        {
            [Key(1)] public bool HasStick;
            [Key(2)] public bool HasCandy;
            [Key(3)] public bool Active;
            [Key(4)] public float Progress;
            [Key(5)] public bool ShowHoldPoint;

            public IUpdatableObject GetRelevantSubview(IObjectView view) => view.GetSubView<CottonCandyView>();

            public bool IsChangedFrom(ViewData check) =>
                Active != check.Active || Progress != check.Progress || 
                HasStick != check.HasStick || HasCandy != check.HasCandy || 
                ShowHoldPoint != check.ShowHoldPoint;
        }

        private class UpdateView : IncrementalViewSystemBase<ViewData>
        {
            private EntityQuery Query;
            protected override void Initialise()
            {
                base.Initialise();
                Query = GetEntityQuery(typeof(CCottonCandyMachine), typeof(CTakesDuration), typeof(CLinkedView), typeof(CAppliance));
            }

            protected override void OnUpdate()
            {
                using var entities = Query.ToEntityArray(Allocator.Temp);
                for (int i = 0; i < entities.Length; i++)
                {
                    var entity = entities[i];
                    var machine = GetComponent<CCottonCandyMachine>(entity);
                    var data = new ViewData
                    {
                        HasStick = machine.HasStick,
                        HasCandy = machine.HasCandy,
                        ShowHoldPoint = !machine.HasCottonCandy
                    };

                    if (machine.Cycling)
                    {
                        var duration = GetComponent<CTakesDuration>(entity);

                        data.Active = duration.Active && duration.CurrentChange != 0f;
                        data.Progress = duration.Remaining / duration.Total;
                    }

                    SendUpdate(GetComponent<CLinkedView>(entity), data, MessageType.SpecificViewUpdate);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using FootballAdministration.Enums;
using FootballAdministration.Models.Views;
using FootballAdministration.Services.Base;
using FootballAdministration.ViewModels.Base;

namespace FootballAdministration.ViewModels
{
    public partial class PlanningViewModel : ViewModelBase
    {
        private List<PlanningItemView> _planningItems;

        public PlanningViewModel(DialogService dialogService = null)
            : base(dialogService)
        {
            //
        }

        #region Properties
        public List<PlanningItemView> PlanningItems
        {
            get => _planningItems;
            set => SetProperty(ref _planningItems, value);
        }
        #endregion

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();

            PlanningItems = [
                new PlanningItemView() {
                    FieldName = "Field 1",
                    Title = "Match 1",
                    StartDateTime = new DateTimeOffset(2021, 10, 1, 10, 0, 0, 0, new TimeSpan(0, 0, 0)),
                    StopDateTime = new DateTimeOffset(2021, 10, 1, 12, 0, 0, 0, new TimeSpan(0, 0, 0)),
                    Type = PlanningItemType.Match
                },
                new PlanningItemView() {
                    FieldName = "Field 3",
                    Title = "Training 1",
                    StartDateTime = new DateTimeOffset(2021, 10, 1, 7, 0, 0, 0, new TimeSpan(0, 0, 0)),
                    StopDateTime = new DateTimeOffset(2021, 10, 1, 9, 30, 0, 0, new TimeSpan(0, 0, 0)),
                    Type = PlanningItemType.Training
                }
            ];
        }
    }
}

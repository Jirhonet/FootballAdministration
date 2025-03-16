using FootballAdministration.Enums;
using FootballAdministration.Models.Views;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System.Collections.Generic;
using System.Linq;

namespace FootballAdministration.Controls
{
    public sealed partial class FieldDayPlanning : UserControl
    {
        /// <summary>
        /// The <see cref="Grid"/> component tries to render at least every <see cref="ColumnDefinition"/> with a MinWidth of 1.<br/>
        /// Creating 60 * 24 = 1440 columns (minutes), will result in a grid trying to find 1440 pixels to render.<br/>
        /// If there are less pixels on the screen the last columns will just be hidden resulting in a non-uniform grid.<br/>
        /// <br/>
        /// The SimplifyFactor basically changes the 'Minutes per column', and is used to properly render the planning.
        /// </summary>
        private const int SimplifyFactor = 12; // 12 -> 5 minutes per column, seems to be a good balance between detail and functionality
        private readonly int minutes = 60 / SimplifyFactor;

        private static readonly GridLength HourHeight = new GridLength(30);
        private static readonly GridLength RowHeight = new GridLength(50);
        private static readonly CornerRadius RowRadius = new CornerRadius(5);

        DependencyProperty PlanningItemsProperty = DependencyProperty.Register(nameof(PlanningItems), typeof(List<PlanningItemView>), typeof(FieldDayPlanning),
            new PropertyMetadata(default, new PropertyChangedCallback(OnPlanningItemsChanged)));

        public FieldDayPlanning()
        {
            InitializeComponent();
            InitializePlanningItems();
        }

        #region Properties
        public List<PlanningItemView> PlanningItems
        {
            get => (List<PlanningItemView>)GetValue(PlanningItemsProperty);
            set => SetValue(PlanningItemsProperty, value);
        }
        #endregion

        private static void OnPlanningItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FieldDayPlanning dayPlanning = (FieldDayPlanning)d;

            dayPlanning.InitializePlanningItems();
        }

        private void InitializePlanningItems()
        {
            ResetPlanningGrid();

            if (PlanningItems is null or [])
                return;

            InitializePlanningColumns();
            AddHeader();
            AddPlanningItems();
        }

        private void ResetPlanningGrid()
        {
            planning.Children.Clear();
            planning.ColumnDefinitions.Clear();
            planning.RowDefinitions.Clear();
        }

        private void InitializePlanningColumns()
        {
            planning.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

            for (int i = 0; i < 24 * minutes; i++)
                planning.ColumnDefinitions.Add(new ColumnDefinition());
        }

        private void AddHeader()
        {
            planning.RowDefinitions.Add(new RowDefinition() { Height = HourHeight });
            for (int i = 0; i < 24; i++)
                AddHeaderItem(i);
        }

        private void AddHeaderItem(int hour)
        {
            Grid grid = CreateHeaderItemGrid(hour);

            TextBlock textBlock = new TextBlock()
            {
                Text = $"{hour:00}:00",
                Padding = new Thickness(5, 1, 0, 0)
            };
            grid.Children.Add(textBlock);

            planning.Children.Add(grid);
        }

        private Grid CreateHeaderItemGrid(int hour)
        {
            Grid grid = new Grid()
            {
                BorderBrush = new SolidColorBrush(Colors.White),
                BorderThickness = new Thickness(1, 0, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                MinWidth = 0
            };

            int startColumn = hour * minutes + 1;
            int stopColumn = startColumn + minutes;
            Grid.SetColumnSpan(grid, stopColumn - startColumn);
            Grid.SetColumn(grid, startColumn);
            Grid.SetRow(grid, 0);

            return grid;
        }

        private void AddPlanningItems()
        {
            int row = 1;
            foreach (var fieldDayPlanning in PlanningItems.GroupBy(pi => pi.FieldName))
            {
                planning.RowDefinitions.Add(new RowDefinition() { Height = RowHeight });

                Grid grid = new Grid() { VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Stretch, MinWidth = 0 };
                Grid.SetRow(grid, row);

                grid.Children.Add(new TextBlock() { Text = fieldDayPlanning.Key, Padding = new Thickness(10, 0, 10, 0) });


                Grid background = new Grid() { Background = (Brush)Application.Current.Resources["CardBackgroundFillColorDefaultBrush"], CornerRadius = RowRadius };
                Grid.SetColumn(background, 1);
                Grid.SetColumnSpan(background, 24 * minutes);
                Grid.SetRow(background, row);

                planning.Children.Add(background);


                foreach (PlanningItemView planningItem in fieldDayPlanning)
                    AddPlanningItem(planningItem, row);

                planning.Children.Add(grid);

                row++;
            }
        }

        private void AddPlanningItem(PlanningItemView planningItem, int row)
        {
            Button button = CreatePlanningItemButton(planningItem, row);

            planning.Children.Add(button);
        }

        private Button CreatePlanningItemButton(PlanningItemView planningItem, int row)
        {
            Button button = new Button()
            {
                Content = planningItem.Title,
                CornerRadius = RowRadius,
                Background = GetBrushByPlanningItemType(planningItem.Type),
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };

            int startColumn = planningItem.StartDateTime.Hour * minutes + planningItem.StartDateTime.Minute / SimplifyFactor + 1;
            int stopColumn = planningItem.StopDateTime.Hour * minutes + planningItem.StopDateTime.Minute / SimplifyFactor + 1;
            Grid.SetColumnSpan(button, stopColumn - startColumn);
            Grid.SetColumn(button, startColumn);
            Grid.SetRow(button, row);

            return button;
        }

        private static Brush GetBrushByPlanningItemType(PlanningItemType type)
        {
            return type switch
            {
                PlanningItemType.Training => (Brush)Application.Current.Resources["AccentFillColorDefaultBrush"],
                PlanningItemType.Match => (Brush)Application.Current.Resources["AccentFillColorSelectedTextBackgroundBrush"],
                _ => (Brush)Application.Current.Resources["AccentFillColorDisabledBrush"],
            };
        }
    }
}

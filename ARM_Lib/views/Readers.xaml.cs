using ARM_Lib.dg_actions;
using ARM_Lib.models;
using ARM_Lib.models_view;
using ARM_Lib.vm;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ARM_Lib.views
{
    /// <summary>
    /// Логика взаимодействия для Readers.xaml
    /// </summary>
    public partial class Readers : MetroWindow
    {
        private Dictionary<int, ActionTypes> changedCells;
        private ActionTypes currentlyActionType;
        private List<ReaderView> tempReaders = new List<ReaderView>();

        public Readers()
        {
            InitializeComponent();

            this.DataContext = new ReadersViewModel();
            this.readers_grid.CellEditEnding += CellEditEventHandler;
            this.changedCells = new Dictionary<int, ActionTypes>();
        }

        private void about_app_Click(object sender, RoutedEventArgs e)
        {
            this.AboutApp.IsOpen = !this.AboutApp.IsOpen;
        }

        private void reports_button_click(object sender, RoutedEventArgs e)
        {
            this.reports_pane.IsOpen = !this.reports_pane.IsOpen;
        }
        private void exit_app_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_AddingNewItem(object sender, System.Windows.Controls.AddingNewItemEventArgs e)
        {
            currentlyActionType = ActionTypes.Create;
        }

        // См в Books.xaml, копипаста
        private async void DataGrid_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            this.commit_button.IsEnabled = true;
            if (e.Key == Key.Delete)
            {
                var grid = (System.Windows.Controls.DataGrid)sender;
                try
                {
                    tempReaders.Add(grid.SelectedItem as ReaderView);
                }
                catch (Exception exc)
                {
                    await this.ShowMessageAsync("Deleting element from database", "exc: " + exc.Message);
                }
                //this.changedCells.Add(, ActionTypes.Remove);
                currentlyActionType = ActionTypes.Remove;

                this.changedCells.Add(tempReaders.Count - 1, ActionTypes.Remove);
            }
        }

        // СМ в Books.xaml, копипаста
        private async void CellEditEventHandler(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                if (changedCells.ContainsKey(e.Row.GetIndex()))
                {
                    return;
                }
                switch (currentlyActionType)
                {
                    case ActionTypes.Create:
                        currentlyActionType = ActionTypes.Update;
                        this.changedCells.Add(e.Row.GetIndex(), ActionTypes.Create);
                        break;
                    case ActionTypes.Remove:
                        currentlyActionType = ActionTypes.Undefined;
                        this.changedCells.Add(e.Row.GetIndex(), ActionTypes.Remove);
                        await this.ShowMessageAsync("Deleting element from database", "message");
                        break;
                    default:
                        this.changedCells.Add(e.Row.GetIndex(), ActionTypes.Update);
                        break;
                }

                this.commit_button.IsEnabled = true;
            }
        }

        private void commit_button_Click(object sender, RoutedEventArgs e)
        {
            this.commit_button.IsEnabled = false;
            (this.DataContext as ReadersViewModel).commitChangeData(this.changedCells, tempReaders);
        }

        private void back_to_main_window_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void report_per_books_button_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var reportsBooks = new ReportPerBooks();
            reportsBooks.ShowDialog();
            this.IsEnabled = true;
        }

        private void report_per_reader_button_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var reportsReaders = new ReportPerReader();
            reportsReaders.ShowDialog();
            this.IsEnabled = true;
        }
    }
}

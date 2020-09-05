using ARM_Lib.dg_actions;
using ARM_Lib.vm;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ARM_Lib.views
{
    /// <summary>
    /// Логика взаимодействия для Books.xaml
    /// </summary>
    public partial class Books : MetroWindow
    {
        private Dictionary<int, ActionTypes> changedCells;
        private ActionTypes currentlyActionType;
        private int currentlyRowEditing = -1;
        public Books()
        {
            InitializeComponent();

            this.DataContext = new BooksViewModel();
            this.books_grid.CellEditEnding += CellEditEventHandler;
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

        private void RemoveBook_Click(object sender, RoutedEventArgs e)
        {
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void CellEditEventHandler(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                if (changedCells.ContainsKey(e.Row.GetIndex()))
                {
                    await this.ShowMessageAsync("Already changed on row was catched", "tururu");
                    return;
                }
                switch(currentlyActionType)
                {
                    case ActionTypes.Create:
                        currentlyActionType = ActionTypes.Update;
                        this.changedCells.Add(e.Row.GetIndex(), ActionTypes.Create);
                        break;
                    default:
                        this.changedCells.Add(e.Row.GetIndex(), ActionTypes.Update);
                        break;
                }
                
                this.commit_button.IsEnabled = true;
                await this.ShowMessageAsync("First catch changed", "tururu");
            }
        }

        private void CommitSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void books_grid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            currentlyActionType = ActionTypes.Create;
        }

        private async void books_grid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            await this.ShowMessageAsync("Completed edited row", e.Row.Item.ToString());
        }
    }
}

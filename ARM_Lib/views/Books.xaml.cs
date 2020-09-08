using ARM_Lib.dg_actions;
using ARM_Lib.models_view;
using ARM_Lib.vm;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace ARM_Lib.views
{
    /// <summary>
    /// Логика взаимодействия для Books.xaml
    /// </summary>
    public partial class Books : MetroWindow
    {
        private Dictionary<int, ActionTypes> changedCells;
        private ActionTypes currentlyActionType;
        private List<BookView> tempBooks = new List<BookView>();

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

        private async void RemoveBook_Click(object sender, RoutedEventArgs e)
        {
            var grid = (System.Windows.Controls.DataGrid)sender;
            try
            {
                tempBooks.Add(grid.SelectedItem as BookView);
            }
            catch (Exception exc)
            {
                await this.ShowMessageAsync("Deleting element from database", "exc: " + exc.Message);
            }
            currentlyActionType = ActionTypes.Remove;

            this.changedCells.Add(tempBooks.Count - 1, ActionTypes.Remove);
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {

        }

        // основной метоод, который отслеживает измененние ячеек в таблице.
        private async void CellEditEventHandler(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                if (changedCells.ContainsKey(e.Row.GetIndex()))
                {
                    return;
                }
                switch(currentlyActionType)
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

        // после того, как пользователь всё что нужно сделал (добавил, отредачил, удалил), он берёт и коммитит
        private void CommitSave_Click(object sender, RoutedEventArgs e)
        {
            this.commit_button.IsEnabled = false;
            (this.DataContext as BooksViewModel).commitChangeData(this.changedCells, tempBooks); // в свою очередь через ViewModel отправляем изменнеия в базу
        }

        private void back_to_main_window_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void books_grid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            currentlyActionType = ActionTypes.Create; // отслеживаем таким образом текущее изменение как добавление новой строки (см привязку в xaml)
        }

        private async void DataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            await this.ShowMessageAsync("Removin handling", "Some message");
        }

        // отслеживаем удаление элемента
        private async void books_grid_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            this.commit_button.IsEnabled = true;
            if (e.Key == Key.Delete)
            {
                var grid = (System.Windows.Controls.DataGrid)sender;
                try
                {
                    tempBooks.Add(grid.SelectedItem as BookView);
                } catch(Exception exc)
                {
                    await this.ShowMessageAsync("Deleting element from database", "exc: " + exc.Message);
                }
                //this.changedCells.Add(, ActionTypes.Remove);
                currentlyActionType = ActionTypes.Remove;

                this.changedCells.Add(tempBooks.Count - 1, ActionTypes.Remove);
            }
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

        private void report_history_button_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var reportHistory = new ReportHistory();
            reportHistory.ShowDialog();
            this.IsEnabled = true;
        }
    }
}

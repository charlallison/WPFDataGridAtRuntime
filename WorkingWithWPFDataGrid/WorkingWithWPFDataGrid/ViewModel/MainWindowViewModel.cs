using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WorkingWithWPFDataGrid.Command;

namespace WorkingWithWPFDataGrid.ViewModel {

    public class MainWindowViewModel : INotifyPropertyChanged {
        public MainWindowViewModel() {
            AddColumnCommand = new CommandImpl(AddColumnAction);
            AddRowCommand = new CommandImpl(AddRowAction);

            DataSource = new DataTable();
            DataSource.Columns.Add("Column 1");
            DataSource.Columns.Add("Column 2");
        }

        private void AddColumnAction() {
            DataSource.Columns.Add(new DataColumn(ColumnName));
            ColumnName = string.Empty;
            UpdateDataGrid();
        }

        private void AddRowAction() {
            DataSource.Rows.Add(DataSource.NewRow());
        }

        // method is called after a DataColumn is added to the DataTable
        private void UpdateDataGrid() {
            GenerateColumn = false;
            GenerateColumn = true;
        }

        private bool _generateColumns;
        public bool GenerateColumn {
            get { return _generateColumns; }
            set { _generateColumns = value; OnPropertyChanged(); }
        }


        private DataTable dataSource;
        public DataTable DataSource {
            get { return dataSource; }
            set { dataSource = value; OnPropertyChanged(); }
        }

        private string columnName;
        public string ColumnName {
            get { return columnName; }
            set { columnName = value; OnPropertyChanged(); }
        }

        public ICommand AddColumnCommand { get; set; }

        public ICommand AddRowCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged([CallerMemberName]string propertyName = "") {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

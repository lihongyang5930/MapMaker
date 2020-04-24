using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DrPipe.Core.Services;
using DrPipe.Diagnosis.Models;
using Syncfusion.Windows.Forms.Chart;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;

namespace DrPipe.Diagnosis.Views.Local.Analysis.Hydraulics
{
    public partial class PatternView : UserControl
    {
        GridComboBoxColumn _categoryColumn;

        public PatternView()
        {
            InitializeComponent();
            Appearances.DataGrid(dgPattern);
            Appearances.DataGrid(dgPatternValue);
            InitializePatternMasterDataGrid(dgPattern);
            InitializePatternValuesDataGrid(dgPatternValue);
            InitializeChartControl(chtPattern);
        }

        public void SetPatternCategories(params string[] categories)
        {
            _categoryColumn.DataSource  = categories;
        }
        public void SetPatterns(IEnumerable<Pattern> data)
        {
            dgPattern.DataSource = data;
            if (data.Any())
            {
                dgPattern.SelectedIndex = 0;
                OnSelectedPatternChanged(data.First());
            }
        }

        private void InitializePatternMasterDataGrid(SfDataGrid dataGrid)
        {
            _categoryColumn = new GridComboBoxColumn() { 
                HeaderText  = "구분"  , 
                MappingName = nameof(Pattern.Category),
            };
            dataGrid.Columns.Add(_categoryColumn);
            dataGrid.Columns.Add(new GridTextColumn() { HeaderText = "패턴명", MappingName = nameof(Pattern.Name    ) });
            dataGrid.AutoGenerateColumns = false;
            dataGrid.SelectionChanged   += OnPatternMasterDataGridSelectionChanged;
        }
        private void InitializePatternValuesDataGrid(SfDataGrid dataGrid)
        {
            dataGrid.Columns.Add(new GridTextColumn() { HeaderText = "No.", MappingName = nameof(PatternValue.No   )});
            dataGrid.Columns.Add(new GridTextColumn() { HeaderText = "값" , MappingName = nameof(PatternValue.Value)});
            dataGrid.CurrentCellEndEdit += OnPatternValuesDataGridCurrentCellEndEdit;
        }

        private void InitializeChartControl(ChartControl chart)
        {
            Appearances.Chart(chart);

            chart.PrimaryXAxis.RangeType = ChartAxisRangeType.Set;
            chart.PrimaryXAxis.Range     = new MinMaxInfo(0, 25, 1);

            chart.PrimaryYAxis.RangeType = ChartAxisRangeType.Set;
            chart.PrimaryYAxis.Range     = new MinMaxInfo(0, 1.5, 0.1);

            chart.Series[0].Style.Border.Color = Color.Transparent;

            RefreshChart(null);
        }

        private void OnPatternMasterDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pattern pattern = null;
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                pattern = e.AddedItems.First() as Pattern;
            }
            OnSelectedPatternChanged(pattern);
        }
        private void OnSelectedPatternChanged(Pattern pattern)
        {
            var values = pattern?.Values;
            dgPatternValue.DataSource = values;
            RefreshChart(values);
        }
        private void OnPatternValuesDataGridCurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
        {
            var dataGrid = (SfDataGrid)sender;
            var values   = dataGrid.DataSource as PatternValue[];
            if (values != null)
            {
                RefreshChart(values);
            }
        }

        private void RefreshChart(PatternValue[] values)
        {
            var series = new ChartSeries();
            if (values != null)
            {
                foreach (var value in values)
                {
                    series.Points.Add(value.No, value.Value);
                }
            }
            chtPattern.Series.Clear();
            chtPattern.Series.Add(series);
        }
    }
}

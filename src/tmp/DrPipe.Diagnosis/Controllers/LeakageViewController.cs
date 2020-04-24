using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrPipe.Core.Controllers;
using DrPipe.Core.Models;
using DrPipe.Diagnosis.Views.Local.Analysis.Repair;

namespace DrPipe.Diagnosis.Controllers
{
    public class LeakageViewController : ControllerBase
    {
        LeakageView _view;

        DateTime?   _startMonth;
        DateTime?   _endMonth;
        double?     _icf;
        public LeakageViewController()
        {
            _view = new LeakageView();
            _view.txtPeriod.ReadOnly  = true;
            _view.btnSetPeriod     .Click += OnBtnSetPeriodClick;
            _view.btnCoeff         .Click += OnBtnCoeffClick;
            _view.btnLeakageHistory.Click += OnBtnLeakageHistoryClick;
            _view.lblIcf.Text  = GetIcfLabel(0);
        }



        public double? Icf
        {
            get => _icf;
            set
            {
                _icf = value;
                _view.lblIcf.Text = GetIcfLabel(value ?? 0);
            }
        }


        public void OnBtnCoeffClick(object sender, EventArgs e)
        {
            //var view   = new CoefficientSetupView();
            //var result = Views.ShowFixedDialog(view, "계수 설정");
            //if (result == DialogResult.OK)
            //{
            //    Icf = view.Icf;
            //}
        }
        public void OnBtnSetPeriodClick(object sender, EventArgs e)
        {
            var period = Views.SelectMonth();
            SetPeriod(period);
        }
        public void OnBtnLeakageHistoryClick(object sender, EventArgs e)
        {
            var view   = new LeakageHistory();
            var result = Views.ShowFixedDialog(view, "파열누수 이력정보");
            if (result == DialogResult.OK)
            {
            }
        }

        private void SetPeriod(MonthRange period)
        {
            if (period == null)
            {
                _startMonth = null;
                _endMonth   = null;
                _view.txtPeriod.Text = string.Empty;
            }
            else
            {
                _startMonth = new DateTime(period.Year1, period.Month1, 1);
                _endMonth   = new DateTime(period.Year2, period.Month2, 1);
                _view.txtPeriod.Text 
                    = $"{GetMonthString(_startMonth)} ~ {GetMonthString(_endMonth)}";
            }
        }
        private string GetMonthString(DateTime? dateTime)
        {
            if (dateTime == null)
                return string.Empty;
            return $"{dateTime.Value.Year.ToString("D4")}-{dateTime.Value.Month.ToString("D2")}";
        }
        private string GetIcfLabel(double value)
        {
            return $"ICF: " + value;
        }

        public override Task Initialize()
        {
            return Task.CompletedTask;
        }
    }
}

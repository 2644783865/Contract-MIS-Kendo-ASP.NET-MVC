using System;
using Misi.MVC.ViewModels.Shared;

namespace Misi.MVC.ViewModels.ScenarioGeneral
{
    public class RoutingTableLineViewModel
    {
        public int Step { get; set; }
        public DropDownListViewModel Divisions { get; set; }
        public string Instruction { get; set; }
        public string Response { get; set; }
        public DateTime Baseline { get; set; }
        public DateTime Plan { get; set; }
        public DateTime Actual { get; set; }
        public bool DivisionStatus { get; set; }
        public bool SaStatus { get; set; }
        public DropDownListViewModel RoutingStatusList { get; set; }
        public string Modify { get; set; }
    }
}
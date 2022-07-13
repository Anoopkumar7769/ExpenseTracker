using System.Collections.Generic;
using System.Web.Mvc;

namespace ExpenseTracker.Models.ViewModels
{
    public class ExpenditureVM
    {
        public Expenditure Expenditure { get; set; }

        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
    }
}

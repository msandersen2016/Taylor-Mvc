using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taylor_Mvc.Models
{
    public class AllStaffSelectionViewModel
    {
        public List<SelectStaffEditorViewModel> Staff { get; set; }
        public AllStaffSelectionViewModel()
        {
            Staff = new List<SelectStaffEditorViewModel>();
        }


        public IEnumerable<string> GetSelectedIds()
        {
            // Return an Enumerable containing the Id's of the selected people:
            return (from p in Staff where p.Selected select p.Email).ToList();

        }
    }
}
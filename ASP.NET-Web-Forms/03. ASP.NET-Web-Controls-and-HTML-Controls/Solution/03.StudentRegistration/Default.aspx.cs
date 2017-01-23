using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.StudentRegistration
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnRegisterStudentButtonClicked(object sender, EventArgs e)
        {
            var student = new
            {
                FirstName = this.FirstNameInput.Text,
                LastName = this.LastNameInput.Text,
                FacultyNumber = this.FacultyNumberInput.Text,
                University = this.UniversityDropDown.SelectedValue,
                Course = this.CourseDropDown.SelectedValue,
                Speciality = this.SpecialtyDropDown.SelectedValue
            };

            this.RegistrationInfo.InnerText = student.ToString();
        }
    }
}
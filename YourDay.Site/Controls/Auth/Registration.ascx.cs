using System;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using YourDay.BLL;
using System.Web.Security;

namespace YourDay.Site.Controls.Auth
{
    public partial class Registration : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelRegistrationTitle.Text = Constants.Strings.RegistrationTitle;
        }

        protected void CreateUserWizard1_CreatingUser(object sender, LoginCancelEventArgs e)
        {
            CreateUserWizard uw = (CreateUserWizard)sender;
            try
            {
                if (uw.Password != uw.ConfirmPassword)
                    throw new ConfirmPasswordException(Constants.Errors.ConfirmPasswordError);
                uw.Email = uw.UserName;
                //TODO: вынести. и подумать как вынести в JS.
                Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                if (!regex.IsMatch(uw.UserName))
                    throw new Exception(Constants.Errors.RegexLoginError);
                //BLL.Post.SimpleUser(uw.UserName);

                string role = String.Empty;

                RadioButton rbSimpleUser = uw.DeepFindControl<RadioButton>("RadioButtonSimpleUser");
                RadioButton rbContractor = uw.DeepFindControl<RadioButton>("RadioButtonContractor");

                if (rbSimpleUser.Checked)
                    role = YourDay.Security.RoleProvider.SIMPLE_USER;
                else if (rbContractor.Checked)
                    role = YourDay.Security.RoleProvider.NOT_APPROVED;
                Roles.AddUserToRole(uw.UserName, role);
            }
            catch (ConfirmPasswordException ex)
            {
                Label ConfirmPassword = uw.DeepFindControl<Label>("ConfirmPasswordError");
                Label Password = uw.DeepFindControl<Label>("PasswordError");
                ConfirmPassword.Text = ex.Message;
                Password.Text = ex.Message;
            }
            catch (Exception ex)
            {
                Label loginError = uw.DeepFindControl<Label>("LoginError");
                loginError.Text = ex.Message;
            }
            
        }
    }
}
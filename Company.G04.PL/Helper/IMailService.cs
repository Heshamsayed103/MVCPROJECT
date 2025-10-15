using Company.G04.DAL;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Company.G04.PL.Helper
{
    public interface IMailService
    {

        public void SendEmail(Email email);

    }
}

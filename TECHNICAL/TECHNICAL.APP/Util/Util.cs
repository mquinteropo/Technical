using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TECHNICAL.APP.Util
{
    public class Util
    {
        private const string ScriptSwal = "Swal.fire( '{0}','{1}','{2}')";
        private static void ShowMessageSwal(Page page, String title, String msg, String type)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "Alert", String.Format(ScriptSwal, title, msg.Replace(@"""", " ").Replace(Environment.NewLine, "").Replace("'", " "), type), true);
        }
        public static void showErrorMessageSwal(Page page, String title, String msg)
        {
            ShowMessageSwal(page, title, msg, "danger");
        }
        public static void showWarningMessageSwal(Page page, String title, String msg)
        {
            ShowMessageSwal(page, title, msg, "warning");
        }
        public static void showSuccessMessageSwal(Page page, String title, String msg)
        {
            ShowMessageSwal(page, title, msg, "success");
        }
        public static void ShowModal(Page page, string modal)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "showModal", "" +
                         "$('#" + modal + "').modal('toggle'); ", true);
        }

        public static void CloseModal(Page page, string modal)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "closeModal", "" +
                         "$('#" + modal + "').modal('hide');", true);
        }
    }
}
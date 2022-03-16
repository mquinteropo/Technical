using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TECHNICAL.APP.Model;

namespace TECHNICAL.APP
{
    public partial class Page_1 : System.Web.UI.Page
    {
        private string UrlService = ConfigurationManager.AppSettings["EndPointService"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTypeDdl();
                GetPersons();
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "dataTable", "$('#tableList').DataTable();", true);
        }
        #region Table
        public void GetPersons()
        {
            try
            {
                var client = new RestClient(UrlService + "Person");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = JsonConvert.DeserializeObject<ServiceResponse>(response.Content);
                    listPersons.DataSource = result.data;
                    listPersons.DataBind();
                }
            }
            catch (Exception ex)
            {
                Util.Util.showErrorMessageSwal(Page, "Error", ex.Message);
            }
        }
        #endregion
        #region Controls
        protected void Delete(object sender, EventArgs e)
        {
            try
            {
                string[] values = ((LinkButton)sender).CommandArgument.Split(';');
                int id = Convert.ToInt32(values[0]);

                var client = new RestClient(UrlService + "Person/" + id);
                client.Timeout = -1;
                var request = new RestRequest(Method.DELETE);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = JsonConvert.DeserializeObject<ServiceTypesResponse>(response.Content);
                    if (result.success)
                    {
                        Util.Util.showSuccessMessageSwal(Page, "Success", result.message);
                        GetPersons();
                    }
                    else
                    {
                        Util.Util.showWarningMessageSwal(Page, "Warning", result.message);
                    }
                }
                else
                {
                    Util.Util.showWarningMessageSwal(Page, "Warning", "Service response isn't good");
                }
            }
            catch (Exception ex)
            {
                Util.Util.showErrorMessageSwal(Page, "Error", ex.Message);
            }
        }
        protected void Edit(object sender, EventArgs e)
        {
            try
            {
                string[] values = ((LinkButton)sender).CommandArgument.Split(';');
                string id = values[0];
                string name = values[1];
                string age = values[2];
                string type = values[3];

                txtId.ReadOnly = true;
                hddIdPerson.Value = id;
                txtId.Text = id;
                txtName.Text = name;
                txtAge.Text = age;
                ddlType.SelectedValue = type;

                Util.Util.ShowModal(Page, "modalForm");

            }
            catch (Exception ex)
            {
                Util.Util.showErrorMessageSwal(Page, "Error", ex.Message);
            }
        }
        protected void Info(object sender, EventArgs e)
        {
            try
            {
                string[] values = ((LinkButton)sender).CommandArgument.Split(';');
                string id = values[0];
                string name = values[1];
                string age = values[2];
                string type = values[3];

                Response.Redirect(string.Format("Page2?name={0}&age={1}&type={2}", name, age, type));

            }
            catch (Exception ex)
            {
                Util.Util.showErrorMessageSwal(Page, "Error", ex.Message);
            }
        }
        #endregion
        #region Form
        protected void LoadTypeDdl()
        {
            try
            {
                ddlType.Items.Clear();
                ddlType.Items.Add(new ListItem("Select type", "0"));
                var client = new RestClient(UrlService + "Types");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = JsonConvert.DeserializeObject<ServiceTypesResponse>(response.Content);
                    if (result.success)
                    {
                        foreach (var item in result.data)
                        {
                            ddlType.Items.Add(new ListItem(item.description, item.type.ToString()));
                        }
                    }
                    else
                    {
                        Util.Util.showWarningMessageSwal(Page, "Warning", result.message);
                    }
                }
                else
                {
                    Util.Util.showWarningMessageSwal(Page, "Warning", "Service response isn't good");
                }
            }
            catch (Exception ex)
            {
                Util.Util.showErrorMessageSwal(Page, "Error", ex.Message);
            }
        }
        protected void ClearForm()
        {
            try
            {
                txtId.Text = string.Empty;
                txtName.Text = string.Empty;
                txtAge.Text = string.Empty;
                ddlType.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                Util.Util.showErrorMessageSwal(Page, "Error", ex.Message);
            }
        }
        protected void NewForm(object sender, EventArgs e)
        {
            try
            {
                hddIdPerson.Value = "";
                txtId.ReadOnly = false;
                ClearForm();
                Util.Util.ShowModal(Page, "modalForm");
            }
            catch (Exception ex)
            {
                Util.Util.showErrorMessageSwal(Page, "Error", ex.Message);
            }
        }
        protected void SaveForm(object sender, EventArgs e)
        {
            try
            {
                string error = "";
                if (string.IsNullOrEmpty(txtId.Text.Trim()))
                    error += "Id field is mandatory.<br/>";
                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                    error += "Name field is mandatory.<br/>";
                if (string.IsNullOrEmpty(txtAge.Text.Trim()))
                    error += "Age field is mandatory.<br/>";
                if (ddlType.SelectedValue == "0" || ddlType.SelectedValue == null)
                    error += "Type field is mandatory.<br/>";

                if (error == "")
                {
                    PersonModel obj = new PersonModel()
                    {
                        id = Convert.ToInt32(txtId.Text),
                        name = txtName.Text,
                        age = Convert.ToInt32(txtAge.Text),
                        type = new TypeModel()
                        {
                            type = Convert.ToInt32(ddlType.SelectedValue)
                        }
                    };

                    JObject oRequest = JObject.FromObject(obj);
                    var client = new RestClient(UrlService + "Person");
                    client.Timeout = -1;

                    var method = (hddIdPerson.Value != "") ? Method.PUT : Method.POST;

                    var request = new RestRequest(method);
                    request.AddHeader("content-type", "application/json");
                    request.AddParameter("application/json", oRequest, ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    Console.WriteLine(response.Content);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = JsonConvert.DeserializeObject<ServiceResponse>(response.Content);
                        if (result.success)
                        {
                            Util.Util.showSuccessMessageSwal(Page, "Success", result.message);
                            GetPersons();
                        }
                        else
                        {
                            Util.Util.showWarningMessageSwal(Page, "Warning", result.message);
                        }
                    }
                    else
                    {
                        Util.Util.showWarningMessageSwal(Page, "Warning", "Service response isn't good");
                    }

                }
                else
                {
                    Util.Util.showWarningMessageSwal(Page, "Warning", error);
                }
            }
            catch (Exception ex)
            {
                Util.Util.showErrorMessageSwal(Page, "Error", ex.Message);
            }

        }
        #endregion
    }
}
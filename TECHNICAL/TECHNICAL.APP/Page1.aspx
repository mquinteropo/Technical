<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="TECHNICAL.APP.Page_1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Panel" class="panel panel-primary">
        <div class="panel-heading">
            <div class="row">
                <div class="col-lg-4">
                    <span class="glyphicon glyphicon-list-alt " aria-hidden="true"></span>&nbsp; &nbsp;Persons
                </div>
                <div style="text-align: center">
                    <asp:LinkButton ID="LinkButton1" OnClick="NewForm" runat="server" CausesValidation="false"><div style="margin-right: 10px;"><span class="glyphicon glyphicon-plus pull-right" style="color:white;" aria-hidden="true" data-toggle="tooltip" data-placement="right" title="Add"></span></div></asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="table-responsive">
                <asp:HiddenField ID="idUser" runat="server" />
                <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <table id="tableList" class="table table-striped  table-hover table-condensed cell-border">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Name</th>
                                    <th>Age</th>
                                    <th>Type</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="listPersons" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("id")%></td>
                                            <td><%#Eval("name")%> </td>
                                            <td><%#Eval("age")%></td>
                                            <td><%#Eval("type.description")%></td>
                                            <td>
                                                <asp:LinkButton ID="btnEdit"  OnClick="Edit" tile="Edit" CausesValidation="false" runat="server" CssClass="btn btn-warning" CommandArgument='<%#Eval("id")  + ";" + Eval("name") + ";" + Eval("age") + ";" + Eval("type.type")%>'><i class="fa-solid fa-pen"></i></asp:LinkButton>
                                                <asp:LinkButton ID="btnDelete" OnClick="Delete" tile="Delete" CausesValidation="false" runat="server" CssClass="btn btn-danger" CommandArgument='<%#Eval("id")%>'><i class="fa-solid fa-trash-can"></i></asp:LinkButton>
                                                <asp:LinkButton ID="btnChar"  OnClick="Info" tile="Info" CausesValidation="false" runat="server" CssClass=' <%#Eval("type.type").ToString() != "1" ? "hide" : "btn btn-info" %>' CommandArgument='<%#Eval("id")  + ";" + Eval("name") + ";" + Eval("age") + ";" + Eval("type.description")%>'><i class="fa-solid fa-chart-line"></i></asp:LinkButton>
                                            </td>


                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <!-- Modal -->

    <div id="modalForm" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" id="txtTitle" runat="server"></h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdateModal" runat="server">
                        <ContentTemplate>
                            <div class="modal-body">
                                <asp:HiddenField ID="hddIdPerson" runat="server" />
                                <div class="form-group">
                                    <label>Id:</label>
                                    <asp:TextBox ID="txtId" TextMode="Number" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Name:</label>
                                    <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Age:</label>
                                    <asp:TextBox ID="txtAge" TextMode="Number" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Type:</label>
                                    <asp:DropDownList runat="server" id="ddlType" CssClass="form-control combo"></asp:DropDownList>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <div class="row">
                        <div class="col-md-6">
                            <asp:LinkButton ID="btnGuardar" runat="server" OnClick="SaveForm"
                                CssClass="btn btn-success btn-block"><span class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></span> Save
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-6">
                            <button type="button" class="btn btn-success btn-block" data-dismiss="modal"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span>Close</button>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </div>

</asp:Content>

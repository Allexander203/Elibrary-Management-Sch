<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminpublishermanagement.aspx.cs" Inherits="SchoolApp.adminpublishermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">    
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();
           
        }); 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="p-3">
                            <div class="d-grid gap-2">
                                <div class="row">
                                    <div class="col">
                                        <center>
                                           <h4>Publisher Details</h4>
                                        </center>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">
                                        <center>
                                         <img width="100px" src="images/open-book%20(1).png" />
                                        </center>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">
                                        <hr>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <label>Publisher ID</label>
                                        <div class="form-group">
                                            <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="ID"></asp:TextBox>
                                                <asp:Button class="btn btn-primary" ID="Button2"  runat="server" Text="Search" OnClick="Button2_Click" />
                                                </div>
                                            </div>
                                    </div>
                                    <div class="col-md-8">
                                        <label>Publisher Name</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Publisher Name"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class ="col-4">
                                        <div class="d-grid gap-2">
                                        <asp:Button  class="btn btn-success " ID="Button3" runat="server" Text="Add" OnClick="Button3_Click" />
                                        </div>
                                    </div>
                                    <div class ="col-4">
                                        <div class="d-grid gap-2">
                                        <asp:Button  class="btn btn-warning  " ID="Button4" runat="server" Text="Update" OnClick="Button4_Click" />
                                        </div>
                                    </div>
                                     <div class ="col-4">
                                         <div class="d-grid gap-2">
                                        <asp:Button  class="btn btn-danger " ID="Button5" runat="server" Text="Delete" OnClick="Button5_Click" />
                                         </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

             <div class="col-md-7">

                 <div class="card">
                    <div class="card-body">
                        <div class="p-3">
                            <div class="d-grid gap-2">
                                <div class="row">
                                    <div class="col">
                                        <center>
                                           <img width="100px" src="images/books%20(1).png" />
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <center>
                                           <h4>Publisher List</h4>
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <hr>
                                    </div>
                                </div>
                                
                                <div class="row">
                                    <div class="col">
                                        
                                        <asp:GridView class="table table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                                            <Columns>
                                                <asp:BoundField DataField="publisher_id" HeaderText="Publisher ID" ReadOnly="True" SortExpression="publisher_id" />
                                                <asp:BoundField DataField="publisher_name" HeaderText="Publisher Name" SortExpression="publisher_name" />
                                                <asp:BoundField DataField="publisher_history" HeaderText="Publisher History" SortExpression="publisher_history" />
                                            </Columns>
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibrary_DBConnectionString %>" SelectCommand="SELECT * FROM [publisher]"></asp:SqlDataSource>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </div>


        </div>
    </div>

</asp:Content>

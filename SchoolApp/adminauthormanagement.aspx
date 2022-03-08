<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="SchoolApp.adminauthormanagment" %>

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
                                           <h4>Author Details</h4>
                                        </center>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">
                                        <center>
                                           <img width="100px" src="images/writer.png" />
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
                                        <label>Author ID</label>
                                        <div class="form-group">
                                            <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="ID"></asp:TextBox>
                                                <asp:Button class="btn btn-primary" ID="Button2"  runat="server" OnClick="Button2_Click" Text="Search" />
                                                </div>
                                            </div>
                                    </div>
                                    <div class="col-md-8">
                                        <label>Author Name</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Author Name"></asp:TextBox>
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
                                        <asp:Button  class="btn btn-danger " ID="Button1" runat="server" Text="Delete" OnClick="Button1_Click" />
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
                                           <h4>Your Issued Books</h4>
                                                <asp:Label class="badge rounded-pill bg-info text-dark" ID="Label2" runat="server" Text="Your books info"></asp:Label>
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
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibrary_DBConnectionString %>" SelectCommand="SELECT * FROM [author]"></asp:SqlDataSource>
                                        <asp:GridView class="table table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                            <Columns>
                                                <asp:BoundField DataField="author_id" HeaderText="Author ID" ReadOnly="True" SortExpression="author_id" />
                                                <asp:BoundField DataField="author_name" HeaderText="Author Name" SortExpression="author_name" />
                                            </Columns>
                                        </asp:GridView>
                                        
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

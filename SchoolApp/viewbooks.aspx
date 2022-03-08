<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewbooks.aspx.cs" Inherits="SchoolApp.viewbooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">

            <div class="col-sm-12">
                <center>
                    <h3 class="text-light">Available Books</h3>
                </center>
                <img width="100px" src="images/open-book%20(2).png" />
                <div class="row">
                    <div class="col-sm-12 col-md-12">
                        <asp:Panel class="alert alert-success" role="alert" ID="Panel1" runat="server" Visible="False">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </asp:Panel>
                    </div>
                </div>
                <br />
                <div class="row ">
                    <div class="card">
                        <div>
                            <div class="p-1">
                                <div class="d-grid gap-2">
                                    <div class="row">
                                        <div class="col">
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibrary_DBConnectionString %>" SelectCommand="SELECT * FROM [book_info]"></asp:SqlDataSource>

                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col">

                                            <asp:GridView class="table table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                                <Columns>
                                                    <asp:BoundField DataField="book_id" HeaderText="ID на книгата" SortExpression="book_id" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div class="container-fluid">
                                                                <div class="row">
                                                                    <div class="col-lg-10">
                                                                        <div class="row">
                                                                            <div class="col-12">
                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                                            </div>
                                                                        </div>

                                                                        <div class="row">
                                                                            <div class="col-12">
                                                                                Издател:
                                                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                                &nbsp;| Жанр:
                                                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                                                &nbsp;| Език:
                                                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>

                                                                            </div>
                                                                        </div>

                                                                        <div class="row">
                                                                            <div class="col-12">
                                                                                Издател:
                                                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                                &nbsp;| Дата на издаване:
                                                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publisher_date") %>'></asp:Label>
                                                                                &nbsp;| Страници:
                                                                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("num_of_pages") %>'></asp:Label>
                                                                                &nbsp;| Издание:
                                                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>

                                                                            </div>
                                                                        </div>

                                                                        <div class="row">
                                                                            <div class="col-12">
                                                                                Цена:
                                                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                                &nbsp;| Наличност:
                                                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                                &nbsp;| Налични:
                                                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                            </div>
                                                                        </div>

                                                                        <div class="row">
                                                                            <div class="col-12">
                                                                                Описание:
                                                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("description") %>'></asp:Label>

                                                                            </div>
                                                                        </div>

                                                                    </div>

                                                                    <div class="col-lg-2">
                                                                        <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img") %>' />
                                                                    </div>

                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

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
    </div>


    </asp:GridView>
</asp:Content>

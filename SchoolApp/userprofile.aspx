<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="SchoolApp.userprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">    
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable();

        });
        imgInp.onchange = evt => {
            const [file] = imgInp.files
            if (file) {
                blah.src = URL.createObjectURL(file)
            }
        }
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
        var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl)
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="p-3">
                            <div class="d-grid gap-2">
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <h4>Профил</h4>
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <center>

                                            <img id="output" width="100px" src="images/account.png" />

                                            <span>Статус</span>
                                            <asp:Label class="badge rounded-pill bg-info text-dark" ID="Label1" runat="server" Text="Good"></asp:Label>
                                        </center>
                                    </div>
                                </div>
                                <asp:Label class="badge bg-light text-dark" ID="Label3" runat="server" Text="Снимка на профила"></asp:Label>

                                <div class="row">
                                    <div class="col">
                                        <asp:FileUpload accept="image/*" onchange="loadFile(event)" CssClass="form-control" ID="FileUpload1" runat="server" />
                                        <script>
                                            var loadFile = function (event) {
                                                var output = document.getElementById('output');
                                                output.src = URL.createObjectURL(event.target.files[0]);
                                                output.onload = function () {
                                                    URL.revokeObjectURL(output.src)
                                                }
                                            };
                                        </script>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Име</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Име"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <label>Дата на раздане</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Password" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <label>Телефонен номер</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Телефонен номер"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <label>Имейл</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <label>Град</label>
                                        <div class="form-group">
                                            <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
                                                <asp:ListItem Text="Избери" Value="Select" />
                                                <asp:ListItem Text="София" Value="Sofia" />
                                                <asp:ListItem Text="Пловдив" Value="Plovdiv" />
                                                <asp:ListItem Text="Варна" Value="Varna" />
                                                <asp:ListItem Text="Бургас" Value="Burgas" />
                                                <asp:ListItem Text="Стара Загора" Value="St. Zagora" />
                                                <asp:ListItem Text="В. Търново" Value="V. Turnovo" />
                                                <asp:ListItem Text="Видин" Value="Vidin" />
                                                <asp:ListItem Text="Враца" Value="Vratsa" />
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <label>Град</label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="Град" />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <label>Пинкод</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Пинкод" TextMode="Number" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <label>Адрес</label>
                                            <div class="form-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Адрес" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <center>
                                        <span class="badge rounded-pill bg-info text-light">Login Credentials</span>
                                    </center>
                                    <div class="col-md-4">
                                        <label>ID</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="ID" ReadOnly="True" />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <label>Стара парола</label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="Парола" ReadOnly="True" />
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <label>Нова парола</label>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="Парола" />
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-8 mx-auto">
                                            <center>
                                                <div class="form-group">
                                                    <asp:Button class="btn btn-primary btn-lg" Style="margin-top: 1.7rem !important;" ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
                                                </div>
                                            </center>
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
                                            <div class="col-lg-2">
                                            </div>

                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <h4>Взети книги</h4>
                                           
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibrary_DBConnectionString %>" SelectCommand="SELECT * FROM [book_issuing]"></asp:SqlDataSource>

                                            <asp:Label class="badge rounded-pill bg-info text-dark" ID="Label2" runat="server" Text="Книги, дадени под наем"></asp:Label>
                                            <asp:GridView ID="GridView1" class="table table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="member_id" HeaderText="ID" SortExpression="member_id" />
                                                    <asp:BoundField DataField="book_id" HeaderText="ID на книгата" SortExpression="book_id" />
                                                    <asp:BoundField DataField="book_name" HeaderText="Име на книгата" SortExpression="book_name" />
                                                    <asp:BoundField DataField="issue_date" HeaderText="Начална дата" SortExpression="issue_date" />
                                                    <asp:BoundField DataField="due_date" HeaderText="Крайна дата" SortExpression="due_date" />
                                                </Columns>
                                            </asp:GridView>
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <hr>
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

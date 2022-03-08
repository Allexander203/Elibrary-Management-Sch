<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookinventory.aspx.cs" Inherits="SchoolApp.adminbookinventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
        imgInp.onchange = evt => {
            const [file] = imgInp.files
            if (file) {
                blah.src = URL.createObjectURL(file)
            }
        }
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
                                            <h4>Детайли за книгата</h4>
                                        </center>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">
                                        <center>
                                            <img id="output" width="100px" src="images/publisher.png" />
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

                                    <div class="col-md-4">
                                        <label>ID</label>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="ID"></asp:TextBox>      
                                                <asp:Button class="form-control btn btn-primary" ID="Button3" runat="server" Text="Go" OnClick="Button3_Click" />
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-8">
                                        <label>Име на книгата</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control ms-1" ID="TextBox1" runat="server" placeholder="Book Name"></asp:TextBox>
                                        </div>
                                    </div>


                                </div>
                                <div class="row">

                                    <div class="col-md-4">
                                        <label>Език</label>
                                        <div class="form-group">
                                            <div class="input-group">

                                                <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">

                                                    <asp:ListItem Text="Bulgarian" Value="Bulgarian" />
                                                    <asp:ListItem Text="English" Value="English" />
                                                    <asp:ListItem Text="German" Value="German" />
                                                    <asp:ListItem Text="French" Value="French" />
                                                    <asp:ListItem Text="Chinese" Value="Chinese" />
                                                    <asp:ListItem Text="Japanese" Value="Japanese" />

                                                </asp:DropDownList>

                                            </div>
                                        </div>

                                        <label>Име на издателя</label>
                                        <div class="form-group">
                                            <div class="input-group">

                                                <asp:DropDownList class="form-control" ID="DropDownList3" runat="server" DataSourceID="SqlDataSource2" DataTextField="publisher_name" DataValueField="publisher_name">

                                                    <asp:ListItem Text="Publisher1" Value="Publisher1" />
                                                    <asp:ListItem Text="Publisher2" Value="Publisher2" />
                                                </asp:DropDownList>

                                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:elibrary_DBConnectionString %>" SelectCommand="SELECT [publisher_name] FROM [publisher]"></asp:SqlDataSource>

                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md-4">
                                        <label>Име на автора</label>
                                        <div class="form-group">
                                            <div class="input-group">

                                                <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">

                                                    <asp:ListItem Text="A2" Value="A2" />
                                                    <asp:ListItem Text="A1" Value="A1" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <label>Дата на публикуване</label>
                                        <div class="form-group">
                                            <div class="input-group">

                                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder=""></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="col-md-4">
                                        <label>Жанр</label>
                                        <div class="form-group">
                                            <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple">
                                                <asp:ListItem Text="Action" Value="Action" />
                                                <asp:ListItem Text="Adventure" Value="Adventure" />
                                                <asp:ListItem Text="Comic Book" Value="Comic Book" />
                                                <asp:ListItem Text="Self Help" Value="Self Help" />
                                                <asp:ListItem Text="Motivation" Value="Motivation" />
                                                <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                                                <asp:ListItem Text="Wellness" Value="Wellness" />
                                                <asp:ListItem Text="Crime" Value="Crime" />
                                                <asp:ListItem Text="Drama" Value="Drama" />
                                                <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                                <asp:ListItem Text="Horror" Value="Horror" />
                                                <asp:ListItem Text="Poetry" Value="Poetry" />
                                                <asp:ListItem Text="Personal Development" Value="Personal Development" />
                                                <asp:ListItem Text="Romance" Value="Romance" />
                                                <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                                                <asp:ListItem Text="Suspense" Value="Suspense" />
                                                <asp:ListItem Text="Thriller" Value="Thriller" />
                                                <asp:ListItem Text="Art" Value="Art" />
                                                <asp:ListItem Text="Autobiography" Value="Autobiography" />
                                                <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                                                <asp:ListItem Text="Health" Value="Health" />
                                                <asp:ListItem Text="History" Value="History" />
                                                <asp:ListItem Text="Math" Value="Math" />
                                                <asp:ListItem Text="Textbook" Value="Textbook" />
                                                <asp:ListItem Text="Science" Value="Science" />
                                                <asp:ListItem Text="Travel" Value="Travel" />
                                            </asp:ListBox>
                                        </div>
                                    </div>

                                </div>

                                <div class="row">

                                    <div class="col-md-4">
                                        <label>Издание</label>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Edition"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <label>Цена</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Book cost" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <label>Страници</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Pages" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>

                                <div class="row">

                                    <div class="col-md-4">
                                        <label>Наличност</label>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Actual Stock"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <label>Налични</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Current Stock" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <label>Issued Book</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Issued Book" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <label>Описание</label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox14" runat="server" placeholder="Book Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>

               

                                <div class="row">
                                    <div class="col-4">
                                        <div class="d-grid gap-2">
                                            <asp:Button class="btn btn-primary" ID="Button4" runat="server" Text="Добави" OnClick="Button4_Click" />
                                        </div>
                                    </div>
                                    <div class="col-4">
                                        <div class="d-grid gap-2">
                                            <asp:Button class="btn btn-warning" ID="Button1" runat="server" Text="Актуализирай" OnClick="Button1_Click" />
                                        </div>
                                    </div>
                                    <div class="col-4">
                                        <div class="d-grid gap-2">
                                            <asp:Button class="btn btn-danger" ID="Button2" runat="server" Text="Изтрий" OnClick="Button2_Click" />
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
                                            <h4>Инвентар</h4>
                                        </center>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibrary_DBConnectionString %>" SelectCommand="SELECT * FROM [book_info]"></asp:SqlDataSource>
                                        <hr>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col">

                                        <asp:GridView class="table table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                            <Columns>
                                                <asp:BoundField DataField="book_id" HeaderText="ID" SortExpression="book_id" />           
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

                                                                            Автор:
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

</asp:Content>

<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Leave_Updation.aspx.vb" Inherits="WebAppHRMS.LeaveApplication_Leave_Updation_70eeaa418351" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="server">

    <script type="text/javascript">
        function JSFunctionValidate() {

            if (document.getElementById("<%=txtcategory.ClientID%>").value === "" && document.getElementById("<%=txtreason.ClientID%>").value === "") {
                alert("fields are required");
                return false;
            }
            else {
                return true;
            }
        }
    </script>
    <script type="text/javascript">

        function checkNum() {

            if ((event.keyCode > 64 && event.keyCode < 91) || (event.keyCode > 96 && event.keyCode < 123) || event.keyCode == 8 || event.keyCode == 32)
                return true;
            else {
                alert("Please enter only char");
                return false;
            }

        }

    </script>


    <div>
        <%-- <div id="ifYes" style="display:none">--%>
        <table border="1" style="font-size: 10pt; font-family: 'Times New Roman'; height: 40px">
            <tr>
                <td>
                    <b>Category</b><input type="radio" checked="true" onclick="javascript:yesnoCheck();" name="yesno" id="yesCheck" runat="server" />

                </td>
                <td>
                    <b>Reason</b><input type="radio" onclick="javascript:yesnoCheck();" name="yesno" id="noCheck" runat="server" />

                </td>
            </tr>
            <tr id="cat_row1">
                <td>
                    <asp:Label ID="Label1" Font-Bold="true" runat="server" Text="Enter Category Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtcategory" onkeypress="return checkNum()" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr id="res_row1">
                <td>
                    <asp:Label ID="Label2" Font-Bold="true" runat="server" Text="Select Category Name"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_category" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr id="res_row2">
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Enter Reason"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtreason" onkeypress="return checkNum()" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="res_row3" style="text-align: center;">
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Submit" OnClientClick="return JSFunctionValidate()" />
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="Exit" />
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">

        yesnoCheck();
        function yesnoCheck() {
            if (document.getElementById('<%=yesCheck.ClientID%>').checked) {
                displayCat('table-row');
                displayReason('none');

            }
            else {
                displayCat('none');
                displayReason('table-row');
            }
        }
        function displayReason(display) {
            document.getElementById('res_row1').style.display = display;
            document.getElementById('res_row2').style.display = display;
            // document.getElementById('res_row3').style.display=display;
        }
        function displayCat(display) {
            document.getElementById('cat_row1').style.display = display;
            //    document.getElementById('res_row3').style.display=display;
        }

    </script>
</asp:Content>

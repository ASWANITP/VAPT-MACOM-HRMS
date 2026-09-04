<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="previous_empdetails.aspx.vb" Inherits="WebAppHRMS.previous_empdetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Employee Previous Details</title>
</head>

    <script language="javascript">

    function Button1_onclick() {
    window.open("../HRM_leave_rec_sanMAC.aspx", '_self');
        }

</script>
<body>
    <asp:Label ID="lblTitle" runat="server" Font-Names="Verdana" Font-Size="Large" ForeColor="#2E4053" Text="Leave Balance & Availed Report" />

    <form id="form1" runat="server">
           <div style="text-align: center">
          <div style="text-align: center">
              &nbsp;<table>
                <%--  <tr>
                    
                      <td style="width: 100px; text-align: left">
                          <input id="Button1" style="width: 105px" type="button" value="Exit" onclick="return Button1_onclick()" /></td>
                  </tr>--%>
              </table>
          </div>
          <asp:Panel ID="PanelHoNSS" runat="server" Width="90%">
          </asp:Panel>

      </div>
  </form>
</body>
</html>

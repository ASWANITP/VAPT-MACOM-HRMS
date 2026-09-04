<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="add_vda.aspx.vb" Inherits="WebAppHRMS.add_vda" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/control/uc_date.ascx" TagName="uc_date" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">

        var cs = cont_name.split("txt");
        function cmd_exit_onclick() {
            window.open('../../home.aspx', '_self')
        }
        function showalert() {
            window.open('../../home.aspx', '_self')
        }
        //function checkvalue()
        //{
        //       if (isNaN(document.getElementById(cs[0]+"txt_newda").value) || document.getElementById(cs[0]+"txt_newda").value=="")
        //        {
        //              alert("Wrong Entry");
        //              document.getElementById(cs[0]+"txt_newda").value=""
        //              document.getElementById(cs[0]+"txt_newda").focus()
        //              return false;
        //        }
        //    
        //}
        function isNumberKey(event) {

            var charcode = (event.which) ? event.which : event.keyCode
            if (charcode > 31 && (charcode < 48 || charcode > 57)) {
                return false;
            }
            else
                return true;
        }
        //function check_dt()
        //{
        // alert("Select Date From Calender")
        // return false;
        //}

        //function dt_check()
        //{
        //var mydate=new Date()
        //var year=mydate.getYear()
        //if (year < 1000)
        //year+=1900
        //var day=mydate.getDay()
        //var month=mydate.getMonth()
        //var daym=mydate.getDate()
        //if (daym<10)
        //daym="0"+daym
        // var montharray=new Array("Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec")
        // mydate=daym+"/"+montharray[month]+"/"+year
        //    var dbd
        //    var day3;
        //    var month3;
        //    var year3;

        //    value3 = document.getElementById(cs[0]+"dt_effect").value;
        //    day3= value3.substring (0, value3.indexOf ("/"));
        //    month3 = value3.substring (value3.indexOf ("/")+1, value3.lastIndexOf ("/"));
        //    year3 = value3.substring (value3.lastIndexOf ("/")+1, value3.length);

        //    var value4 = mydate;
        //    var day4 = value4.substring (0, value4.indexOf ("/"));
        //    var month4 = value4.substring (value4.indexOf ("/")+1, value4.lastIndexOf ("/"));
        //    var year4 =value4.substring (value4.lastIndexOf ("/")+1, value4.length);
        // 
        //    date3 = year3+"/"+month3+"/"+day3;
        //    date4 = year4+"/"+month4+"/"+day4;
        //    firstDate = Date.parse(date3)
        //    secondDate= Date.parse(date4)
        //    msPerDay = 24 * 60 * 60 * 1000
        //    dbd = Math.round((secondDate.valueOf()-firstDate.valueOf())/ msPerDay) ;
        //    if(dbd<-365)
        //    {
        //     alert("You can only Select 1 year future Date");
        //     return false; 
        //    }
        //    if(dbd>365)
        //    {
        //     alert("You can only Select 1 year Back Date");
        //     return false; 
        //    }
        // }
        // 
        function cmb_search_onclick() {

        }

        // ]]>
    </script>

    <div style="text-align: center" runat="server" id="Div1">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <table id="tbl_imp" border="1" style="width: 600px; height: 117px" runat="server">
                    <tr>
                        <td style="width: 573px; text-align: left">Present VDA :
                        </td>
                        <td colspan="2" style="width: 305px; text-align: center">
                            <asp:TextBox ID="txt_preda" runat="server" ReadOnly="True" Width="256px"></asp:TextBox></td>
                        <td colspan="1" style="width: 69px; text-align: center"></td>
                    </tr>
                    <tr>
                        <td style="width: 573px; text-align: left; height: 12px;">Employee Code</td>
                        <td style="width: 305px; text-align: center; height: 6px;" colspan="2">
                            <asp:TextBox ID="txt_emp" runat="server" MaxLength="6" Width="256px"></asp:TextBox></td>
                        <td style="width: 69px; height: 12px; text-align: center">
                            <asp:Button ID="btn_search" runat="server" Text="SEARCH" OnClick="btn_search_Click" />
                            <%-- <input id="btn_search" type="button" value="SEARCH" onclick="return cmb_search_onclick()" />--%></td>
                    </tr>
                    <tr id="msg_row" runat="server">

                        <td style="height: 14px; text-align: left" colspan="3">
                            <div id="ddd">
                                <asp:Label ID="lbl_msg" runat="server" Font-Bold="True" ForeColor="Blue" Width="496px" CssClass="csslab" Font-Size="Small" Font-Underline="True" Height="24px"></asp:Label>&nbsp;
                            </div>
                        </td>
                        <td colspan="1" rowspan="2" style="width: 69px; text-align: left"></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 26px">
                            <asp:RadioButton ID="ADD" runat="server" Font-Bold="True" GroupName="AA" OnCheckedChanged="ADD_CheckedChanged" Checked="true" /><asp:Label
                                ID="Label2" runat="server" Font-Bold="True" Text="ADD" Width="1px"></asp:Label>
                            &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                    <asp:RadioButton ID="DELTE" runat="server" Font-Bold="True" GroupName="AA" OnCheckedChanged="DELTE_CheckedChanged" /><asp:Label
                        ID="Label1" runat="server" Font-Bold="True" Text="DELETE" Width="24px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Height="24px" Width="83px" Style="cursor: hand" OnClientClick="return dt_check()" />
                            <input id="cmd_exit" style="width: 73px; cursor: hand;" type="button" value="EXIT" onclick="return cmd_exit_onclick()" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    <br />
    <br />
    <br />
    <br />
</asp:Content>


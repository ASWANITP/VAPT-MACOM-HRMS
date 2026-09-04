<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/edp.Master" CodeBehind="hrm_compulsaryleave_report.aspx.vb" Inherits="WebAppHRMS.hrm_compulsaryleave_report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    <style>
        
        .form-container {
            padding: 20px 30px;
            border-radius: 12px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.08);
            background: linear-gradient(to right, #b3cde0, #f0f8ff); /* soft blue fade */
            width: 400px;
            margin: 50px auto;
             height: 150px; 
            text-align: center;
        }
        .form-group input[type="text"] {
            width: 100%;
            padding: 8px 10px;
            border: 1px solid #ccc;
            border-radius: 6px;
            font-size: 14px;
            text-align: center;
        }
        .button-group {
            margin-top: 30px;
            display: flex;
            text-align: center;
            justify-content: center;
        }
            .button-group input,
            .button-group asp\:Button {
                width: 28%;
                padding: 10px;
                font-size: 14px;
                border: none;
                border-radius: 6px;
                cursor: pointer;
                color: #fff;
            }
           
        
        .btn-confirm {
            background-color: #17508A;
            color: #ffffff;
            padding: 10px 20px;
            border-radius: 6px;
            border: none;
            font-weight: bold;
            margin-right: 10px;
            cursor: pointer;
            transition: background-color .3s ease;
        }
        .btn-exit {
            background-color: #17508A;
            transition: background-color .3s ease;
            color: #ffffff;
            font-weight: bold;
        }
        .form-group-row {
    display: flex;
    justify-content: space-between;
    gap: 10px;
}

    .form-group-inline label {
        display: block;
        font-weight: bold;
        margin-bottom: 5px;
        color: #1e4d5b;
    }

    .form-group-inline .form-control {
        width: 50%;
        padding: 10px 25px;
        border: 1px solid #ccc;
        border-radius: 6px;
        font-size: 14px;
}

        
    </style>
<script language="javascript" type="text/javascript">
    // <!CDATA[
    var con = header.split('txt');

    function cmd_exit_onclick() {

        window.open('../home.aspx', '_self');
    }
    
</script>
     <h2 style="color: #1e4d5b; margin-bottom: -30px; font-size: 20px; text-transform: uppercase;  text-align: center;">
       Employee Compulsary Leave Report</h2>
   <div class="form-container">
       <%--<h2 style="color: #1e4d5b; margin-bottom: 20px; font-size: 20px; text-transform: uppercase;">
             Employee Compulsary Leave Report</h2>--%>

       

       <div class="form-group-row">
            <div class="form-group-inline">
            <label for="txtfdt">From Date</label>
            <asp:TextBox ID="txtfdt" runat="server" CssClass="form-control" />
        </div>

       <div class="form-group-inline">
            <label for="txttdt">To Date</label>
            <asp:TextBox ID="txttdt" runat="server" CssClass="form-control" />
        </div>
           </div>
                <div class="button-group">
            <asp:Button ID="Button1" runat="server" Text="CONFIRM" CssClass="btn-confirm" />
            <input type="button" value="EXIT" class="btn-exit" onclick="cmd_exit_onclick()" />
        </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfdt" Format="dd/MMM/yyyy" />
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttdt" Format="dd/MMM/yyyy" />
    </div>
</asp:Content>


<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Rd_data.aspx.vb"  Inherits="WebAppHRMS.Auction_Listed_pledges_ad40ce216603" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style>

        div{
            margin:0 auto;
        }
    </style>
    
    <script language="javascript" type="text/javascript">


   function nextpage1(BRID,fdat)
   {

   window.open('branch_drill.aspx?BRID='+BRID+'&fdat='+fdat+'','_self');
   }
    function nextpage2(BRID,fdat)
   {
   window.open('interest_remited.aspx?BRID='+BRID+'&fdat='+fdat+'','_self');
   }
    function nextpage3(BRID,fdat)
   {
   window.open('normal_drill.aspx?BRID='+BRID+'&fdat='+fdat+'','_self');
   }
       function nextpage4(BRID,fdat)
   {
   window.open('auction_settled_drill.aspx?BRID='+BRID+'&fdat='+fdat+'','_self');
   }
       function nextpage5(BRID,fdat)
   {
   window.open('receieved_ho_drill.aspx?BRID='+BRID+'&fdat='+fdat+'','_self');
   }
       function nextpage6(BRID,fdat)
   {
   window.open('balance_drill.aspx?BRID='+BRID+'&fdat='+fdat+'','_self');
   }
     
     
</script>
    
    
    
</head>

<%--//ok--%>
<body style="text-align: center">
    <form id="form1" runat="server">
        <div>
    <asp:Panel style="LEFT: 0px; POSITION: relative; TOP: 0px" id="Panel1" runat="server" Width="1000px">
        </asp:Panel>
            </div>
    </form>
</body>
</html>

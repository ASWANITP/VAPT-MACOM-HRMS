
Partial Class HRM_Visual_0ceb7a503821
    Inherits System.Web.UI.Page

    Protected Sub btnVision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVision.Click
        Response.Redirect("Library/Vission.ppt")
    End Sub

    Protected Sub btnMoneyTransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMoneyTransfer.Click
        Response.Redirect("Library/Moneytransfer.ppt")
    End Sub

    Protected Sub btnOutward_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOutward.Click
        Response.Redirect("Library/Outwardremittance.ppt")
    End Sub

    Protected Sub btnGoldCoin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGoldCoin.Click
        Response.Redirect("Library/GOLDCOIN.ppt")
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Response.Redirect("../home.aspx")
    End Sub

    Protected Sub btnCompProfile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCompProfile.Click
        Response.Redirect("Library/mantrafinal.wma")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("Library/GoldLoanSchemes.ppt")
    End Sub

    Protected Sub btnGLRecovery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGLRecovery.Click
        Response.Redirect("Library/GoldLoanRecovery.ppt")
    End Sub
    Protected Sub btnStrongPlan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStrongPlan.Click
        Response.Redirect("Library/StrongRoomPlan.pdf")
    End Sub

    'Protected Sub btnDeposit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeposit.Click
    '    Response.Redirect("Library/DEPOSIT.ppt")
    'End Sub

    'Protected Sub btnInsurance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsurance.Click
    '    Response.Redirect("Library/Insurance.ppt")
    'End Sub

    Protected Sub btnCustService_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCustService.Click
        Response.Redirect("Library/CustomerService.pptx")
    End Sub

    Protected Sub btnCommunication_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCommunication.Click
        Response.Redirect("Library/SuccessfulCommunication.ppt")
    End Sub

    Protected Sub cmd_induction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_induction.Click
        Response.Redirect("Library/Induction_Training.pptx")
    End Sub

    Protected Sub cmd_goldloan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_goldloan.Click
        Response.Redirect("Library/GL_Training PPT.pptx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim firm As String
        Dim fr_id As Integer
        firm = Session("firm_name")
        fr_id = Session("firm_id")
        Me.Label1.Text = firm
    End Sub
End Class

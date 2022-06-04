<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueCertificate.aspx.cs" Inherits="GUCera.IssueCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="lbl_issue_certificate" runat="server" Text="Issue Certificate:"></asp:Label>
            <br />
            <asp:Label ID="lbl_sid" runat="server" Text="student id:"></asp:Label>
            <asp:TextBox ID="txt_sid" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_cid" runat="server" Text="Course id:"></asp:Label>
            <asp:TextBox ID="txt_cid" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_issue_date" runat="server" Text="Issue Date and Time:"></asp:Label>
            <asp:TextBox ID="txt_issue_day" runat="server" Columns="2"></asp:TextBox>
            <asp:TextBox ID="txt_issue_month" runat="server" Columns="2"></asp:TextBox>
            <asp:TextBox ID="txt_issue_year" runat="server" Columns="4"></asp:TextBox>
            <asp:Label ID="lbl_date_format" runat="server" Text="dd MM yyyy" ForeColor="Gray"></asp:Label>
            <asp:TextBox ID="txt_issue_hour" runat="server" Columns="2"></asp:TextBox>
            <asp:TextBox ID="txt_issue_minute" runat="server" Columns="2"></asp:TextBox> 
            <asp:Label ID="lbl_time_format" runat="server" Text="hh:mm" ForeColor="Gray"></asp:Label>
            &nbsp;<asp:DropDownList ID="ddm_pm_am" runat="server">
                <asp:ListItem Selected="True">AM</asp:ListItem>
                <asp:ListItem>PM</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="btn_issue" runat="server" Text="Issue" OnClick="Issue"/>
            <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="Back"/>
            <br />
        </div>
    </form>
</body>
</html>

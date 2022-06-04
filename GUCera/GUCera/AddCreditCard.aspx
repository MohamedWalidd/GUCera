<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCreditCard.aspx.cs" Inherits="GUCera.AddCreditCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="CreditNumber" runat="server"></asp:TextBox>
        Enter Credit Card Number<div>
        </div>
        <asp:TextBox ID="HolderName" runat="server"></asp:TextBox>
        Enter Card Holder Name<div>
        </div>
        <asp:TextBox ID="Exp_Date_Year" runat="server"></asp:TextBox>
        Enter Expiry Date Year<br />
        <asp:TextBox ID="Exp_Date_Month" runat="server"></asp:TextBox>
        Enter Expiry Date Month<br />
        <asp:TextBox ID="Exp_Date_Day" runat="server"></asp:TextBox>
        Enter Expiry Date Day<br />
        <asp:TextBox ID="C" runat="server"></asp:TextBox>
        Enter CVV <p>
            <asp:Button ID="Submit" runat="server" OnClick="Button1_Click" Text="Submit" />
            <asp:Button ID="back" runat="server" OnClick="Back" Text="Back" />
        </p>
    </form>
</body>
</html>

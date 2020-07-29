<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modifyAccount.aspx.cs" Inherits="ParkingManagementClient.modifyAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-family:Calibri;background:#262626;font-size:20px;">
<center>  <br /><h1 style="color:#dcdcdc;font-size:35px;">MANAGE ACCOUNT DETAILS</h1>
   <br />
    <form id="form1" runat="server">
        <div style="background:#dcdcdc;border:2px solid #fff;width:350px;padding:40px 30px;">
             <h3 style="font-size:25px;">CURRENT PROFILE DETAILS ARE SHOWN BELOW</h3>  
            <br />
            Username :&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
&nbsp;Email Id :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;Password :&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="UPDATE" OnClick="Button1_Click" Width="122px" BackColor="#262626" ForeColor="white" Height="33px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px"/>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="DELETE ACCOUNT" OnClick="Button2_Click" Width="182px" BackColor="#262626" ForeColor="white" Height="33px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px"/>

            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="BACK" Width="122px" BackColor="#262626" ForeColor="white" Height="33px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px"/>

            <br />

             <br />

        </div>
    </form></center>
</body>
</html>

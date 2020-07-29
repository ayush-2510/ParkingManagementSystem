<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="ParkingManagementClient.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-family:Calibri;background:#262626;font-size:20px;"><center>
    <form id="form1" runat="server">
        <h1 style="color:#dcdcdc;font-size:35px;">USER REGISTRATION</h1></br>
        <div style="background:#dcdcdc;border:2px solid #fff;width:320px;padding:40px 30px;">    
        <h2 style="font-size:25px;">WELCOME TO ONLINE PARKING SYSTEM</h2><br />
           
            Username :&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Password :&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            Email :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp;<br />
            <br />
            
            <asp:Button ID="Button1" runat="server" Text="REGISTER" OnClick="Button1_Click" Width="122px" BackColor="#262626" ForeColor="white" Height="35px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px"/>
            <br />
            <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="LOGIN" Width="122px" BackColor="#262626" ForeColor="white" Height="35px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px"/><br />
            <br />
        </div>
   </form>
</body>
</html>

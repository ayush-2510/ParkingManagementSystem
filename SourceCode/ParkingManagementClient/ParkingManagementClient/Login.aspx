<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ParkingManagementClient.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body style="font-family:Calibri;background:#262626;font-size:20px;"><center>
    <form id="form1" runat="server">
   <br />
       <h1 style="color:#dcdcdc;font-size:35px;">WELCOME TO ONLINE PARKING MANAGEMENT SYSTEM</h1><br />
        <div style="background:#dcdcdc;border:2px solid #fff;width:320px;padding:40px 30px;">
        <h3>PLEASE LOG IN TO BOOK A SLOT </h3>
        <br />
        
                Email :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                
                    <asp:TextBox ID="TextBox1" runat="server" Width="175px"></asp:TextBox>
               <br />
        <br />
               Password
                    :&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" Width="175px"></asp:TextBox>
            
              <br />
            <br />
        <br />
            
              <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="LOGIN" Width="122px" BackColor="#262626" ForeColor="white" Height="35px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px"/>
               
                    <br />
        <br />
               
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="SIGN UP" Width="122px" BackColor="#262626" ForeColor="white" Height="35px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px"/>
            
             
                    <br />
        <br />
            
             
                    <asp:Label ID="Label1" runat="server"></asp:Label>

        <br />

                
       
    </div>
    </form>
</body>
</html>

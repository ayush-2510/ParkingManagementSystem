<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSlots.aspx.cs" Inherits="ParkingManagementClient.ManageSlots" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-family:Calibri;background:#262626;font-size:20px;">
    
    <center>
    <form id="form1" runat="server">
        <div style="margin:1% 5% 0% 0%;float:right;">
        <div style="float: left; width: 350px; border: 3px solid #fff; padding: 12px 0px; background: #dcdcdc; margin: 0px 45px;"><h3>----- Add Slots -----</h3>
            Section :&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="67px"></asp:TextBox>
            <br />
            <br />
            Floor :&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Selected="True">1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Type :&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList3" runat="server">
                <asp:ListItem>Bicycle</asp:ListItem>
                <asp:ListItem Selected="True">2 Wheeler</asp:ListItem>
                <asp:ListItem>4 Wheeler</asp:ListItem>
                <asp:ListItem>6 Wheeler</asp:ListItem>
                <asp:ListItem>Heavy Vehicle</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Normal Charges :&nbsp; <asp:TextBox ID="TextBox3" runat="server" Height="17px" Width="121px"></asp:TextBox>
&nbsp; Rs.<br />
            <br />
            Overtime Charges :
            <asp:TextBox ID="TextBox4" runat="server" Height="16px" Width="119px"></asp:TextBox>
&nbsp; Rs.<br />
            <br />
            No. of Slots :&nbsp;
            <asp:TextBox ID="TextBox5" runat="server" Width="71px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="ADD SLOTS" OnClick="Button1_Click" Width="140px" BackColor="#262626" ForeColor="white" Height="40px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px" />
            </div>
            
        <div style="float: right;
                width: 320px;
                border: 3px solid #fff;
                padding: 12px 0px;
                background: #dcdcdc;
                margin: 0px 45px;"><h3>---- Remove Slots ----</h3>
            Section :&nbsp;&nbsp; 
            <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            Floor :&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            <br />
            <br />
            Type :
            <asp:DropDownList ID="DropDownList4" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            <br />
            <br />
            No. of Slots :
            <asp:TextBox ID="TextBox8" runat="server" Width="71px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="REMOVE SLOTS" Width="160px" BackColor="#262626" ForeColor="white" Height="40px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
        </div>
        </div>
        <div style="position:fixed;position:fixed;top: 620px;left: 40%;">            
            <asp:Button ID="Button7" runat="server" Text="VIEW BOOKINGS" Width="180px" BackColor="#dcdcdc" ForeColor="#262626" Height="40px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" OnClick="Button7_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="VIEW USERS" Width="160px" BackColor="#dcdcdc" ForeColor="#262626" Height="40px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" />
</div>
        <div style="position:fixed;position:fixed;top: 680px;left: 40%;">
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="LOG OUT" Width="140px" BackColor="#dcdcdc" ForeColor="#262626" Height="40px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="MANAGE ACCOUNT" Width="200px" BackColor="#dcdcdc" ForeColor="#262626" Height="40px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" />
        </div>
        
    </form></center>

</body>
</html>

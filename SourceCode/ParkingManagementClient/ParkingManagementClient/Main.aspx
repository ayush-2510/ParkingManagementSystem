<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="ParkingManagementClient.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 450px;
        }
        .auto-style2 {
            width: 231px;
        }
        .auto-style3 {
            width: 228px;
        }
        .auto-style5 {
            height: 23px;
        }
        td {
            text-align: left;
            padding:8px 0px;
            padding-left:12px;
        }
    </style>
</head>
<body style="font-family:Calibri;background:#262626"><center>
    <form id="form1" runat="server">
    <div>
        <h1 style="text-align:center;color:#dcdcdc;font-size:35px;">BOOKING PAGE</h1>
        <br />
        <div>
            <div style="float:left;margin:0% 4% 0% 11%;background:#dcdcdc;border:2px solid #fff;">
        <h2>BOOK A SLOT HERE :</h2>
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp; Section</td>
                <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="168px" AutoPostBack="true">
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp; Floor</td>
                <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Height="22px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="168px" AutoPostBack="true">
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp; Vehicle Type</td>
                <td>
                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="true" Width="168px" height="22px">
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp; Registration Number</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp; Arrival Time</td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" TextMode="Date"></asp:TextBox>
                    <br />
                    <br />
                    <asp:TextBox ID="TextBox6" runat="server" TextMode="Time"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp; Exit Time</td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server" TextMode="Date"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;<br />
                    <br />
                    <asp:TextBox ID="TextBox8" runat="server" TextMode="Time"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;">
                    <br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="BOOK SLOT" Width="170px" BackColor="#262626" ForeColor="white" Height="40px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br /></div>
        <div style="                float: right;
                margin: 0% 11% 0% 4%;
                height: 300px;
                background: #dcdcdc;
                border: 2px solid #fff;">
        <h2>CANCEL BOOKING :&nbsp; </h2>
            <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Booking Id</td>
                <td>
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2" style="text-align:center;">
                    <br />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="CANCEL" Width="170px" BackColor="#262626" ForeColor="white" Height="40px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px" />
                </td>
            </tr>
        </table>
                    <br />
                    <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
       <br /></div>
        <div style="position:fixed;top:520px;right:110px;"><asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="MANAGE ACCOUNT" Width="180px" BackColor="#dcdcdc" ForeColor="#262626" Height="40px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" />
     
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button5" runat="server" Text="MY BOOKINGS" OnClick="Button5_Click" Width="180px" BackColor="#dcdcdc" ForeColor="#262626" Height="40px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" />
            &nbsp;&nbsp;&nbsp;&nbsp;
     
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="LOG OUT" Width="180px" BackColor="#dcdcdc" ForeColor="#262626" Height="40px" BorderColor="DarkGray" BorderStyle="Solid" BorderWidth="3px" Font-Bold="True" /></div>
    </form></center>
</body>
</html>

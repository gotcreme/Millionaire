<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="Millionaire.Game" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Millionaire</title>
    <link href="/Style/Site.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="logimg">
            <img src="~/Resources/millionaire-logo.png" style="visibility:hidden"/>              
        </div>
        <table id="scoretable" runat="server">
            <tr>
                <td>
                    <asp:Button id="btnHelp1" CssClass="help help1 unfocus" runat="server" BorderStyle="None" OnClick="btnHelp1_Click"/>
                </td>
                <td>
                    <asp:Button id="btnHelp2" CssClass="help help2 unfocus" runat="server" BorderStyle="None" OnClick="btnHelp2_Click"/>
                </td>
                <td>
                    <asp:Button id="btnHelp3" CssClass="help help3 unfocus" runat="server" BorderStyle="None" OnClick="btnHelp3_Click"/>
                </td>
            </tr>
            <tr class="fire">
                <td class="c1">15</td>
                <td class="c2" colspan ="3">1 000 000</td>
            </tr>
            <tr>
                <td class="c1">14</td>
                <td class="c2" colspan ="3">500 000</td>
            </tr>
            <tr>
                <td class="c1">13</td>
                <td class="c2" colspan ="3">250 000</td>
            </tr>
            <tr>
                <td class="c1">12</td>
                <td class="c2" colspan ="3">125 000</td>
            </tr>
            <tr>
                <td class="c1">11</td>
                <td class="c2" colspan ="3">64 000</td>
            </tr>
            <tr class="fire">
                <td class="c1">10</td>
                <td class="c2" colspan ="3">32 000</td>
            </tr>
            <tr>
                <td class="c1">9</td>
                <td class="c2" colspan ="3">16 000</td>
            </tr>
            <tr>
                <td class="c1">8</td>
                <td class="c2" colspan ="3">8 000</td>
            </tr>
            <tr>
                <td class="c1">7</td>
                <td class="c2" colspan ="3">4 000</td>
            </tr>
            <tr>
                <td class="c1">6</td>
                <td class="c2" colspan ="3">2 000</td>
            </tr>
            <tr class="fire">
                <td class="c1">5</td>
                <td class="c2" colspan ="3">1 000</td>
            </tr>
            <tr>
                <td class="c1">4</td>
                <td class="c2" colspan ="3">500</td>
            </tr>
            <tr>
                <td class="c1">3</td>
                <td class="c2" colspan ="3">300</td>
            </tr>
            <tr>
                <td class="c1">2</td>
                <td class="c2" colspan ="3">200</td>
            </tr>
            <tr>
                <td class="c1">1</td>
                <td class="c2" colspan ="3">100</td>
            </tr>
        </table>
        <div id="question">
        <table id="qtable">
            <tr>             
                <td colspan="2">
                    <asp:Button CssClass="questpanel" ID="lblQuest" runat="server" BorderStyle="None" enabled="false"/>
                </td>
            </tr>
            <tr>
                <td><asp:Button CssClass="butA btnAnswer unfocus" ID="btnA" runat="server" BorderStyle="None" OnClick="btnA_Click"/></td>
                <td><asp:Button CssClass="butB btnAnswer unfocus" ID="btnB" runat="server" BorderStyle="None" OnClick="btnB_Click"/></td>

            </tr>
            <tr>
                <td><asp:Button CssClass="butC btnAnswer unfocus" ID="btnC" runat="server" BorderStyle="None" OnClick="btnC_Click"/></td>
                <td><asp:Button CssClass="butD btnAnswer unfocus" ID="btnD" runat="server" BorderStyle="None" OnClick="btnD_Click"/></td>

            </tr>
        </table>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IETTForm.aspx.cs" Inherits="Ders4.IETTForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <body>
        <form id="DurakBilgisiGetir" runat="server">
            <h1>IEET durak Bilgileri</h1>
                <div>
                    <div>
                        <h3>Otobüs Numarasını Giriniz</h3>
                        <input type="text" id="txtGetDurak" runat="server"/>
                        <asp:button name="GetDurak" ID="GetDurak" Text="Durak Bilgisi Getir" runat="server" OnClick="HandleDurak" />
                    </div>
            
                    <div id="txtresult" runat="server"></div>
                </div>
        </form>
    </body>
</html>

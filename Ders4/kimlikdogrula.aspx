<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kimlikdogrula.aspx.cs" Inherits="Ders4.kimlikdogrula" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
 <p style="background-color:antiquewhite">ABC kimya müşteri portaline hoşgeldiniz



</p>
<p> </p>
<form id="form1" runat="server" style="background-color:bisque">
<div>Kimlik No</div>
<div><input type="password" id="txtTCKimlikNo" runat="server" /></div>
<div>Ad</div>
<div><input type="text" id="txtAd" runat="server"/></div>
<div>soyAd</div>
<div><input type="text" id="txtSoyad" runat="server" /></div>
<div>Doğum yılı</div>
<div><input type="text" id="txtDogumYili" runat="server" /></div>



<div>
<p> Telefonu<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</p>
<p> &nbsp;</p>
<p> E-Mail:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
</p>
<p> &nbsp;</p>
<p> Adresi:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
</p> 
<asp:button name="Gonder" ID="Gonder" Text="Üye Ol" runat="server" OnClick="Gonder_Click" /></div>
<div id="txtresult" runat="server"></div>
</form>
</body>
</html>

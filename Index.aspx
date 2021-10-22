<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PruebaTata.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Css/General.css" rel="stylesheet" />

</head>
<body translate="no">
    <div id="Principal">
        <form class="form" id="form1" runat="server">
            <div id="Formulario">
                <div id="titulo">
                    PROCESADOR DE PALABRAS
                </div>
                <div id="text">
                    <asp:TextBox runat="server"  ID="txtConte" placeholder="Ingrese una frase" TextMode="MultiLine" ></asp:TextBox>
                </div>
                <div class="submit">
                    <div id="buttonDiv">
                        <asp:LinkButton runat="server" ID="buttonblue" OnClick="buttonblue_Click">Procesar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>

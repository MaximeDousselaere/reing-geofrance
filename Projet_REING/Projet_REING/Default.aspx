<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- <asp:Button ID="Button3" runat="server" class="buttonToXML" Text="Afficher_Donnees_SQL" OnClick="Afficher_Donnees_SQL"/> -->
    <h1>Régions : </h1>
    Fichier source : App_Data/Database.mdf
    <br /> Type fichier source : <b>Base de données locale</b>
    <br /> <br />
    <div class="info">
        Une région est, en France, une collectivité territoriale issue de la décentralisation, dotée de la personnalité juridique et d'une liberté d'administration, ainsi qu'une division administrative du territoire et des services déconcentrés de l'État.
    </div>
    
        <br />
        <asp:Label ID="labelForRegionsXML" runat="server"/>
        <h3> Liste des régions françaises : </h3>
    <center>
        <asp:Label ID="labelForRegions" runat="server"/>
        <br /> <br />
         <asp:Button ID="Button2" class="buttonToXML" runat="server" Text="Convertir SQL vers XML" OnClick="SQL_to_XML"/>
        <br /> <br />
        <asp:Button ID="Button54" class="buttonToXML" runat="server" Text="Convertir SQL vers JSON" OnClick="SQL_to_JSON"/>
    </center>
        
    <hr />
    <center>
        <img src="/Content/images/img-regions.jpg" style="width:500px"/>
    </center>
    <hr />
    
    
</asp:Content>

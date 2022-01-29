<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <br />
    <h1>Départements : </h1>
    Fichier source : App_Data/departements.csv
    <br /> Type fichier source : <b>fichier CSV</b>
    <br />
    Fichier trouvé sur : <a target="_blank" href="https://www.data.gouv.fr/fr/datasets/liste-des-departements-francais-metropolitains-doutre-mer-et-les-com-ainsi-que-leurs-prefectures/">data.gouv.fr</a>
    <br /> <br />
    <div class="info">
        En France, le département est à la fois : <br />
        &nbsp;&nbsp; - une circonscription administrative, territoire de compétence de services de l'État ; <br />
        &nbsp;&nbsp; - le territoire de compétence d'un département en tant que collectivité territoriale ; <br />
        &nbsp;&nbsp; - une collectivité territoriale proprement dite, à savoir une personne morale de droit public différente de l'État, investie d'une mission d'intérêt général concernant le département, compris en tant que territoire.
    </div>
    
        <br />
        <asp:Label ID="labelForDepartementsXML" runat="server"/>
        <h3> Liste des départements français : </h3>
        <center>
        <asp:Label ID="labelForDepartements" runat="server"/>
        <br /> <br />
        <asp:Button ID="Button1" class="buttonToXML" runat="server" Text="Convertir CSV vers XML" OnClick="CREER_FXML"/>
        <br /> <br />
        <asp:Button ID="Button2" class="buttonToXML" runat="server" Text="Convertir CSV vers JSON" OnClick="CREER_FJSON"/>
        </center>

    <hr />
    <center>
        <img src="/Content/images/image-departements.png" style="width:500px"/>
    </center>
    <hr />
</asp:Content>

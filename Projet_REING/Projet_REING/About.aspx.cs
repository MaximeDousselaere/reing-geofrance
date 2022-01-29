using System;
using System.Web.UI;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

public partial class About : Page
{
    private static JavaScriptSerializer json;
    private static JavaScriptSerializer JSON { get { return json ?? (json = new JavaScriptSerializer()); } }
    string[] string_DEP = new string[109];
    // Modèle de données
    class DEP
    {
        string code;
        string nom;
        string chefLieu;
        string region;
        public DEP(string P1, string P2, string P3, string P4)
        {
            this.code = P1;
            this.nom = P2;
            this.chefLieu = P3;
            this.region = P4;
        }
        public string getCode { get { return code; } }
        public string getNom { get { return nom; } }
        public string getChefLieu { get { return chefLieu; } }
        public string getRegion { get { return region; } }
    };


    protected void Page_Load(object sender, EventArgs e)
    {
        // au chargement de la page, les données sont chargées et affichées 
        Decouper_Text();
    }

    /*
     *  Cette procédure va charger le fichier de données et afficher sur la page un tableau 
     */
    public void Decouper_Text()
    {
        // endroit où ira le résultat d'affichage
        labelForDepartements.Text = "";

        // Le fichier de données est dans le dossier App_Data j'utilise donc Server.MapPath("~App_Data"); 

        if (File.Exists(Server.MapPath("~/App_Data/departements.csv")))
        {
            //Response.Write("The file exists.");
        }

        // Testet si le fichier  existe
        bool exists = File.Exists(Server.MapPath("~/App_Data/departements.csv"));
        string[] lines = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/departements.csv"));
        char[] tc = new char[200];
        int i = 0;

        //Ecriture dynamique du tableau : 
        labelForDepartements.Text += "<table>";
        labelForDepartements.Text += "<tr><th>Code</th><th>Type</th><th>Nom</th><th>Chef lieu</th><th>Région</th><th>Date validité</th></tr>";
        foreach (string line in lines)
        {
            string_DEP[i] = line;
            labelForDepartements.Text += "<tr>";
            string[] words = line.Split(',');
            int j = 1;
            foreach (string mot in words)
            {
                j++;
                labelForDepartements.Text += "<td>" + mot + "</td>";

            }
            labelForDepartements.Text += "</tr>";
            i++;
        }
        labelForDepartements.Text += "</table>";

    }

    protected void CREER_FXML(object sender, EventArgs e)
    {
        DEP[] LIST_DEP = new DEP[109];
        int i = 0;
        foreach (string line in string_DEP)
        {
            string[] mots = line.Split(',');
            LIST_DEP[i] = new DEP(mots[0], mots[2], mots[3], mots[4]);
            i++;
        }

        using (XmlWriter writer = XmlWriter.Create(Server.MapPath("~/Content/DEPARTEMENTS.XML")))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("LISTE_REGION");

            foreach (DEP reg in LIST_DEP)
            {
                writer.WriteStartElement("REGION");

                writer.WriteElementString("CODE", reg.getCode);
                writer.WriteElementString("NOM", reg.getNom);
                writer.WriteElementString("CHEF_LIEU", reg.getChefLieu);
                writer.WriteElementString("REGION", reg.getRegion);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
        labelForDepartementsXML.Text += "<div class=\"success\">INFORMATION : Le fichier 'DEPARTEMENT.XML' a été créé, il se trouve dans le dossier 'Content' du projet. <br /> Accédez-y en <a href=\"Content/DEPARTEMENTS.XML\" target=\"_blank\">cliquant ici</a>.</div><br />";

    }

    protected void CREER_FJSON(object sender, EventArgs e)
    {
        DEP[] LIST_DEP = new DEP[109];
        int i = 0;
        foreach (string line in string_DEP)
        {
            string[] mots = line.Split(',');
            LIST_DEP[i] = new DEP(mots[0], mots[2], mots[3], mots[4]);
            i++;
        }

        using (XmlWriter writer = XmlWriter.Create(Server.MapPath("~/Content/DEPARTEMENTS.XML")))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("LISTE_REGION");

            foreach (DEP reg in LIST_DEP)
            {
                writer.WriteStartElement("REGION");

                writer.WriteElementString("CODE", reg.getCode);
                writer.WriteElementString("NOM", reg.getNom);
                writer.WriteElementString("CHEF_LIEU", reg.getChefLieu);
                writer.WriteElementString("REGION", reg.getRegion);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        //Server.MapPath("~/Content/DEPARTEMENTS.XML");
        XmlDocument doc = new XmlDocument();
        string xml = System.IO.File.ReadAllText(Server.MapPath("~/Content/DEPARTEMENTS.XML"));
        doc.LoadXml(xml);

        string json = JsonConvert.SerializeXmlNode(doc);
        // write string to file
        //File.WriteAllText(@"C:\\Users\\Henri Basson\\Desktop\\Doc_p_XML\\JSON1.txt", json.ToString());
        // Response.Write(json);
        string path = @Server.MapPath("~/Content/DEPARTEMENTS.JSON");
        //exporter les données vers un fichier  json en utilisant TexWriter. 
        using (TextWriter tw = new StreamWriter(path))
        {
            tw.WriteLine(json);
        };

        labelForDepartementsXML.Text += "<div class=\"success\">INFORMATION : Le fichier 'DEPARTEMENTS.JSON' a été créé, il se trouve dans le dossier 'Content' du projet. <br /> Accédez-y en <a href=\"Content/DEPARTEMENTS.JSON\" target=\"_blank\">cliquant ici</a>.</div><br />";
    }
}
using System;
using System.Web.UI;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;


public partial class _Default : Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        Afficher_Donnees_SQL(null, new EventArgs());
    }

  
    protected void Afficher_Donnees_SQL(object sender, EventArgs e)
    {
        string url = Server.MapPath("~/App_Data/");
        string PARAMS_INTEROP =
              "Data Source = (LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename = " + url + "Database.mdf;" +
                 "Integrated Security = True";


        SqlConnection connection = new SqlConnection(PARAMS_INTEROP);


        connection.Open();
        string TABLE_CONCERNEE = "Region";
        string REQ_SQL = "SELECT [id], [nom], [localisation], [ville_principale] FROM[" + TABLE_CONCERNEE + "]";

        using (SqlDataAdapter adaptateur = new SqlDataAdapter(
                REQ_SQL, connection))
        {
            //  adaptateur.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            DataTable dt = new DataTable();
            adaptateur.Fill(dt);
            labelForRegions.Text = "<center><table><tr><td>Code</td><td>Nom</td><td>Localisation</td><td>Ville Principale</td></tr>";
            int i, k = 1;
            foreach (DataRow dr in dt.Rows)
            {
                i = 0;
                // Affichage des valeurs des champs pour s'assurer 
                // de la capture des données via le DataSet 
                labelForRegions.Text += "<tr>";
                labelForRegions.Text +=  "<td>" + dr[i].ToString() + " </td>";
                labelForRegions.Text +=  "<td>" + dr[i + 1].ToString() + "</td>";
                labelForRegions.Text +=  "<td>" + dr[i + 2].ToString() + "</td>";
                labelForRegions.Text +=  "<td>" + dr[i + 3].ToString() + "</td>";
                k++;
            }
            labelForRegions.Text += "<table></center>";
        }

    }

    /*
      Cette fonction va dans un premier temps aller chercher les données de la table puis va écrire les résultats ligne par ligne dans des objets XML      
    */
    protected void SQL_to_XML(object sender, EventArgs e)
    {
        string url = Server.MapPath("~/App_Data/");
        string url2 = Server.MapPath("~/Content/");
        string PARAMS_INTEROP =
              "Data Source = (LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename = " + url + "Database.mdf;" +
                 "Integrated Security = True";


        SqlConnection connection = new SqlConnection(PARAMS_INTEROP);

        connection.Open();
        string TABLE_CONCERNEE = "Region";
        string REQ_SQL = "SELECT [id], [nom], [localisation], [ville_principale] FROM[" + TABLE_CONCERNEE + "]";

        using (SqlDataAdapter adaptateur = new SqlDataAdapter(
                REQ_SQL, connection))
        {
            //  adaptateur.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            DataTable dt = new DataTable();
            adaptateur.Fill(dt);
            // SQL to XML : 
            // Création de fichier XML qui sera initié avec la variable writer de type   XmlWriter
            using (XmlWriter writer = XmlWriter.Create(url2 + "REGIONS.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("REGIONS");

                foreach (DataRow dr in dt.Rows)
                {
                    writer.WriteStartElement("REGION");
                    writer.WriteElementString("CODE", dr[0].ToString());
                    writer.WriteElementString("NOM", dr[1].ToString());
                    writer.WriteElementString("LOCALISATION", dr[2].ToString());
                    writer.WriteElementString("VILLE_PRINCIPALE", dr[3].ToString());
                    writer.WriteEndElement();

                }

                writer.WriteEndDocument();
            }
        }
        labelForRegionsXML.Text += "<div class=\"success\">INFORMATION : Le fichier 'REGION.XML' a été créé, il se trouve dans le dossier 'Content' du projet. <br /> Accédez-y en <a href=\"Content/REGIONS.XML\" target=\"_blank\">cliquant ici</a>.</div><br />";

    }

    protected void SQL_to_JSON(object sender, EventArgs e)
    {

        string url = Server.MapPath("~/App_Data/");
        string url2 = Server.MapPath("~/Content/");

        string PARAMS_INTEROP =
              "Data Source = (LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename = " + url + "Database.mdf;" +
                 "Integrated Security = True";


        SqlConnection connection = new SqlConnection(PARAMS_INTEROP);

        connection.Open();
        string TABLE_CONCERNEE = "Region";
        string REQ_SQL = "SELECT [id], [nom], [localisation], [ville_principale] FROM[" + TABLE_CONCERNEE + "]";

        using (SqlDataAdapter adaptateur = new SqlDataAdapter(
                REQ_SQL, connection))
        {
            //  adaptateur.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            DataTable dt = new DataTable();
            adaptateur.Fill(dt);
            // SQL to XML : 
            // Création de fichier XML qui sera initié avec la variable writer de type   XmlWriter
            using (XmlWriter writer = XmlWriter.Create(url2 + "REGIONS.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("REGIONS");

                foreach (DataRow dr in dt.Rows)
                {
                    writer.WriteStartElement("REGION");
                    writer.WriteElementString("CODE", dr[0].ToString());
                    writer.WriteElementString("NOM", dr[1].ToString());
                    writer.WriteElementString("LOCALISATION", dr[2].ToString());
                    writer.WriteElementString("VILLE_PRINCIPALE", dr[3].ToString());
                    writer.WriteEndElement();

                }

                writer.WriteEndDocument();
            }
        }

        XmlDocument doc = new XmlDocument();
        string xmlString = System.IO.File.ReadAllText(url2 + "REGIONS.xml");
        // charger la chaîne dans un fichier de type XmlDocument
        doc.LoadXml(xmlString);
        // sérialisation du contenu XML de doc en format json
        string json = JsonConvert.SerializeXmlNode(doc);
        // chemin d'accès au  fichier json
        string path = @"" + url2 + "REGIONS.json";
        //exporter les données vers un fichier  json en utilisant TexWriter. 
        using (TextWriter tw = new StreamWriter(path))
        {
            tw.WriteLine(json);
        };
        labelForRegionsXML.Text += "<div class=\"success\">INFORMATION : Le fichier 'REGION.JSON' a été créé, il se trouve dans le dossier 'Content' du projet. <br /> Accédez-y en <a href=\"Content/REGIONS.JSON\" target=\"_blank\">cliquant ici</a>.</div><br />";
    }
}

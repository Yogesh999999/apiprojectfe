using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace practice
{
    public partial class practice : System.Web.UI.Page
    {
        private static string connectionstring = ConfigurationManager.ConnectionStrings["mySql"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]

        public static string Auto(string name, string lastname, string email, int phonenumber, string dob)
        {
            try
            {

                using (MySqlConnection conector = new MySqlConnection(connectionstring))
                {
                    conector.Open();
                    string query = "insert into prac(name,lastname,email,phonenumber,dateofbirth)values(@name,@lastname,@email,@phonenumber,@dateofbirtrh)";
                    MySqlCommand insertquery = new MySqlCommand(query, conector);

                    insertquery.Parameters.AddWithValue("@name", name);
                    insertquery.Parameters.AddWithValue("@lastname", lastname);
                    insertquery.Parameters.AddWithValue("@email", email);
                    insertquery.Parameters.AddWithValue("@phonenumber", phonenumber);
                    insertquery.Parameters.AddWithValue("@dateofbirtrh", dob);
                    insertquery.ExecuteNonQuery();

                }

                return "data inserted successfully";
            }
            catch (Exception ex)
            {
                return "erroe" + ex.Message;
            }

        }


        [WebMethod]

        public static List<object> Country()
        {
            List<object> co = new List<object>();
            try
            {
                using (MySqlConnection connector = new MySqlConnection(connectionstring))
                {
                    connector.Open();
                    string query = "select * from country";

                    MySqlCommand command = new MySqlCommand(query, connector);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        co.Add(new
                        {
                            cid = reader["countryid"],
                            country = reader["country"].ToString()

                        });

                    }



                }


                return co;
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        [WebMethod]
        public  static List<object> Statepop(int country)
        {
            using(MySqlConnection connector = new MySqlConnection(connectionstring))
            {
                List<object> st = new List<object>();
                connector.Open();
                string query = "select id,state from state where cid=@con";
                MySqlCommand changer = new MySqlCommand(query, connector);
                changer.Parameters.AddWithValue("@con", country);
                   
                var reader = changer.ExecuteReader();

                while (reader.Read())
                {
                    st.Add(new
                    {
                        sid = reader["id"],
                        state = reader["state"].ToString()
                    });


                }
                return st;
            }
        }



        [WebMethod]

        public static List<object> Retriving()
        {
            try
            {
                List<object> name = new List<object>();

                using (MySqlConnection connector = new MySqlConnection(connectionstring))
                {
                    connector.Open();
                    string query = "select name,lastname,email,phonenumber,dateofbirth from prac";
                    MySqlCommand command = new MySqlCommand(query, connector);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        name.Add(new
                        {
                            name1 = reader["name"].ToString(),
                            lastname1 = reader["lastname"].ToString(),
                            email1 = reader["email"].ToString(),
                            phone1 = reader["phonenumber"].ToString(),
                            date1 = reader["dateofbirth"].ToString()
                        });

                    }

                    return name;
                }

            }
            catch (Exception )
            {
                return new List<object>();
            }
        }
    }
}

public class whole
{
    public string name1 { get; set; }
    public string lastname1 { get; set; }
    public string email1 { get; set; }
    public string phone1 { get; set; }
    public string date1 { get; set; }

    public string cid { get; set; }
    public string country { get; set; }

    public string sid { get; set; }
    public string state { get; set; }






}

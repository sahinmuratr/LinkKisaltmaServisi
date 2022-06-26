using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Link
    {
        public int Id { get; set; }

        public string UzunLink { get; set; }

        public string KisaLink { get; set; }

        public int Count { get; set; }

        public void Ekle()
        {
            SqlConnection conn = new SqlConnection
                (@"Server=DESKTOP-0JD0258;Database=ShortLink;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand("insert into UserLink (LongLink,Link) values(@longLink,@link)", conn);
            cmd.Parameters.AddWithValue("@longlink", UzunLink);
            cmd.Parameters.AddWithValue("@link", KisaLink);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public Link UzunLinkGetir()
        {
            SqlConnection conn = new SqlConnection
                (@"Server=DESKTOP-0JD0258;Database=ShortLink;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand("Select * from UserLink where Link=@link", conn);
            cmd.Parameters.AddWithValue("@link", KisaLink);
            DataTable dt = new DataTable();
            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            Link link = new Link();


            if (dt.Rows.Count > 0)
            {
                link.UzunLink = dt.Rows[0]["LongLink"].ToString();
                link.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                link.Count = Convert.ToInt32(dt.Rows[0]["ClickCount"]);
                return link;
            }
            else
            {
                return new Link();
            }
        }

        public List<Link> TumLinkleriGetir()
        {
            SqlConnection conn = new SqlConnection
               (@"Server=DESKTOP-0JD0258;Database=ShortLink;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand("Select * from UserLink ", conn);

            DataTable dt = new DataTable();
            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            List<Link> linkler = new List<Link>();
            foreach (DataRow satir in dt.Rows)
            {
                linkler.Add(new Link
                {
                    KisaLink = satir["Link"].ToString(),
                    UzunLink = satir["LongLink"].ToString()
                });

            }
            return linkler;
        }

        public void SayacArttir()
        {
            SqlConnection conn = new SqlConnection
                (@"Server=DESKTOP-0JD0258;Database=ShortLink;Trusted_Connection=True;");

            SqlCommand cmd = new SqlCommand("Update UserLink set ClickCount+=1 where Id=@id", conn);

            cmd.Parameters.AddWithValue("@id", Id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

    }
}

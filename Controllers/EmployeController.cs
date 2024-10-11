using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using Newtonsoft.Json;
using MVC_JQ1_18_12;
using MVC_JQ1_18_12.Models;

namespace MVC_JQ1_18_12.Controllers
{
   

    public class EmployeController : Controller
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-3278F0B\\SQLEXPRESS;initial catalog=mvc1;integrated security=true");

        public ActionResult Index()


        {
            return View();

        }
        public void EmployeInsert(EmployeModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employe_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@city", obj.City);
            cmd.Parameters.AddWithValue("@mobile", obj.Mobile);
            cmd.Parameters.AddWithValue("@age", obj.Age);
            cmd.Parameters.AddWithValue("@country", obj.Country);
            cmd.Parameters.AddWithValue("@state", obj.State);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void EmployeUpdate(EmployeModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employe_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", obj.Id);
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@city", obj.City);
            cmd.Parameters.AddWithValue("@mobile", obj.Mobile);
            cmd.Parameters.AddWithValue("@age", obj.Age);
            cmd.Parameters.AddWithValue("@country", obj.Country);
            cmd.Parameters.AddWithValue("@state", obj.State);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void EmployeDelete(int A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employe_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", A);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public JsonResult EmployeEdit(int A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employe_edit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", A);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }



        public JsonResult EmployeGet()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employe_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CountryGet()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("country_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult StateGet(int A)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("state_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", A);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EmployeSearch(string A, int B)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("employe_search", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@key", A);
            cmd.Parameters.AddWithValue("@column", B);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
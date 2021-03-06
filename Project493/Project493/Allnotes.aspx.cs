﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project493
{
    public partial class Allnotes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //check session
            if (Session["UID"] == null || Session.IsNewSession)
            {
                Response.Redirect("~/Login/Index.aspx", false);
            }
            else
            {
                Note note = new Note();
                note.setUID((int)Session["UID"]);
                DataTable dt = note.getAllNotes();
                if(dt.Rows.Count < 1)
                {
                    noText.Visible = true;
                }
                else
                {
                    noText.Visible = false;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                
            }
          
            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string decodedText1 = HttpUtility.HtmlDecode(e.Row.Cells[0].Text);
                e.Row.Cells[0].Text = decodedText1;
                string decodedText = HttpUtility.HtmlDecode(e.Row.Cells[1].Text);
                e.Row.Cells[1].Text = decodedText;
                
            }
        }
    }
}
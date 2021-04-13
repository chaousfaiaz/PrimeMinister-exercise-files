﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.IO;


namespace PrimeMinisters
{
    public partial class frmPrimeMinisters : Form
    {
        private Dictionary<string, PrimeMinister> primeMinisters;

        public frmPrimeMinisters()
        {
            InitializeComponent();
        }

        private void frmPrimeMinisters_Load(object sender, EventArgs e)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            FileStream fileStream = new FileStream("PrimeMinisters.json", FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);

            primeMinisters = serializer.Deserialize<Dictionary<string, PrimeMinister>>(streamReader.ReadToEnd());

            streamReader.Close();
            fileStream.Close();

            lstPrimeMinisters.DataSource = primeMinisters.Keys.ToList<string>();
        }

        private void lstPrimeMinisters_SelectedValueChanged(object sender, EventArgs e)
        {
            PrimeMinister primeMinister = primeMinisters[lstPrimeMinisters.SelectedValue.ToString()];

            picPhoto.ImageLocation = primeMinister.LastName + ".jpg";

            lblName.Text = primeMinister.FirstName + " " + primeMinister.LastName;
            lblTerm.Text = primeMinister.Term;
            lblParty.Text = primeMinister.Party;
        }
    }
}

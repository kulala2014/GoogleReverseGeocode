using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReverseGeocode_Click(object sender, EventArgs e)
        {
            double lat = 0;
            double lng = 0;
            if (!double.TryParse(txtLat.Text, out lat))
            {
                MessageBox.Show("Latitude is not in the correct format");
                return;
            }
            if (!double.TryParse(txtLong.Text, out lng))
            {
                MessageBox.Show("Longitude is not in the correct format");
                return;
            }
            //GoogleReverseGeocoder.GoogleReverseGeocoder.ClientId = txtGoogleClientId.Text;
            //GoogleReverseGeocoder.GoogleReverseGeocoder.SecretKey = txtGoogleSecretKey.Text;
            bool success = false;
            string result = GoogleReverseGeocoder.GoogleReverseGeocoder.ReverseGeocode(lat, lng, out success);

            if (success)
            {
                lbResult.Items.Clear();
                lbResult.Items.Add(result);
            }
            else
                MessageBox.Show("Call to Google failed");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text.Length > 0)
            {
                //GoogleReverseGeocoder.GoogleReverseGeocoder.ClientId = txtGoogleClientId.Text;
                //GoogleReverseGeocoder.GoogleReverseGeocoder.SecretKey = txtGoogleSecretKey.Text;

                var result = GoogleReverseGeocoder.GoogleReverseGeocoder.GeocodeGetWholeResponse(txtAddress.Text, "US");
                lbResult.Items.Clear();
                //foreach (var r in result.results)
                //{
                //    lbResult.Items.Add(r.formatted_address);
                //}
            }
            else
                MessageBox.Show("No address entered");
        }
    }
}
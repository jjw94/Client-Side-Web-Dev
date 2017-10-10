/**
 * @author Jeremy Wong
 * Course: ISTE 340
 * Project: #3
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication3{
    public partial class Frm1Data: Form{
        /**
         * Default constructor
         * Creates object
         */
        public Frm1Data(){
            InitializeComponent();
        }

        /**
         * Method to load the organization types
         */
        public void getOrgTypes(){
            string uri = @"http://simon.ist.rit.edu:8080/Services/resources/ESD/OrgTypes";

            //Sets up web request from uri
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.Method = "GET";

            try{
                //Receives web response
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream str = res.GetResponseStream();

                XmlReader xr = XmlReader.Create(str);
                cmbType.Items.Clear();

                while(xr.Read()){
                    if(xr.Value != ""){
                        xr.ReadToFollowing("type");
                        cmbType.Items.Add(xr.ReadElementContentAsString());
                    }
                }
                res.Close();
            }
            catch{
                Console.Write("Error");
            }
        }

        /**
         * Method to return the organization names
         */
        public void getOrgNames(){
            String uri = @"http://simon.ist.rit.edu:8080/Services/resources/ESD/Organizations?Name";

            XmlDocument orgXml = new XmlDocument();
            orgXml.Load(uri);

            XmlNodeList orgList = orgXml.GetElementsByTagName("Name");
            for(int i = 0; i < orgList.Count; i++){
                cmbName.Items.Add(orgList[i].InnerXml);
            }
        }

        /**
         * Method to return the cities
         */
        public void getCities(){
            String uri = @"http://simon.ist.rit.edu:8080/Services/resources/ESD/Cities?state=" + cmbState.Text;

            XmlDocument cityXml = new XmlDocument();
            cityXml.Load(uri);

            XmlNodeList cityList = cityXml.GetElementsByTagName("city");
            for(int i = 0; i < cityList.Count; i++){
                cmbCity.Items.Add(cityList[i].InnerXml);
            }
        }

        /**
         * Method to return all the counties
         */
        public void getCounties(){
            String uri = @"http://simon.ist.rit.edu:8080/Services/resources/ESD/Counties?state=" + cmbState.Text;

            XmlDocument countyXml = new XmlDocument();
            countyXml.Load(uri);

            XmlNodeList countyList = countyXml.GetElementsByTagName("CountyName");
            for(int i = 0; i < countyList.Count; i++){
                cmbCounty.Items.Add(countyList[i].InnerXml);
            }
        }
        
        /**
         * Search button functionality
         * When no data is inputted, return all organizations
         */
        private void btnSearch_Click(object sender, EventArgs e){
            string uri = @"http://simon.ist.rit.edu:8080/Services/resources/ESD/Organizations?";
            
            if(cmbType.Text != ""){
                uri = uri + "&type=" + cmbType.Text;
            }
            //Initialize attributes
            string a1 = "";
            string a2 = "";
            string a3 = "";
            string a4 = "";
            string a5 = "";
            string a6 = "";
            string a7 = "";
            string a8 = "";

            XmlDocument orgXml = new XmlDocument();
            orgXml.Load(uri);

            //Identify XML info by tag names
            XmlNodeList orgList1 = orgXml.GetElementsByTagName("OrganizationID");
            XmlNodeList orgList2 = orgXml.GetElementsByTagName("type");
            XmlNodeList orgList3 = orgXml.GetElementsByTagName("Name");
            XmlNodeList orgList4 = orgXml.GetElementsByTagName("Email");
            XmlNodeList orgList5 = orgXml.GetElementsByTagName("city");
            XmlNodeList orgList6 = orgXml.GetElementsByTagName("zip");
            XmlNodeList orgList7 = orgXml.GetElementsByTagName("CountyName");
            XmlNodeList orgList8 = orgXml.GetElementsByTagName("State");

            //Loop through the elements in the XML file
            for(int i = 0; i < orgList1.Count; i++){
                a1 = orgList1[i].InnerXml;
                a2 = orgList2[i].InnerXml;
                a3 = orgList3[i].InnerXml;
                a4 = orgList4[i].InnerXml;
                a5 = orgList5[i].InnerXml;
                a6 = orgList6[i].InnerXml;
                a7 = orgList7[i].InnerXml;
                a8 = orgList8[i].InnerXml;

                //Add it to the data table
                DataTable.Rows.Add(a1, a2, a3, a4, a5, a6, a7, a8);
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e){
            
        }

        /**
         * Calls the getOrgTyoes and getOrgNames methods
         */
        private void Frm1Data_Load(object sender, EventArgs e){
            getOrgTypes();
            getOrgNames();
        }

        /**
         * Calls the getCities and getCounties methods
         */
        private void cmbType2_SelectedIndexChanged(object sender, EventArgs e){
            getCities();
            getCounties();
        }

        /**
         * Creates an instance of frmSearchCriteria
         * Shows the search forms
         */
        private void dataTable_CellContentClick(object sender, DataGridViewCellEventArgs e){
            int col = e.ColumnIndex;
            int row = e.RowIndex;

            int orgID = Convert.ToInt32(DataTable[0, row].Value);
            String criteria = orgID.ToString();
            frmSearchCriteria fsc = new frmSearchCriteria(criteria);
            fsc.Show();
        }
    }
}
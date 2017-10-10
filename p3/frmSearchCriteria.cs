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
    public partial class frmSearchCriteria: Form{
        //Initialize global variables
        XmlNodeList locationList = null;
        string orgID = "";
        Boolean isGeneral = false;

        /**
         * Default constructor
         * Creates the object
         */
        public frmSearchCriteria(string id){
            InitializeComponent();
            orgID = id;

            for(int i = 0; i <= peopleData.TabCount-1; i++){
                TabPage tab = peopleData.TabPages[i];
            }
        }

        /**
         * Method to return the information from the General tab
         */
        public void getGeneralInfo(){
            //Initialize attributes
            string a1 = "";
            string a2 = "";
            string a3 = "";
            string a4 = "";
            string a5 = "";
            string a6 = "";
            string a7 = "";

            string uri = @"http://simon.ist.rit.edu:8080/Services/resources/ESD/" + orgID + "/General";
            XmlDocument generalXml = new XmlDocument();

            //Web request from uri
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.Method = "GET";
            req.Proxy = null;
            
            //Web response from uri
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            generalXml.Load(res.GetResponseStream());
            res.Close();
            
            if(!isGeneral){
                //Identify XML info by tag names
                XmlNodeList generalList1 = generalXml.GetElementsByTagName("name");
                XmlNodeList generalList2 = generalXml.GetElementsByTagName("email");
                XmlNodeList generalList3 = generalXml.GetElementsByTagName("website");
                XmlNodeList generalList4 = generalXml.GetElementsByTagName("nummembers");
                XmlNodeList generalList5 = generalXml.GetElementsByTagName("numcalls");
                XmlNodeList generalList6 = generalXml.GetElementsByTagName("description");
                XmlNodeList generalList7 = generalXml.GetElementsByTagName("serviceArea");
                
                //Loop through the XML file
                for(int i = 0; i < generalList1.Count; i++){
                    if(generalXml.GetElementsByTagName("name")[0].InnerText != null && generalXml.GetElementsByTagName("name")[0].InnerText != ""){
                        a1 = generalList1[i].InnerXml;
                    }
                    
                    if(generalXml.GetElementsByTagName("email")[0].InnerText != null && generalXml.GetElementsByTagName("email")[0].InnerText != ""){
                        a2 = generalList2[i].InnerXml;
                    }
                    
                    if(generalXml.GetElementsByTagName("website")[0].InnerText != null && generalXml.GetElementsByTagName("website")[0].InnerText != ""){
                        a3 = generalList3[i].InnerXml;
                    }
                    
                    if(generalXml.GetElementsByTagName("nummembers")[0].InnerText != null && generalXml.GetElementsByTagName("nummembers")[0].InnerText != ""){
                        a4 = generalList4[i].InnerXml;
                    }
                    
                    if(generalXml.GetElementsByTagName("numcalls")[0].InnerText != null && generalXml.GetElementsByTagName("numcalls")[0].InnerText != ""){
                        a5 = generalList5[i].InnerXml;
                    }

                    if(generalXml.GetElementsByTagName("description")[0].InnerText != null && generalXml.GetElementsByTagName("description")[0].InnerText != ""){
                        a6 = generalList6[i].InnerXml;
                    }
                    
                    if(generalXml.GetElementsByTagName("serviceArea").Count > 0){
                        if(generalXml.GetElementsByTagName("serviceArea")[0].InnerText != null && generalXml.GetElementsByTagName("serviceArea")[0].InnerText != ""){
                            a7 = generalList7[i].InnerXml;
                        }
                    }
                }
                //Add info to the data table
                generalData.Rows.Insert(0, a1, a2, a3, a4, a5, a6, a7);
                isGeneral = true;
            }
        }

        /**
         * Method to return the information from the Locations tab
         */
        public void getLoc(){
            if(locationList == null){
                string uri = @"http://simon.ist.rit.edu:8080/Services/resources/ESD/" + orgID + "/Locations";

                XmlDocument locationXml = new XmlDocument();
                locationXml.Load(uri);

                locationList = locationXml.GetElementsByTagName("location");

                foreach(XmlNode location in locationList){
                    cmbLocation.Items.Add(location["type"].InnerText + ": " + location["address1"].InnerText);
                }
                cmbLocation.SelectedIndex = 0;
            }
        }

        /**
         * Method to change the information in the Locations tab
         */
        public void setLoc(){
            //Initialize attributes
            int index = cmbLocation.SelectedIndex;
            string a1 = "";
            string a2 = "";
            string a3 = "";
            string a4 = "";
            string a5 = "";

            //Load uri
            string uri = @"http://simon.ist.rit.edu:8080/Services/resources/ESD/" + orgID + "/Locations";
            XmlDocument locationXml = new XmlDocument();
            locationXml.Load(uri);
            XmlNode location = locationList[index];

            //Identify XML info by tag names
            XmlNodeList locationList1 = locationXml.GetElementsByTagName("city");
            XmlNodeList locationList2 = locationXml.GetElementsByTagName("state");
            XmlNodeList locationList3 = locationXml.GetElementsByTagName("address1");
            XmlNodeList locationList4 = locationXml.GetElementsByTagName("latitude");
            XmlNodeList locationList5 = locationXml.GetElementsByTagName("longitude");

            //Loop through the XML file
            for(int i = 0; i < locationList1.Count; i++){
                if(location["city"].InnerText != null && location["city"].InnerText != ""){
                    a1 = locationList1[i].InnerXml;
                }
                if(location["state"].InnerText != null && location["state"].InnerText != ""){
                    a2 = locationList2[i].InnerXml;
                }
                if(location["address1"].InnerText != null && location["address1"].InnerText != ""){
                    a3 = locationList3[i].InnerXml;
                }
                if(location["latitude"].InnerText != null && location["latitude"].InnerText != ""){
                    a4 = locationList4[i].InnerXml;
                }
                if(location["longitude"].InnerText != null && location["longitude"].InnerText != ""){
                    a5 = locationList5[i].InnerXml;
                }
            }
            //Add info to the data table
            locationData.Rows.Insert(0, a1, a2, a3, a4, a5);
        }

        /**
         * Method to return the information from the Treatments tab
         */
        public void getTreat(){
            //Initialize attributes
            string a1 = "";
            string a2 = "";
            
            string uri = @"http://simon.ist.rit.edu:8080/Services/resources/ESD/" + orgID + "/Treatments";
            XmlDocument treatmentXml = new XmlDocument();

            //Web request from uri
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = "GET";
            req.Proxy = null;

            //Web response from uri
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            treatmentXml.Load(res.GetResponseStream());
            res.Close();

            //Identify XML info by tag name
            XmlNodeList treatmentList1 = treatmentXml.GetElementsByTagName("treatment");

            //Loop through the XML info
            foreach(XmlNode facilities in treatmentList1){
                if(facilities["type"].InnerText != null && facilities["type"].InnerText != ""){
                    a1 = facilities["type"].InnerXml;
                }

                if(facilities["abbreviation"].InnerText != null && facilities["abbreviation"].InnerText != ""){
                    a2 = facilities["abbreviation"].InnerXml;
                }
                //Add info to the data table
                treatmentData.Rows.Add(a1, a2);
            }
        }

        /**
         * Method to return the information for the Training tab
         */
        public void getTrain(){
            //Initialize attributes
            string a1 = "";
            string a2 = "";

            string uri = @"http://simon.ist.rit.edu:8080/Services/resources/ESD/" + orgID + "/Training";
            XmlDocument trainingXml = new XmlDocument();

            //Web request from uri
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = "GET";
            req.Proxy = null;

            //Web response from uri
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            trainingXml.Load(res.GetResponseStream());
            res.Close();

            //Identify XML info by tag name
            XmlNodeList trainingList1 = trainingXml.GetElementsByTagName("training");

            //Loop through the XML info
            foreach(XmlNode training in trainingList1){
                if(training["type"].InnerText != null && training["type"].InnerText != ""){
                    a1 = training["type"].InnerXml;
                }

                if(training["abbreviation"].InnerText != null && training["abbreviation"].InnerText != ""){
                    a2 = training["abbreviation"].InnerXml;
                }
                //Add info to the data table
                trainingData.Rows.Add(a1, a2);
            }
        }

        /**
         * Method to return the information for the Facilities tab
         */
        public void getFac(){
            //Initialize attributes
            string a1 = "";
            string a2 = "";
            string a3 = "";

            string uri = @"http://simon.ist.rit.edu:8080/Services/resources/ESD/" + orgID + "/Facilities";
            XmlDocument facilitiesXml = new XmlDocument();

            //Web request from uri
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = "GET";
            req.Proxy = null;

            //Web response from uri
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            facilitiesXml.Load(res.GetResponseStream());
            res.Close();

            //Identify XML info by tag name
            XmlNodeList facilitiesList1 = facilitiesXml.GetElementsByTagName("facility");

            //Loop through the XMl info
            foreach(XmlNode facilities in facilitiesList1){
                if(facilities["type"].InnerText != null && facilities["type"].InnerText != ""){
                    a1 = facilities["type"].InnerXml;
                }

                if(facilities["quantity"].InnerText != null && facilities["quantity"].InnerText != ""){
                    a2 = facilities["quantity"].InnerXml;
                }

                if(facilities["description"].InnerText != null && facilities["description"].InnerText != ""){
                    a3 = facilities["description"].InnerXml;
                }
                //Add the info to the data table
                facilitiesData.Rows.Add(a1, a2, a3);
            }
        }

        /**
         * Method to return the information for the Equipment tab
         */
        public void getEquip(){
            //Initialize attributes
            string a1 = "";
            string a2 = "";
            string a3 = "";

            string uri = @"http://simon.ist.rit.edu:8080/Services/resources/ESD/" + orgID + "/Equipment";
            XmlDocument equipmentXml = new XmlDocument();

            //Web request from uri
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = "GET";
            req.Proxy = null;

            //Web response from uri
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            equipmentXml.Load(res.GetResponseStream());
            res.Close();

            //Identify XML info by tag name
            XmlNodeList equipmentList1 = equipmentXml.GetElementsByTagName("equipment");

            //Loop through the XML info
            foreach(XmlNode equipment in equipmentList1){
                if(equipment["type"].InnerText != null && equipment["type"].InnerText != ""){
                    a1 = equipment["type"].InnerXml;
                }

                if(equipment["quantity"].InnerText != null && equipment["quantity"].InnerText != ""){
                    a2 = equipment["quantity"].InnerXml;
                }

                if(equipment["description"].InnerText != null && equipment["description"].InnerText != ""){
                    a3 = equipment["description"].InnerXml;
                }
                //Add info to the data table
                equipmentData.Rows.Add(a1, a2, a3);
            }
        }

        /**
         * Method to return the information for the Physicians tab
         */
        public void getPhys(){
            //Initialize attributes
            string a1 = "";
            string a2 = "";
            string a3 = "";
            string a4 = "";
            string a5 = "";
            string a6 = "";

            string uri = @"http://simon.ist.rit.edu:8080/Services/resources/ESD/" + orgID + "/Physicians";
            XmlDocument physiciansXml = new XmlDocument();

            //Web request from uri
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = "GET";
            req.Proxy = null;

            //Web response from uri
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            physiciansXml.Load(res.GetResponseStream());
            res.Close();

            //Identify XML inf by tag name
            XmlNodeList physiciansList1 = physiciansXml.GetElementsByTagName("physician");

            //Loop through the XML info
            foreach(XmlNode physicians in physiciansList1){
                if(physicians["fName"].InnerText != null && physicians["fName"].InnerText != ""){
                    a1 = physicians["fName"].InnerXml;
                }

                if(physicians["mName"].InnerText != null && physicians["mName"].InnerText != ""){
                    a2 = physicians["mName"].InnerXml;
                }

                if(physicians["lName"].InnerText != null && physicians["lName"].InnerText != ""){
                    a3 = physicians["lName"].InnerXml;
                }
                if(physicians["suffix"].InnerText != null && physicians["suffix"].InnerText != ""){
                    a4 = physicians["suffix"].InnerXml;
                }

                if(physicians["phone"].InnerText != null && physicians["phone"].InnerText != ""){
                    a5 = physicians["phone"].InnerXml;
                }

                if(physicians["license"].InnerText != null && physicians["license"].InnerText != ""){
                    a6 = physicians["license"].InnerXml;
                }
                //Add the info to the data table
                physiciansData.Rows.Add(a1, a2, a3, a4, a5, a6);
            }
        }

        /**
         * Method to return the information in the People tab
         */
        public void getPerson(){
            //Initialize attributes
            string a1 = "";
            string a2 = "";
            string a3 = "";
            string a4 = "";
            string a5 = "";
            string a6 = "";

            string uri = @"http://simon.ist.rit.edu:8080/Services/resources/ESD/" + orgID + "/People";
            XmlDocument peopleXml = new XmlDocument();

            //Web request from uri
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = "GET";
            req.Proxy = null;

            //Web response from uri
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            peopleXml.Load(res.GetResponseStream());
            res.Close();

            //Identify XML info by tag name
            XmlNodeList peopleList1 = peopleXml.GetElementsByTagName("person");

            //Loop through the XML info
            foreach(XmlNode people in peopleList1){
                if(people["honorific"].InnerText != null && people["honorific"].InnerText != ""){
                    a1 = people["honorific"].InnerXml;
                }

                if(people["fName"].InnerText != null && people["fName"].InnerText != ""){
                    a2 = people["fName"].InnerXml;
                }

                if(people["mName"].InnerText != null && people["mName"].InnerText != ""){
                    a3 = people["mName"].InnerXml;
                }

                if(people["lName"].InnerText != null && people["lName"].InnerText != ""){
                    a4 = people["lName"].InnerXml;
                }

                if(people["suffix"].InnerText != null && people["suffix"].InnerText != ""){
                    a5 = people["suffix"].InnerXml;
                }

                if(people["role"].InnerText != null && people["role"].InnerText != ""){
                    a6 = people["role"].InnerXml;
                }
                //Add info to the data table
                peopleD.Rows.Add(a1, a2, a3, a4, a5, a6);
            }
        }

        private void generalForm_Click(object sender, EventArgs e){

        }

        private void tabForm_Click(object sender, EventArgs e){

        }

        /**
         * Calls all methods in this class
         */
        private void frmSearchCriteria_Load(object sender, EventArgs e){
            getGeneralInfo();
            getLoc();
            setLoc();
            getTreat();
            getTrain();
            getFac();
            getEquip();
            getPhys();
            getPerson();
        }
    }
}
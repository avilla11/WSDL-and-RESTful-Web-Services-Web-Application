using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryItPage
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //button click will call the nearest store method
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TextBox1.Text) && !String.IsNullOrWhiteSpace(TextBox2.Text)) //if the boxes are not empty
            {
                //WebService.Service1Client web = new WebService.Service1Client();
                //Test.Service1Client test = new Test.Service1Client();
                //web2.Service1Client web2 = new web2.Service1Client();
                //Webs.Service1Client web3 = new Webs.Service1Client();
                Update.Service1Client up = new Update.Service1Client();

                string s = up.findNearestStore(TextBox1.Text, TextBox2.Text);
                Label1.Text = s.ToString(); //print output
            }
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //call the show all states procedure
        protected void Button2_Click(object sender, EventArgs e)
        {
            //WebService.Service1Client web = new WebService.Service1Client();
            //Test.Service1Client test = new Test.Service1Client();
            // web2.Service1Client web2 = new web2.Service1Client();
            //Webs.Service1Client web3 = new Webs.Service1Client();
            Update.Service1Client up = new Update.Service1Client();
            string s = up.showAllStates();
            Label2.Text = s.ToString(); //print output
        }

        //call the get tax function
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TextBox3.Text)) //if the box is not empty
            {
                //NoRestful.Service1Client test = new NoRestful.Service1Client();
                //test3.Service1Client test = new test3.Service1Client();
                //web2.Service1Client web = new web2.Service1Client();
                //Webs.Service1Client web3 = new Webs.Service1Client();
                Update.Service1Client up = new Update.Service1Client();
                string s = up.getTax(TextBox3.Text);
                Label3.Text = s.ToString(); //print output
            }

        }

        //call the restful service for directions
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TextBox4.Text) && (!String.IsNullOrWhiteSpace(TextBox5.Text) && (!String.IsNullOrWhiteSpace(TextBox6.Text)))) //if the box is not empty
            {
                string origin = TextBox4.Text;
                string destination = TextBox5.Text;
                string mode = TextBox6.Text;
                string url = "http://webstrar59.fulton.asu.edu/page4/Service1.svc/giveDirections?origin=" + origin + "&destination=" + destination + "&mode=" + mode + "&key=AIzaSyCu7SZ-mwmbBOTB_d07sfg3Ub_IGxsZvJE";
                var json = "";
                //Direc.Service1Client direct = new Direc.Service1Client();
                using (var webClient = new System.Net.WebClient())
                {
                    json = webClient.DownloadString(url);
                }
                Label4.Text = json; //print output
            }

        }
        //button to call the aur qyality functon
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TextBox7.Text)) //if the textbos is not empty
            {
                //air.Service1Client airq = new air.Service1Client();
                Update.Service1Client up = new Update.Service1Client();
                string s = up.getAirQuality(TextBox7.Text);
                Label5.Text = s.ToString(); //print output
            }

        }

        protected void Button6_Click(object sender, EventArgs e) //all buttons below are to call the try it functions implemented as part of what I did for this project under number 2
        {
            if (!String.IsNullOrWhiteSpace(TextBox8.Text))
            {
                //localTest.Service1Client xml = new localTest.Service1Client();
                //refForXML.Service1Client newxml = new refForXML.Service1Client();
                //ServiceReference12.Service1Client xmlWeb = new ServiceReference12.Service1Client();
                FinalRef.Service1Client finalXML = new FinalRef.Service1Client();
                string s = finalXML.removeFromMemberXML(TextBox8.Text); //calls remove for member from member xml
                Label6.Text = s.ToString();
            }
        }

        /*protected void Button7_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TextBox9.Text))
            {
                //localTest.Service1Client xml = new localTest.Service1Client();
                //refForXML.Service1Client newxml = new refForXML.Service1Client();
                //FinalRef.Service1Client finalXML = new FinalRef.Service1Client();
                // ServiceReference15.Service1Client webml = new ServiceReference15.Service1Client();
                //localRefXML.Service1Client webxml = new localRefXML.Service1Client();
                webpl.Service1Client wbpl = new webpl.Service1Client();
                string s = wbpl.removeFromStaffXML(TextBox9.Text); //remove a staff from the xml by username
                Label7.Text = s.ToString();
            }
        } */

        protected void Button8_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TextBox10.Text))
            {
                //localTest.Service1Client xml = new localTest.Service1Client();
                //refForXML.Service1Client newxml = new refForXML.Service1Client();
                FinalRef.Service1Client finalXML = new FinalRef.Service1Client();
                string s = finalXML.searchMemberUsernameXML(TextBox10.Text); //search for a member's username
                Label8.Text = s.ToString();
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TextBox11.Text))
            {
                //localTest.Service1Client xml = new localTest.Service1Client();
                //refForXML.Service1Client newxml = new refForXML.Service1Client();
                FinalRef.Service1Client finalXML = new FinalRef.Service1Client();
                string s = finalXML.searchMemberPasswordXML(TextBox11.Text); //search for a password in the xml
                Label9.Text = s.ToString();
            }
        }

        /*protected void Button10_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TextBox12.Text))
            {
                localTest.Service1Client xml = new localTest.Service1Client();
                //refForXML.Service1Client newxml = new refForXML.Service1Client();
                //FinalRef.Service1Client finalXML = new FinalRef.Service1Client();
                string s = xml.searchStaffUsernameXML(TextBox12.Text); //search for staff username in staff xml
                Label10.Text = s.ToString();
            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TextBox13.Text))
            {
                //localTest.Service1Client xml = new localTest.Service1Client();
                //refForXML.Service1Client newxml = new refForXML.Service1Client();
                //string s = newxml.searchStaffPasswordXML(TextBox13.Text);
                FinalRef.Service1Client finalXML = new FinalRef.Service1Client();
                string s = finalXML.searchStaffPasswordXML(TextBox13.Text); //search for staff password in staff xml
                Label11.Text = s.ToString();
            }
        }  */
    }
}
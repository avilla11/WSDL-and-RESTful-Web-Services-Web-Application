using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Xml;
using System.Xml.Linq;
using System.Web;

namespace CSE445Project3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string findNearestStore(string zipCode, string storeName)
        {

            List<string> information = new List<string>(); //create a list to store the nearest store based on zipcode
            string url = "https://maps.googleapis.com/maps/api/geocode/json?components=postal_code:" + zipCode + "&sensor=false" + "&key=AIzaSyCu7SZ-mwmbBOTB_d07sfg3Ub_IGxsZvJE"; //call the google geocode api with zip and my api key
            ParseLatAndLon latLonParse = new ParseLatAndLon(); //creating a longitude and latitude parsing object from the parse latitude and logitude class
            ParseStore storeJson = new ParseStore(); //creating a storejson object from the Parse store class
            string coordinates; //string to store the latitude and longitude
            string result = ""; //string to store the final informaiton that has to be displayed

            using (var webClient = new System.Net.WebClient()) //creating a new webclient for json
            {
                var json = webClient.DownloadString(url); //extracting the json from the google api with zipcode and key 
                //Console.WriteLine(json); 

                latLonParse = JsonConvert.DeserializeObject<ParseLatAndLon>(json); //deserializing the json 
                Console.WriteLine(latLonParse.status + "Status check");

                if (latLonParse.status == "OK") //if the status is OK then that means no errors in the json 
                {
                    coordinates = latLonParse.results[0].geometry.bounds.southwest.lat.ToString() + "," //append the coordinates of the json to the string
                                + latLonParse.results[0].geometry.bounds.southwest.lng.ToString();


                    url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location="
                        + coordinates + "&radius=30000&keyword=" + storeName + "&key=AIzaSyCu7SZ-mwmbBOTB_d07sfg3Ub_IGxsZvJE"; //using the places google api with the store name and my api key same as the one for zip code

                    json = webClient.DownloadString(url); //extracting json again like before
                    Console.WriteLine(json);

                    storeJson = JsonConvert.DeserializeObject<ParseStore>(json); // Deserializes the json like before

                    if (storeJson.status == "OK") // if the status is okay there are no errors in the json 
                    {
                        //list.Add(storeobj.results[0].icon); // URL for the icon 
                        information.Add(storeJson.results[0].name); // add to the information list the name of the store
                        //list.Add(storeobj.results[0].rating.ToString()); // Adds the store rating
                        information.Add(storeJson.results[0].vicinity); // add to the information list the vicinity of the store
                    }
                    else
                    {
                        information.Add(storeName + " Error: No such store."); // if execution reaches here then the store does not exist
                    }
                }
                else
                    //Console.WriteLine(latLonParse.status); testing status
                    //Console.WriteLine(storeJson.status); testing status delete later
                    information.Add(""); // zip code was not valid
            }

            for (int i = 0; i < information.Count; i++)
            {
                result += information[i] + ",";

            }
            result = result.TrimEnd(','); //needed to remove the comma added when separating
            return result;
        }

        public class ParseLatAndLon //class for parsing the latitude and longitude from json
        {
            public Result[] results { get; set; } //get and set for parsing results
            public string status { get; set; } //parsing status

            public class Result
            {
                public Geometry geometry { get; set; } //parsing geometry from the json
                public class Geometry
                {
                    public Bounds bounds { get; set; } //parsing bounds 
                    public class Bounds
                    {
                        public Southwest southwest { get; set; } //getting the southwest coordinates
                        public class Southwest
                        {
                            public float lat { get; set; } //parsing the lat
                            public float lng { get; set; } //parsing the long
                        }
                    }
                }
            }
        }

        public class ParseStore //same logic as above class but for parsing the store information
        {
            public Result[] results { get; set; } //parsing results
            public string status { get; set; } //parsing status

            public class Result
            {
                //public string icon { get; set; }
                public string name { get; set; } //getting name
                                                 //public float rating { get; set; }
                public string vicinity { get; set; } //getting the vicinity
            }
        }

        public string showAllStates() //Economic Research Service has list of all states they have data on. This function returns the name of all the states it has data on
        {


            string result = ""; //empty string for the result
            List<string> information = new List<string>(); //creating a list to hold the information
            ParseStates parser = new ParseStates(); //creating an instance of the parse states class

            string url = "https://api.ers.usda.gov/data/arms/state?api_key=lwhiC0mGA1xsVRUjdIbjgsEJarBmZ1udfdd2tTDe"; //the url to the api call

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(url); //creating a json variable to download the information
                // Console.WriteLine(json);

                parser = JsonConvert.DeserializeObject<ParseStates>(json); //deserializing the json
                // Console.WriteLine(parser.status); //testing status

                if (parser.status == "ok") //if the status is ok then enter
                {
                    for (int i = 1; i <= 15; i++) //loop to add the states to the list
                    {
                        information.Add(parser.data[i].name); //adding to the list
                        //Console.WriteLine(parser.data[i].name);
                    }
                }
                else
                {
                    information.Add("Unexptect error"); //else there is an error so add to list
                }
                for (int i = 0; i < information.Count; i++) //loop to add the list contents to the empty string
                {
                    result += information[i] + ",";
                }
            }
            result = result.TrimEnd(','); //needed to remove the comma added when separating
            return result; //returning result
        }

        public class ParseStates //class for parsing the latitude and longitude from json
        {
            public Data[] data { get; set; } //get and set for parsing results and data array
            public string status { get; set; } //parsing status

            public class Data //data class
            {
                public int id { get; set; } //gettin id code and name from the json
                public string code { get; set; }
                public string name { get; set; }

            }

        }

        public string getTax(string zipcode) //method to get tax information based on zip code
        {
            string result = ""; //empty string 
            List<string> information = new List<string>(); //a list to hold the information for display
            //GeoInfo parser = new GeoInfo();

            string url = "https://api.zip-tax.com/request/v40?key=968peOQc12igWqKZ&postalcode=" + zipcode; //the url to make the api request
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(url); //downloading the url contents for json
                //Console.WriteLine(json);
                try //try catch in case some zipcodes break 
                {
                    Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json); //desearializing the json


                    if (myDeserializedClass.rCode == 100) //if the code is 100 then there are no errors 
                    {
                        //add to the list the necessary info to display
                        information.Add("For the zipcode " + zipcode + " belonging to the state of " + myDeserializedClass.results[0].geoState + " And county of " + myDeserializedClass.results[0].geoCounty + ", the total sales" +
                            " tax is " + myDeserializedClass.results[0].taxSales + ", the total use tax is " + myDeserializedClass.results[0].taxUse + ", the portion of total sales tax from the" +
                            " state level is " + myDeserializedClass.results[0].stateSalesTax + ", the portion of total sales tax from the city level is " + myDeserializedClass.results[0].citySalesTax + " and the portion" +
                            " of total use tax from the city level is " + myDeserializedClass.results[0].cityUseTax);
                    }
                }
                catch //catch exceptions
                {
                    return "Cannot properly assess based on this zip code. Please enter another";
                }
                //Console.WriteLine(myDeserializedClass.results[0].citySalesTax);
            }
            for (int i = 0; i < information.Count; i++) //for loop to add the list to the empty string
            {
                result += information[i];
            }
            return result; //display the results
        }

        //classes for parsing the json
        public class Result
        {
            public string geoPostalCode { get; set; } //all fields from json
            public string geoCity { get; set; }
            public string geoCounty { get; set; }
            public string geoState { get; set; }
            public double taxSales { get; set; }
            public double taxUse { get; set; }
            public string txbService { get; set; }
            public string txbFreight { get; set; }
            public double stateSalesTax { get; set; }
            public double stateUseTax { get; set; }
            public double citySalesTax { get; set; }
            public double cityUseTax { get; set; }
            public string cityTaxCode { get; set; }
            public double countySalesTax { get; set; }
            public decimal countyUseTax { get; set; }
            public string countyTaxCode { get; set; }
            public decimal districtSalesTax { get; set; }
            public decimal districtUseTax { get; set; }
            public string district1Code { get; set; }
            public decimal district1SalesTax { get; set; }
            public decimal district1UseTax { get; set; }
            public string district2Code { get; set; }
            public decimal district2SalesTax { get; set; }
            public decimal district2UseTax { get; set; }
            public string district3Code { get; set; }
            public decimal district3SalesTax { get; set; }
            public decimal district3UseTax { get; set; }
            public string district4Code { get; set; }
            public decimal district4SalesTax { get; set; }
            public decimal district4UseTax { get; set; }
            public string district5Code { get; set; }
            public decimal district5SalesTax { get; set; }
            public decimal district5UseTax { get; set; }
            public string originDestination { get; set; }
        }
        public class Root //root class to use the json
        {
            public string version { get; set; }
            public int rCode { get; set; }
            public List<Result> results { get; set; }
        }
        public string getAirQuality(string city) //function to get the air quality based on city
        {
            string result = ""; //string to display results
            List<string> list = new List<string>(); //list to add info to
            //GeoInfo parser = new GeoInfo();

            string url = "https://api.waqi.info/feed/" + city + "/?token=392e0da0a4b07ae7cd44f8e372203d50b70d71e0"; //the api call url
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(url); //getting json
                //Console.WriteLine(json);
                Root1 parser = JsonConvert.DeserializeObject<Root1>(json); //deserialzing the json
                //Console.WriteLine(myDeserializedClass.results[0].citySalesTax);
                //Console.WriteLine(parser.status);
                if (parser.status == "ok") //if the status is okay then there are no errors
                {
                    //add the information to the list
                    list.Add("The average air quality index (AQI), which ranges from a scale of 0-500 where the higher the number, the greater the level of air pollution and " +
                        "the greater the health concern, of " + parser.data.city.name + " is " + parser.data.aqi + ".");
                }
            }
            for (int i = 0; i < list.Count; i++) //for loop to add list to empty strng
            {
                result += list[i];
            }
            return result; //print the results
        }

        // classes to parse the json as before
        public class Attribution
        {
            public string url { get; set; }
            public string name { get; set; }
        }

        public class City
        {
            public List<double> geo { get; set; }
            public string name { get; set; } //name field used in print
            public string url { get; set; }
        }

        public class Co
        {
            public double v { get; set; }
        }

        public class H
        {
            public decimal v { get; set; }
        }

        public class No2
        {
            public double v { get; set; }
        }

        public class O3
        {
            public double v { get; set; }
        }

        public class P
        {
            public decimal v { get; set; }
        }

        public class Pm10
        {
            public decimal v { get; set; }
        }

        public class Pm25
        {
            public decimal v { get; set; }
        }

        public class So2
        {
            public double v { get; set; }
        }

        public class T
        {
            public decimal v { get; set; }
        }

        public class W
        {
            public double v { get; set; }
        }

        public class Iaqi
        {
            public Co co { get; set; }
            public H h { get; set; }
            public No2 no2 { get; set; }
            public O3 o3 { get; set; }
            public P p { get; set; }
            public Pm10 pm10 { get; set; }
            public Pm25 pm25 { get; set; }
            public So2 so2 { get; set; }
            public T t { get; set; }
            public W w { get; set; }
        }

        public class Time
        {
            public string s { get; set; }
            public string tz { get; set; }
            public decimal v { get; set; }
            public DateTime iso { get; set; }
        }

        public class O32
        {
            public decimal avg { get; set; }
            public string day { get; set; }
            public decimal max { get; set; }
            public decimal min { get; set; }
        }

        public class Pm102
        {
            public decimal avg { get; set; }
            public string day { get; set; }
            public decimal max { get; set; }
            public decimal min { get; set; }
        }

        public class Pm252
        {
            public decimal avg { get; set; }
            public string day { get; set; }
            public decimal max { get; set; }
            public decimal min { get; set; }
        }

        public class Uvi
        {
            public decimal avg { get; set; }
            public string day { get; set; }
            public decimal max { get; set; }
            public decimal min { get; set; }
        }

        public class Daily
        {
            public List<O32> o3 { get; set; }
            public List<Pm102> pm10 { get; set; }
            public List<Pm252> pm25 { get; set; }
            public List<Uvi> uvi { get; set; }
        }

        public class Forecast
        {
            public Daily daily { get; set; }
        }

        public class Debug
        {
            public DateTime sync { get; set; }
        }

        public class Data
        {
            public decimal aqi { get; set; } //aqi used in printing
            public decimal idx { get; set; }
            public List<Attribution> attributions { get; set; }
            public City city { get; set; }
            public string dominentpol { get; set; }
            public Iaqi iaqi { get; set; }
            public Time time { get; set; }
            public Forecast forecast { get; set; }
            public Debug debug { get; set; }
        }
        //end of necessary classes for json

        public class Root1 //root1 class to use the parsed json
        {
            public string status { get; set; }
            public Data data { get; set; }
        }

        public string removeFromMemberXML(string username)
        {
            XmlDocument doc = new XmlDocument();
            //doc.Load(@"Z:\Member.xml");
            string location = HttpRuntime.AppDomainAppPath + "Member.xml";
            doc.Load(location);
            //XElement xelement = XElement.Load(@"C:\Users\Aurelio\Desktop\TestAPI\ConsoleApp1\XMLFile1.xml");

            //XmlNode node = doc.SelectSingleNode("/Members/Member[@user_name= " + "'" + username + "']");
            XmlNode node = doc.SelectSingleNode("/Members/Member[user_name='" + username + "'" + "]");

            // if found....
            if (node != null)
            {
                // get its parent node
                XmlNode parent = node.ParentNode;

                // remove the child node
                parent.RemoveChild(node);

                // verify the new XML structure
                string newXML = doc.OuterXml;

                // save to file or whatever....
                string saveLocation = HttpRuntime.AppDomainAppPath + "newMember.xml";
                doc.Save(saveLocation);
                return "Successfully deleted the username and its password. A new xml file named newMember.xml with the updated contents has been created.";
            }
            else
            {
                return "Error: the username entered does not exist and has not been deleted";

            }
        }


        public string removeFromStaffXML(string username)
        {
            XmlDocument doc = new XmlDocument();
            //doc.Load(@"Z:\staff.xml");
            string location = HttpRuntime.AppDomainAppPath + @"\Staff.xml";
            doc.Load(location);

            //XmlNode node = doc.SelectSingleNode("/Members/Member[@user_name= " + "'" + username + "']");
            XmlNode node = doc.SelectSingleNode("/Members/Member[user_name='" + username + "'" + "]");

            // if found....
            if (node != null)
            {
                // get its parent node
                XmlNode parent = node.ParentNode;

                // remove the child node
                parent.RemoveChild(node);

                // verify the new XML structure
                string newXML = doc.OuterXml;

                // save to file or whatever....
                //doc.Save(@"Z:\newStaff.xml");
                string saveLocation = HttpRuntime.AppDomainAppPath + "newStaff.xml";
                doc.Save(saveLocation);
                return "Successfully deleted the username and its password. A new xml file named newStaff.xml with the updated contents has been created.";
            }
            else
            {
                return "Error: the username entered does not exist and has not been deleted";

            }
        }

        public string searchMemberUsernameXML(string username)
        {
            XElement xelement = XElement.Load(HttpRuntime.AppDomainAppPath + "Member.xml");
            List<string> usernameList = new List<string>();

            bool usernameCheck = false;

            foreach (XElement ele in xelement.Descendants("user_name"))
            {
                //Console.WriteLine(ele);
                usernameList.Add((string)ele);
            }

            for (int i = 0; i < usernameList.Count; i++)
            {
                if (username == usernameList[i])
                {
                    usernameCheck = true;
                }

            }

            if (usernameCheck)
                return "Username " + username + " exists";
            else
                return "Username " + username + " does not exist";
        }

        public string searchMemberPasswordXML(string password)
        {
            XElement xelement = XElement.Load(HttpRuntime.AppDomainAppPath + "Member.xml");
            //Console.WriteLine("Test all usernames");
            //List<string> usernameList = new List<string>();
            List<string> passwordList = new List<string>();
            //Boolean usernameCheck = false;
            //Boolean passwordCheck = false;
            bool passwordCheck = false;

            foreach (XElement ele in xelement.Descendants("password"))
            {
                //Console.WriteLine(ele);
                passwordList.Add((string)ele);
            }

            for (int i = 0; i < passwordList.Count; i++)
                if (password == passwordList[i])
                    passwordCheck = true;

            if (passwordCheck)
                return "Password " + password + " exists";
            else
                return "Password " + password + " does not exist";
        }

        public string searchStaffUsernameXML(string username)
        {
            XElement xelement = XElement.Load(HttpRuntime.AppDomainAppPath + "Staff.xml");
            //Console.WriteLine("Test all usernames");
            List<string> usernameList = new List<string>();
            //List<string> passwordList = new List<string>();
            //Boolean usernameCheck = false;
            //Boolean passwordCheck = false;
            bool usernameCheck = false;

            foreach (XElement ele in xelement.Descendants("user_name"))
            {
                //Console.WriteLine(ele);
                usernameList.Add((string)ele);
            }

            for (int i = 0; i < usernameList.Count; i++)
            {
                if (username == usernameList[i])
                {
                    usernameCheck = true;
                }

            }

            if (usernameCheck)
                return "Username " + username + " exists";
            else
                return "Username " + username + " does not exist";
        }

        public string searchStaffPasswordXML(string password)
        {
            XElement xelement = XElement.Load(HttpRuntime.AppDomainAppPath + "Staff.xml");
            //Console.WriteLine("Test all usernames");
            //List<string> usernameList = new List<string>();
            List<string> passwordList = new List<string>();
            //Boolean usernameCheck = false;
            //Boolean passwordCheck = false;
            bool passwordCheck = false;
            string result = "";
            List<string> result1 = new List<string>();

            foreach (XElement ele in xelement.Descendants("password"))
            {
                //Console.WriteLine(ele);
                passwordList.Add((string)ele);
            }

            for (int i = 0; i < passwordList.Count; i++)
                if (password == passwordList[i])
                    passwordCheck = true;

            if (passwordCheck)
                result1.Add("Password " + password + " exists");
                
            else
                result1.Add("Password " + password + " does not exist");
            for (int i = 0; i < result1.Count; i++) //for loop to add list to empty strng
            {
                result += result1[i];
            }
            return result; //print the results
        }
    }
}

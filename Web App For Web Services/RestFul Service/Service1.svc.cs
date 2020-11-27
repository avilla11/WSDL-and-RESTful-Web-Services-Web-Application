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

namespace RestFul_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string giveDirections(string origin, string destination, string mode) //modes can be driving, walking, transit or bicycling
        {
            string result = ""; //empty string for result
            List<string> list = new List<string>(); //list to add to
            //GeoInfo parser = new GeoInfo();

            string url = "https://maps.googleapis.com/maps/api/directions/json?origin=" + origin + "&destination=" + destination + "&mode=" + mode + "&key="; //url with api call enter your own key to test
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(url); //downloading the url
                //Console.WriteLine(json);
                Root parser = JsonConvert.DeserializeObject<Root>(json); //using root to deseriazlize 
                //Console.WriteLine(myDeserializedClass.results[0].citySalesTax);
                //Console.WriteLine(parser.status);

                if (parser.status == "OK") //if the status is okay there are no errors so add the necessary information
                {
                    list.Add("The distance between " + origin + " and " + destination + " is " + parser.routes[0].legs[0].distance.text + ". ");
                    list.Add("You have chosen directions for " + mode + " mode. ");
                    list.Add("It will take a total of " + parser.routes[0].legs[0].duration.text + " with the current mode you have chosen. ");
                    //list.Add("Follow these steps to get from " + origin + " to " + destination + ". ");
                    list.Add("The following steps will be given with respect to " + mode + " mode you have chosen. Follow these steps to get from " + parser.routes[0].legs[0].start_address + " to " + parser.routes[0].legs[0].end_address + ". ");
                    for (int i = 0; i < parser.routes[0].legs[0].steps.Count; i++) //loop through all the steps and add the steps distances and time
                    {
                        list.Add("\n");
                        list.Add(parser.routes[0].legs[0].steps[i].html_instructions);
                        //list.Add(" ");
                        list.Add(".The next direction is in " + parser.routes[0].legs[0].steps[i].distance.text + " and will come in " + parser.routes[0].legs[0].steps[i].duration.text + ".");
                    }
                    //after steps have been listed add you have arrived
                    list.Add("\nYou have arrived");

                    //for loops to remove uncessary characters
                    //<b>
                    for (int i = 0; i < list.Count; i++)
                        list[i] = list[i].Replace("</b>", "");

                    for (int i = 0; i < list.Count; i++)
                        list[i] = list[i].Replace("<b>", "");

                    //<div style="font-size:0.9em">
                    for (int i = 0; i < list.Count; i++)
                        list[i] = list[i].Replace("<div style=", "");

                    //font - size:0.9em">"

                    for (int i = 0; i < list.Count; i++)
                        list[i] = list[i].Replace("font-size:0.9em", "");

                    for (int i = 0; i < list.Count; i++)
                        list[i] = list[i].Replace(">", "");

                    for (int i = 0; i < list.Count; i++)
                        list[i] = list[i].Replace("/<wbr/", "");

                    for (int i = 0; i < list.Count; i++)
                        list[i] = list[i].Replace("\"", "");

                    //</div
                    for (int i = 0; i < list.Count; i++)
                        list[i] = list[i].Replace("</div", "");
                    //end of for loops for cleaning


                    // Console.WriteLine("The distance between " + origin + " and " + destination + " is " + parser.routes[0].legs[0].distance.text);
                    //Console.WriteLine("it will take a total of " + parser.routes[0].legs[0].duration.text);
                    //Console.WriteLine("Follow these steps to get from " + parser.routes[0].legs[0].start_address + " to " + parser.routes[0].legs[0].end_address);
                }
            }

            //for loop to add the list to the empty string
            for (int i = 0; i < list.Count; i++)
            {
                result += list[i];
            }

            return result;
        }

        //classes needed to parse the json
        public class GeocodedWaypoint
        {
            public string geocoder_status { get; set; }
            public string place_id { get; set; }
            public List<string> types { get; set; }
        }

        public class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Bounds
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Distance
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class Duration
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class EndLocation
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class StartLocation
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Distance2
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class Duration2
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class EndLocation2
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Polyline
        {
            public string points { get; set; }
        }

        public class StartLocation2
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Step
        {
            public Distance2 distance { get; set; }
            public Duration2 duration { get; set; }
            public EndLocation2 end_location { get; set; }
            public string html_instructions { get; set; }
            public Polyline polyline { get; set; }
            public StartLocation2 start_location { get; set; }
            public string travel_mode { get; set; }
            public string maneuver { get; set; }
        }

        public class Leg
        {
            public Distance distance { get; set; }
            public Duration duration { get; set; }
            public string end_address { get; set; }
            public EndLocation end_location { get; set; }
            public string start_address { get; set; }
            public StartLocation start_location { get; set; }
            public List<Step> steps { get; set; }
            public List<object> traffic_speed_entry { get; set; }
            public List<object> via_waypoint { get; set; }
        }

        public class OverviewPolyline
        {
            public string points { get; set; }
        }

        public class Route
        {
            public Bounds bounds { get; set; }
            public string copyrights { get; set; }
            public List<Leg> legs { get; set; }
            public OverviewPolyline overview_polyline { get; set; }
            public string summary { get; set; }
            public List<object> warnings { get; set; }
            public List<object> waypoint_order { get; set; }
        }
        //end of classes needed to parse the json
        public class Root //creating a root class to access parsed json
        {
            public List<GeocodedWaypoint> geocoded_waypoints { get; set; }
            public List<Route> routes { get; set; }
            public string status { get; set; }
        }
    }
}

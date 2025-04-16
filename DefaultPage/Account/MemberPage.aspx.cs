/*
 * 
 * REFERENCES:
 * 
 * NaturalHazard - Earthquak Index Service References: 
 * API Information: https://earthquake.usgs.gov/fdsnws/event/1/ 
 * Additional:      https://docs.microsoft.com/en-us/dotnet/api/system.net.webclient.downloadstring?view=netcore-3.1 
 *                  
 * ZipCode Details Service References:
 *                  https://www.zippopotam.us/
 *                  https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=netcore-3.1
 * 
 * 
 */

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DefaultPage.Account
{
    public partial class MemberPage : System.Web.UI.Page
    {
        string startDate = "1919-10-16";                            // set a default start date
        string todaysDate = DateTime.Now.ToString("yyyy-MM-dd");    // store todays date to help when accessing service data (i.e. earthquake indexes)
        string urlSelection = "";   // used to store our users url selection for our Top10Words Service
        int dateIndex = 0;          // used to adjust the start date based on user selection from date range drowpdown
        int radiusSwitch = 0;       // used to adjust the radius based on user selection from the radius dropdown
        int magSwitch = 0;          // used to adjust the magnitude based on user selection
        double radius = 16.0934;    // initialize starting radius to 10 miles (16.0934 km)
        double magnitude = 2.5;     // initialize our minium earthquake magnitude
        int listIndex = 10;         // initialize our listIndex to a value outside of available indices 



        protected void Page_Load(object sender, EventArgs e)
        {
            //Index_Label0.Visible = false;
            LongLabel.Visible = false;
            LatLabel.Visible = false;
            EQLabel.Visible = false;
        }


        /*
         * Allows user to logout/signout of their membership account 
         * Takes them back to default page
         */
        protected void logoutBtn_Click(object sender, EventArgs e)
        {

            FormsAuthentication.SignOut();
            Session["MemberID"] = 0;
            Session["MemberName"] = "";
            Server.Transfer("~/Default.aspx");

        }


        /*
         * Takes a member back to our default page
         */
        protected void backBtn_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Default.aspx");
        }
        

        protected void weatherBtn_Click1(object sender, EventArgs e)
        {
            string month = MonthList.Text;
            double lat = 0, lon = 0;
    
            if (txtLatitude.Text != "" && txtLongitude.Text != "")
            {
                lat = Convert.ToDouble(txtLatitude.Text);
                lon = Convert.ToDouble(txtLongitude.Text);

                WeatherService.ServiceClient weatherServ = new WeatherService.ServiceClient();

                string[] data = weatherServ.GetWeatherData(month, lat, lon);
                yearLabel.Text = data[0];
                monthLabel.Text = data[1];
                tempLabel.Text = data[2];
                precLabel.Text = data[3];
                sunLabel.Text = data[4];
            }
            else
            {
                yearLabel.Text = "Please enter a location.";
                monthLabel.Text = "";
                tempLabel.Text = "";
                precLabel.Text = "";
                sunLabel.Text = "";
            }

        }


        /*
         *  Converting Zip Code to Latitude and Longitude Coordinates
         *  Earthquake index
         *  
         *  
         *  
         *  
         * Upon button click, we will first make sure the textbox is not empty 
         * and then we will make sure whatever is inputted is actually a valid expression
         * using Regular Expressions https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=netcore-3.1
         * As long as the zip code is valid, we will proceed to get the latitude and longitude coordinates
         */
         
        protected void Convert_Zip_Btn_Click(object sender, EventArgs e)
        {
            Boolean isValid = true;                         // used for error checking
            string zipCode = "";                            // string to store text for textbox1

            /*
             * ^ = matches beginning of line
             * \d{5} = match any decimal digit (0-9) maximum length = 5(or match exactly 5 times)
             * (...) = Capture matched text in parentheses
             * ?: = Non-Capturing Group
             * [-\s] = this groups white space inidators suchs as space, tab, \r & \n
             * \d{4} = match any decimal digit (0-9) exactly 4 times
             * ? = matches the characte before the ? zero or one times
             * $ = matches end of line
             * https://www.computerhope.com/jargon/r/regex.htm
             * 
             * What this expression does is it starts with the beginning of the string and 
             * it trys to match any decimal (0-9) 5 times . . . omitting things like white space.
             * Using RegEx allows me to simply check decimal without having to check for all characters.
             * I added the \d{4})?$ just incase the zip code service I used actually can convert zip codes
             * with the postal standard.
             */
            var zipValidation = @"^\d{5}(?:[-\s]\d{4})?$";

            if (TextBox1.Text != string.Empty && TextBox1.Text.Length == 5)
            {
                zipCode = TextBox1.Text.ToString();

                // if there is not a match . . . FALSE
                if (!Regex.Match(zipCode, zipValidation).Success)
                {
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
            }
            else
            {
                isValid = false;
            }

            // error printout to screen if the zip code is not valid.
            if (isValid == false)
            {
                ZipError.Text = "Please insert a valid zip code.";
            }

            else
            {
                ZipError.Text = string.Empty;       // clear the ziperror

                // below is the process of construction our Uri, creating a channel WebClient.

                Uri baseUri = new Uri("http://webstrar13.fulton.asu.edu/page0/api/CombinedServices1/");

                UriTemplate myTemplate = new UriTemplate("GetZipCodeDetails?zipCode={zipCode}");

                Uri completeUri = myTemplate.BindByPosition(baseUri, zipCode);

                WebClient channel = new WebClient();

                string responseString = channel.DownloadString(completeUri);    // download the "data" directly as a string

                var responses = (JArray)JsonConvert.DeserializeObject(responseString);  // deserialize the string we download and place in JArray

                JArray jobj = JArray.Parse(responses.ToString());   // parse our array for just the data we need.

                // store our data in a JToken to convert to string.
                JToken jToken1 = jobj[0];
                JToken jToken2 = jobj[1];

                LatLabel.Visible = true;
                LongLabel.Visible = true;
                LatitudeResult.Text = jToken1.ToString();
                LongitudeResult.Text = jToken2.ToString();
            }

        }

        /*
         * Keeps track of what Index is selected by our user for date range for 
         * our NaturalHazards (Earthquake Index) service provided by USGS. The date 
         * range calculatioin is done for our users. It will first look at the current 
         * date and based on our users selection, subtract a certain amount of years from
         * that date and use the new date as the "Start Date" for our Earthquake Index
         * Analysis.
         */
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateIndex = DropDownList1.SelectedIndex;   // get the index that is currently selected


            // arithmic switch to change the year based on the the current date
            switch (dateIndex)
            {
                // 10 years
                case 0:
                    var myDate0 = DateTime.Now;
                    var uriStartDate0 = myDate0.AddYears(-10);
                    startDate = uriStartDate0.ToString("yyyy-MM-dd");
                    break;

                // 25 years
                case 1:
                    var myDate1 = DateTime.Now;
                    var uriStartDate1 = myDate1.AddYears(-25);
                    startDate = uriStartDate1.ToString("yyyy-MM-dd");
                    break;

                // 50 years
                case 2:
                    var myDate2 = DateTime.Now;
                    var uriStartDate2 = myDate2.AddYears(-50);
                    startDate = uriStartDate2.ToString("yyyy-MM-dd");
                    break;

                // 100 years
                case 3:
                    var myDate3 = DateTime.Now;
                    var uriStartDate3 = myDate3.AddYears(-100);
                    startDate = uriStartDate3.ToString("yyyy-MM-dd");
                    break;
            }
        }

        /*
         * Keeps track of what Index is selected by our user for Radius for 
         * our NaturalHazards (Earthquake Index) service provided by USGS. The radius
         * is provided to our users in miles and a switch is used to convert them to 
         * km (required for our Earthquake service), but not neccessary. 
         */
        protected void DropDownList_Radius_SelectedIndexChanged(object sender, EventArgs e)
        {
            radiusSwitch = DropDownList_Radius.SelectedIndex;   // gets currently selected radius index

            // arithmic switch that converts the selection in miles to kilometers
            switch (radiusSwitch)
            {
                // 10 miles in km is 16.0934
                case 0:
                    radius = 16.0934;
                    break;

                // 25 miles in km is 40.2336
                case 1:
                    radius = 40.2336;
                    break;

                // 50 miles in km is 80.4672
                case 2:
                    radius = 80.4672;
                    break;

                // 100 miles in km is 160.934
                case 3:
                    radius = 160.934;
                    break;

                default:
                    break;
            }
        }

        /*
         * Keeps track of what Index is selected by our user for Minimum Magnitude for 
         * our NaturalHazards (Earthquake Index) service provided by USGS.
         */
        protected void DropDownList_Magnitude_SelectedIndexChanged(object sender, EventArgs e)
        {
            magSwitch = DropDownList_Magnitude.SelectedIndex;   // get currently selected mag index

            // switch to match the selection of the user.
            switch (magSwitch)
            {
                // 2.5
                case 0:
                    magnitude = 2.5;
                    break;

                // 3.0
                case 1:
                    magnitude = 3.0;
                    break;

                // 3.5
                case 2:
                    magnitude = 3.5;
                    break;

                // 4.0
                case 3:
                    magnitude = 4.0;
                    break;

                // 4.5
                case 4:
                    magnitude = 4.5;
                    break;

                // 5.0
                case 5:
                    magnitude = 5.0;
                    break;

                // 5.5
                case 6:
                    magnitude = 5.5;
                    break;

                // 6.0
                case 7:
                    magnitude = 6.0;
                    break;

                default:
                    break;
            }
        }


        /*
         * Earthquake Index button is what will activate/call our NaturalHazard Service
         * and return the earthquake index based on the latitude and longitude coordinates
         * provided by zip code conversion.
         */
        protected void Earthquake_Index_Btn_Click(object sender, EventArgs e)
        {
            Boolean isValid = true;     // handles error checking
            decimal latitude = 0;       // initialize latitude
            decimal longitude = 0;      // initialize longitude


            /*
             * nested if-if/else statement to check first if the textboxes for latitude or longitude are empty,
             * if they are not empty, we progress to the next check to make sure our input is actually a valid
             * latitude and longitude coordinate. -90 <= latitude < 90  && -180 <= longitude < 180. If these 
             * conditions are met, isValid = true. Otherewise, isValid = false. PRECAUTIONARY . . . OUR ZIP CODE
             * CONVERSION SHOULD PREVENT THIS FROM HAPPENING.
             */
            if (LatitudeResult.Text != string.Empty && LongitudeResult.Text != string.Empty)
            {
                decimal lat = Convert.ToDecimal(LatitudeResult.Text);      // store value from our latitude textbox
                decimal longi = Convert.ToDecimal(LongitudeResult.Text);   // store value from our longitude textbox

                if (lat >= -90 && lat < 90 && longi >= -180 && longi < 180)
                {
                    isValid = true;
                    latitude = lat;
                    longitude = longi;
                }
                else
                {
                    isValid = false;
                }
            }
            else
            {
                isValid = false;
            }

            // if isValid is false, display generic ERROR message.
            if (isValid == false)
            {
                Index_Label.ForeColor = Color.Maroon;
                Index_Label.Text = "ERROR: You must type in a zipcode to convert first!";

            }
            // else, carry on with calling service
            else
            {

                Index_Label.Text = string.Empty;     // erase our error label

                // below is the process of construction our Uri, creating a channel WebClient. 

                Uri baseUri = new Uri("http://webstrar61.fulton.asu.edu/page0/api/CombinedServices1/GetEarthQuakeHazard");

                UriTemplate myTemplate = new UriTemplate("?start={startDate}&latitude={latitude}&longitude={longitude}&radius={radius}&magnitude={magnitude}");

                Uri completeUri = myTemplate.BindByPosition(baseUri, startDate.ToString(), latitude.ToString(), longitude.ToString(), radius.ToString(), magnitude.ToString());

                WebClient channel = new WebClient();    // create a channel

                //           byte[] abc = channel.DownloadData(completeUri);

                string responseString = channel.DownloadString(completeUri);    //downloads the sources directly as a string

                //           Stream strm = new MemoryStream(abc);

                //            DataContractSerializer obj = new DataContractSerializer(typeof(string));

                //            string label = obj.ReadObject(strm).ToString();

                Index_Label.ForeColor = Color.Black;
                EQLabel.Visible = true;
                Index_Label.Text = responseString;                               // display our result in the GUI indexLabel


            }
        }

        protected void Wind_Button_Click(object sender, EventArgs e) {
            decimal check;
            if (decimal.TryParse(TextBox2.Text, out check)) //check if valid decimal
            {
                //local URI - "http://localhost:51519/Service1.svc/WindW?x=" + check.ToString()
                string sURL = "http://webstrar61.fulton.asu.edu/page6/Service1.svc/WindW?x=" + check.ToString(); //RESTful url
                WebRequest www = WebRequest.Create(sURL); //create RESTful link
                www.Method = "GET"; //define RESTful method
                var temp = www.GetResponse(); //call RESTful service
                Encoding enc = System.Text.Encoding.GetEncoding("utf-8"); //define RESTful encoding
                // read response stream from response object
                StreamReader loResponseStream = new StreamReader(temp.GetResponseStream(), enc); //get RESTful response from service
                // read string from stream data
                var strResult = loResponseStream.ReadToEnd(); //get RESTful message
                // close the stream object
                loResponseStream.Close(); //close StreamReader for RESTful message
                // close the response object
                temp.Close(); //close RESTful encoding
                Index_Label0.Text = strResult; //display wind warning result
            }
            else
            {
                Index_Label0.Text = "Not a valid decimal"; //display unvalid decimal error
                //Index_Label0.Visible = true;
            }
        }
    }
}
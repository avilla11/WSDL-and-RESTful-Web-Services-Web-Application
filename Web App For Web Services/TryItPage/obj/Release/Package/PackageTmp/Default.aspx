<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryItPage._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 














    <p>
        &nbsp;</p>
    <p>
        Required Service 1: Find Nearest Store Service<br />
</p>
    <p>
        (A) Description: This button below will invoke the findNearestStore service. Enter a zipcode into the first textbox, a store name into the second textbox and click on the button to invoke the service and see the output. This is service number 22 in the required services PDF</p>
    <p>
        (B) The WCF service URL is at <a href="http://webstrar59.fulton.asu.edu/page3/Service1.svc">http://webstrar59.fulton.asu.edu/page3/Service1.svc</a> </p>
    <p>
        (C)Operation: string FindNearestStore(string zipcode, string storeName), which takes a zipcode and store name and returns the closes store of that name based on the zip code proviced</p>
<p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="FindNearestStore" />
    <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Text="Output"></asp:Label>
</p>
<p>
    &nbsp;</p>
<p>
    Required Service 2: The US Government Data Services. Economic Research Service</p>
    <p>
        (A) Description: This button below will invoke a service that lists all the states the Economic Research Service has data on.This service takes no input as it just lists the states it has data on. It is one of the services offered in service number 24 in the required services PDF</p>
    <p>
        (B) The WCF service URL is at: <a href="http://webstrar59.fulton.asu.edu/page3/Service1.svc">http://webstrar59.fulton.asu.edu/page3/Service1.svc</a> </p>
    <p>
        (C) Operation: string ShowAllStates(); which takes no parameters and returns the list of states the Economic Research Service has data on</p>
<p>
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="ShowAllStates" />
    <asp:Label ID="Label2" runat="server" Text="Output"></asp:Label>
</p>
<p>
</p>
<p>
    Elective Service 1: Find sales tax rates for the zipcode entered
</p>
<p>
    (A) Description: This button below will invoke a service that will find sales tax rates. Enter a zipcode into the textbox and click the button to invoke the service and see the output</p>
<p>
    (B) The WCF service URL is at <a href="http://webstrar59.fulton.asu.edu/page3/Service1.svc">http://webstrar59.fulton.asu.edu/page3/Service1.svc</a> </p>
<p>
    (C) Operation: string getTax(string zipcode), which takes a zipcode and returns sales tax information with respect to the zipcode entered</p>
<p>
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="getTaxInformation" />
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <asp:Label ID="Label3" runat="server" Text="Output"></asp:Label>
</p>
<p>
</p>
<p>
    Elective Service 2: Gets the air quality index (AQI) of a city entered by the user</p>
<p>
    (A) Description: This button below will invoke a service that will find the air quality index (AQI) of a city entered by the user into the textbox</p>
<p>
    (B) The WCF service URL is at http://webstrar59.fulton.asu.edu/page3/Service1.svc</p>
<p>
    (C) Operation: string getAirQuality(string city), which takes a zity as a paramter and returns the air quality index of the entered city</p>
<p>
    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="getAirQualityIndex" />
    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
    <asp:Label ID="Label5" runat="server" Text="Output"></asp:Label>
</p>
<p>
</p>
<p>
    Elective Service 3 (RESTful service): Give directions between an origin and a destination with respect to the mode specified</p>
<p>
    (A) Description: This button below will invoke a RESTful service that gives the user directions based on origin entered, destination entered and mode entered</p>
<p>
    (B) The WCF RESTful service URL is at <a href="http://webstrar59.fulton.asu.edu/page4/Service1.svc">http://webstrar59.fulton.asu.edu/page4/Service1.svc</a></p>
<p>
    (C) Operation: string giveDirections(string origin, string destination, string mode). Origin is the name of the city or state you want to begin at, destination is the name of the city or state you want to end at, and mode can either be driving, walking, bicycling or transit</p>
<p>
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="giveDirections" />
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label4" runat="server" Text="Output"></asp:Label>
</p>
    <p>
        &nbsp;</p>
    <p>
        NOTE: For the functions below, they have only been implemented as try it functions for member.xml only because the staff.xml is the same logic as the member.xml and would be redundant and clutter the try it page. However, The code for both is given in the project source code.</p>
<p>
    Project 5 Try it function for component Aurelio Villalobos implemented. Remove a member&#39;s username and password from the member.xml file</p>
<p>
    (A) description: This button will invoke a service to delete from the Member.xml page located on the root of server directory</p>
<p>
    (B) The WCF service URL is at: <a href="http://webstrar59.fulton.asu.edu/page3/Service1.svc">http://webstrar59.fulton.asu.edu/page3/Service1.svc</a>
</p>
<p>
    (C) Operation: string removeFromMemberXML(string username);. Username is the username from the member.xml you want to remove. When invoked, a new xml file named newMember.xml will be created and placed in the root directory of the server. To test, the xml file contains usernames Test and Test2. When searching for these to remove, it should be successful but not for other usernames.</p>
<p>
    <asp:Button ID="Button6" runat="server" Text="Remove From Member XML" OnClick="Button6_Click" />
    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
    <asp:Label ID="Label6" runat="server" Text="Output"></asp:Label>
</p>
<p>
    &nbsp;</p>
<p>
    Project 5 Try it function for component Aurelio Villalobos implemented. Search the member.xml file for the username entered.
</p>
<p>
    (A) Description. This button will invoke a service to search the member.xml file for a username entered</p>
<p>
    (B) The WCF service URL is at: <a href="http://webstrar59.fulton.asu.edu/page3/Service1.svc">http://webstrar59.fulton.asu.edu/page3/Service1.svc</a> </p>
<p>
    (C) Operation: string&nbsp; searchMemberUsernameXML(string username). Username is the username to search for in the member.xml file. To test, the xml file contains usernames Test and Test2. When searching for these, it should be successful but not for other usernames.</p>
<p>
    <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Search for a Member Username" />
    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
    <asp:Label ID="Label8" runat="server" Text="Output"></asp:Label>
</p>
<p>
    &nbsp;</p>
<p>
    Project 5 Try it function for component Aurelio Villalobos implemented. Search the member xml file for the password entered</p>
<p>
    (A) Description: This button will invoke a service to search the member.xml file for the password entered</p>
<p>
    (B) The WCF service URL is at:
<a href="http://webstrar59.fulton.asu.edu/page3/Service1.svc">http://webstrar59.fulton.asu.edu/page3/Service1.svc</a>
</p>
<p>
    (C) Operation: string searchMemberPasswordXML(string password). Password is the password to search for in the member.xml file. To test, the xml file contains passwords check and check2. When searching for these, it should be successful but not for other passwords.</p>
<p>
    <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Search for a Member Password" />
    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
    <asp:Label ID="Label9" runat="server" Text="Output"></asp:Label>
</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>

 














</asp:Content>

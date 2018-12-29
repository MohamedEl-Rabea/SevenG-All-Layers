<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapFullAddress.aspx.cs" Inherits="sevenG.views.MapFullAddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title> Set location on google map</title>

    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=true&amp;key=AIzaSyBxSIvc-SjMH29kqrTyEnez53tt6eCfuxg" type="text/javascript"></script>


     <script type="text/javascript">

         function load() {
             if (GBrowserIsCompatible()) {
                 var map = new GMap2(document.getElementById("map"));
                 map.addControl(new GSmallMapControl());
                 map.addControl(new GMapTypeControl());
                 var center = new GLatLng(24.6993078, 46.6849328);
                 map.setCenter(center, 14);
                 map.setMapType(G_SATELLITE_MAP);
                 geocoder = new GClientGeocoder();
                 
                 var marker = new GMarker(center, { draggable: true });
                 map.addOverlay(marker);
                
                 document.getElementById("lat").value = center.lat();
                 document.getElementById("lng").value = center.lng();

                 geocoder = new GClientGeocoder();

                 GEvent.addListener(marker, "dragend", function() {
                     var point = marker.getPoint();
                     map.panTo(point);
                     alert(point);
                     document.getElementById("lat").value = point.lat();
                     document.getElementById("lng").value = point.lng();
                 });

                 GEvent.addListener(map, "moveend", function() {
                     map.clearOverlays();
                     var center = map.getCenter();
                     var marker = new GMarker(center, { draggable: true });
                     map.addOverlay(marker);
                     document.getElementById("lat").value = center.lat();
                     document.getElementById("lng").value = center.lng();

                     GEvent.addListener(marker, "dragend", function() {
                     var point = marker.getPoint();
                    
                         map.panTo(point);
                         document.getElementById("lat").value = point.lat();
                         document.getElementById("lng").value = point.lng();
                     });
                 });
             }
         }

         function showAddress(address) {
             
             var map = new GMap2(document.getElementById("map"));
             map.addControl(new GSmallMapControl());
             map.addControl(new GMapTypeControl());
             if (geocoder) {
                 geocoder.getLatLng(
address,
function(point) {
    if (!point) {
        alert(address + " city not found !");
    }
    else {
        document.getElementById("lat").value = point.lat();
        document.getElementById("lng").value = point.lng();
        map.clearOverlays()
        map.setCenter(point, 14);
        var marker = new GMarker(point, { draggable: true });
        map.addOverlay(marker);

        GEvent.addListener(marker, "dragend", function() {
            var pt = marker.getPoint();
            map.panTo(pt);
            document.getElementById("lat").value = pt.lat();
            document.getElementById("lng").value = pt.lng();
        });

        GEvent.addListener(map, "moveend", function() {
            map.clearOverlays();
            var center = map.getCenter();
            var marker = new GMarker(center, { draggable: true });
            map.addOverlay(marker);
            document.getElementById("lat").value = center.lat();
            document.getElementById("lng").value = center.lng();

            GEvent.addListener(marker, "dragend", function() {
                var pt = marker.getPoint();
                map.panTo(pt);
                document.getElementById("lat").value = pt.lat();
                document.getElementById("lng").value = pt.lng();
            });
        });
    } 
}
);
             } 
         }
    </script>
</head>
<body onload="load()" onunload="GUnload()">

     <script language="JavaScript">
<!--
         var message = "";
         function clickIE() { if (document.all) { (message); return false; } }
         function clickNS(e) {
             if
(document.layers || (document.getElementById && !document.all)) {
                 if (e.which == 2 || e.which == 3) { (message); return false; }
             }
         }
         if (document.layers)
         { document.captureEvents(Event.MOUSEDOWN); document.onmousedown = clickNS; }
         else { document.onmouseup = clickNS; document.oncontextmenu = clickIE; }
         document.oncontextmenu = new Function("return false")
// -->
    </script>
    <form id="form1" runat="server">

    <div>
             <asp:TextBox    runat="server" id="lat" name="latitude"></asp:TextBox>
            <asp:TextBox   runat="server" id="lng" name="longitude"></asp:TextBox>
     <div align="center" id="map" style="width: 600px; height: 400px"></div>
            <br />
            Title
             <asp:TextBox   runat="server" id="Titles" name="Titles"></asp:TextBox>
             <br /> Description
             <asp:TextBox   runat="server" id="Description" name="Description"></asp:TextBox>

            <br />
        <asp:TextBox   runat="server" id="Full_address" name="Description"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Add New Location" OnClick="Button1_Click" />
           
        </div>

         <asp:GridView ID="GridView2" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
    runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" />
        <asp:BoundField DataField="Address" HeaderText="Address" />
        <asp:BoundField DataField="Latitude" HeaderText="Latitude" />
        <asp:BoundField DataField="Longitude" HeaderText="Longitude" />
    </Columns>
</asp:GridView>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" InsertVisible="False" SortExpression="Id"></asp:BoundField>
                 <asp:BoundField DataField="lat" HeaderText="lat" SortExpression="lat"></asp:BoundField>
                <asp:BoundField DataField="lng" HeaderText="lng" SortExpression="lng"></asp:BoundField>
                <asp:BoundField DataField="Descrption" HeaderText="Descrption" SortExpression="Descrption"></asp:BoundField>
                
                <asp:BoundField DataField="Titles" HeaderText="Titles" SortExpression="Titles" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" 
            ConflictDetection="CompareAllValues" 
            ConnectionString='<%$ ConnectionStrings:7GConnectionString %>' 
            DeleteCommand="DELETE FROM [Full_address] WHERE [id] = @original_id AND (([lat] = @original_lat) OR ([lat] IS NULL AND @original_lat IS NULL)) AND (([lng] = @original_lng) OR ([lng] IS NULL AND @original_lng IS NULL)) AND (([Description] = @original_Description) OR ([Description] IS NULL AND @original_Description IS NULL)) AND (([Titles] = @original_Titles) OR ([Titles] IS NULL AND @original_Titles IS NULL))" 
            InsertCommand="INSERT INTO [Full_address] ([lat], [lng], [Description], [Titles]) VALUES (@lat, @lng, @Description, @Titles)" 
            OldValuesParameterFormatString="original_{0}" 
            SelectCommand="SELECT * FROM [Full_address]" 
            UpdateCommand="UPDATE [Full_address] SET [lat] = @lat, [lng] = @lng, [Description] = @Description, [Titles] = @Titles WHERE [id] = @original_id AND (([lat] = @original_lat) OR ([lat] IS NULL AND @original_lat IS NULL)) AND (([lng] = @original_lng) OR ([lng] IS NULL AND @original_lng IS NULL)) AND (([Description] = @original_Description) OR ([Description] IS NULL AND @original_Description IS NULL)) AND (([Titles] = @original_Titles) OR ([Titles] IS NULL AND @original_Titles IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_id" Type="Int32" />
                <asp:Parameter Name="original_lat" Type="String" />
                <asp:Parameter Name="original_lng" Type="String" />
                <asp:Parameter Name="original_Description" Type="String" />
                <asp:Parameter Name="original_Titles" Type="String" />
            </DeleteParameters>
            <InsertParameters>
              <asp:ControlParameter ControlID="lat" Name="lat" Type="String" />
              <asp:ControlParameter ControlID="lng" Name="lng" Type="String" />
              <asp:ControlParameter ControlID="Description"  Name="Description" Type="String" />
              <asp:ControlParameter ControlID="Titles"  Name="Titles" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="lat" Type="String" />
                <asp:Parameter Name="lng" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Titles" Type="String" />
                <asp:Parameter Name="original_id" Type="Int32" />
                <asp:Parameter Name="original_lat" Type="String" />
                <asp:Parameter Name="original_lng" Type="String" />
                <asp:Parameter Name="original_Description" Type="String" />
                <asp:Parameter Name="original_Titles" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="TECHNICAL.APP.Page2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Left-aligned -->
    <div class="media">
        <div class="media-left">
            <img src="https://www.w3schools.com/bootstrap/img_avatar1.png" class="media-object" style="width: 60px">
        </div>
        <div class="media-body">
            <h4 class="media-heading">
                <asp:Label runat="server" ID="lblName"></asp:Label></h4>
            <p>Age:
                <asp:Label runat="server" ID="lblAge"></asp:Label></p>
            <p>Type:
                <asp:Label runat="server" ID="lblType"></asp:Label></p>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_content">
            <canvas id="mybarChart"></canvas>
        </div>
    </div>
<script>
    function randomDate(start, end) {
        return new Date(start.getTime() + Math.random() * (end.getTime() - start.getTime()));
    }
    function between(min, max) {
        return Math.floor(
            Math.random() * (max - min) + min
        )
    }

    var randomDates = [];
    var randomNumbers = [];

    for (var i = 0; i < 10; i++) {        
        var date = randomDate(new Date(2012, 0, 1), new Date()).toISOString().split("T")[0];
        randomDates.push(date);
        var number = between(1, 100);
        randomNumbers.push(number);
    }


    var ctx = document.getElementById("mybarChart").getContext("2d");

    var mybarChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: randomDates,
            datasets: [{
                data: randomNumbers,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(255, 159, 64, 0.2)',
                    'rgba(255, 205, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(201, 203, 207, 0.2)',
                    'rgba(201, 233, 207, 0.2)',
                    'rgba(201, 223, 207, 0.2)',
                    'rgba(201, 213, 207, 0.2)'
                ]
            }],
            
        },

        
    });
</script>
</asp:Content>

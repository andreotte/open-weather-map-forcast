
function getWeather(callback) {
    var weather = 'https://api.openweathermap.org/data/2.5/forecast?zip=' + zipCode.value + '&appid=' + apiKey;
    $.ajax({
        dataType: "jsonp",
        jsonpCallback: 'jsonCallback',
        url: weather,
        success: callback
    }).fail(function () {
        alert("Invalid zip code. Forecast not retrieved.");
    });
}

//Called on form submit when user enters a zipcode
function getFiveDayThreeHourWeather() {

    getWeather(function (data) {
        console.log('weather data received');
        const weatherForecasts = data["list"];
        const tableDiv = document.getElementById("table");
        const weatherTable = document.getElementsByClassName("table");

        //Table header
        document.getElementById("cityName").innerHTML = `${data["city"]["name"]}, ${data["city"]["country"]}`;
        tableDiv.innerHTML = '<table class="table"><tr><th>Date</th><th>Temperature (°F)</th><th>Pressure (hPa)</th><th></th></tr>';

        //Create a new row for each forecast data point
        weatherForecasts.forEach(function (item) {
            let newRow = document.createElement('tr');
            newRow.innerHTML = `<tr><td>${item["dt_txt"]}</td><td>${(1.8 * (item["main"]["temp"] - 273.15) + 32).toFixed(1)}</td><td>${item["main"]["pressure"]}</td><tr>`;
            weatherTable[0].appendChild(newRow);
        });

    tableDiv.innerHTML += '</table>';
    });
}


function getFiveDayThreeHourWeather() {
    const tableDiv = document.getElementById("table");

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

    // get data:
    getWeather(function (data) {
        console.log('weather data received');
        //console.log(data);
        document.getElementById("cityName").innerHTML = `${data["city"]["name"]}, ${data["city"]["country"]}`;
        const weatherForecasts = data["list"];

        tableDiv.innerHTML = '<table class="table"><tr><th>Date</th><th>Temperature (°F)</th><th>Pressure (hPa)</th><th></th></tr>';
        const weatherTable = document.getElementsByClassName("table");

        weatherForecasts.forEach(function (item) {
        let newRow = document.createElement('tr');
        newRow.innerHTML = `<tr><td>${item["dt_txt"]}</td><td>${(1.8 * (item["main"]["temp"] - 273.15) + 32).toFixed(1)}</td><td>${item["main"]["pressure"]}</td><tr>`;
        weatherTable[0].appendChild(newRow);
        });

    tableDiv.innerHTML += '</table>';
    });
}

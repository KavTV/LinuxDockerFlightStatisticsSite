// Initialize the echarts instance based on the prepared dom
var myChart = echarts.init(document.getElementById('main'));

// Specify the configuration items and data for the chart
var option = {
    title: {
        text: 'Yearly Flight Crashes'
    },
    tooltip: {},
    legend: {
        data: ['Crashes']
    },
    xAxis: {
        data: []
    },
    yAxis: {},
    series: [
        {
            
        }
    ]
};


// Display the chart using the configuration items and data just specified.
myChart.setOption(option);

function yearlyCrashes(crashes) {
    console.log(crashes);
    myChart.setOption({
        xAxis: {
            data: crashes.map((c) => c.Year)
        },
        series: [
            {
                name: 'Crashes',
                type: 'bar',
                data: crashes.map((c) => c.Crashes)
            },
            {
                name: 'Deaths',
                type: 'line',
                data: crashes.map((c) => c.Deaths)
            }
        ]
})
}
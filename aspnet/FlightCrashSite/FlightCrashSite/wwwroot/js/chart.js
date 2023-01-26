// Initialize the echarts instance based on the prepared dom
var myChart = echarts.init(document.getElementById('main'));

// Specify the configuration items and data for the chart
var option = {
    title: {
        text: 'Yearly Flight Crashes'
    },
    tooltip: {},
    legend: {
        data: ['Crashes', 'Deaths']
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
        yAxis: 
            [{
                offset: 0,
                nameGap: 40,
                nameLocation: "center",
                position: "right",
                type: "value",
                name: "Crashes"
            },
            {
                offset: 60,
                nameGap: 40,
                nameLocation: "center",
                position: "right",
                type: "value",
                name: "Deaths"
            }
            ]
        ,
series: [
    {
        name: 'Crashes',
        type: 'bar',
        yAxisIndex: 0,
        data: crashes.map((c) => c.Crashes)
    },
    {
        name: 'Deaths',
        type: 'line',
        yAxisIndex: 1,
        data: crashes.map((c) => c.Deaths)
    }
]
})
}
// Initialize the echarts instance based on the prepared dom
var myChart = echarts.init(document.getElementById('yearly'));
var operatorChart = echarts.init(document.getElementById('operator'));

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
                nameGap: 30,
                nameLocation: "center",
                position: "right",
                type: "value",
                name: "Crashes"
            },
            {
                offset: 40,
                nameGap: 45,
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

function operatorCrashes(crashes) {
    console.log(crashes);
    operatorChart.setOption({
        title: {
            text: 'Operator Crashes'
        },
        tooltip: {},
        legend: {
            data: ['Crashes', 'Deaths']
        },
        xAxis: {
            data: crashes.map((c) => c.Operator)
        },
        dataZoom: [
            {
                show: true,
            },
        ],
        yAxis:
            [{
                offset: 0,
                nameGap: 30,
                nameLocation: "center",
                position: "right",
                type: "value",
                name: "Crashes"
            },
                {
                    offset: 40,
                    nameGap: 45,
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
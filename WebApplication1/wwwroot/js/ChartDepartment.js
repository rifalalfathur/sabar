$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:7138/api/Department',
        headers: {
            'Authorization': "Bearer " + sessionStorage.getItem("token"),
        },
    }).done((data) => {
        console.log("test");
        console.log(data);
        var DivisionId = data.data
            .map(x => ({ divisionId: x.divisionId }));
        //var divisionId2 = DivisionId[0].divisionId;
        var { divisionId1, divisionId2, divisionId3 } = DivisionId.reduce((previous, current) => {
            if (current.divisionId === 3) {
                //... adalah spread operator
                // spread untuk memecah array-nya 
                return { ...previous, divisionId1: previous.divisionId1 + 1 }
            }
            //console.log(previous, "ytt+otak");
            if (current.divisionId === 4) {
                return { ...previous, divisionId2: previous.divisionId2 + 1 }
            }
            if (current.divisionId === 5) {
                return { ...previous, divisionId3: previous.divisionId3 + 1 }
            }
        }, { divisionId1: 0, divisionId2: 0, divisionId3: 0 })

        //console.log(divisonFiltered);
        //console.log(DivisionId);
        //console.log(DivisionId[0].divisionId);
        //var res = JSON.stringify(DivisionId);
        //console.log(res);
        //var ex = "5";
        var Piechart = {
            series: [divisionId1, divisionId2, divisionId3],
            chart: {
                width: 480,
                height: '300%',
                type: 'pie',
            },
            labels: ['Division Id: 1', 'Division Id: 2', 'Division Id: 3'],
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        show: true,
                        position: 'right',
                    }
                }
            }]
        };
        var Chart2 = {
            series: [{
                data: [divisionId1, divisionId2, divisionId3],
            }],
            chart: {
                height: 350,
                type: 'bar',
                events: {
                    click: function (chart, w, e) {
                        // console.log(chart, w, e)
                    }
                }
            },
            plotOptions: {
                bar: {
                    columnWidth: '45%',
                    distributed: true,
                }
            },
            dataLabels: {
                enabled: false
            },
            legend: {
                show: false
            },
            xaxis: {
                categories: [
                    ['Division Id: 1'],
                    ['Division Id: 2'],
                    ['Division Id: 3'],
                ],
                labels: {
                    style: {
                        fontSize: '12px'
                    }
                }
            }
        };
        //console.log(JSON.stringify(options));
        var chart = new ApexCharts(document.querySelector("#stat-chart"), Piechart);
        var line = new ApexCharts(document.querySelector("#next-chart"), Chart2);
        //console.log(chart);
        chart.render();
        line.render();
    });
});
$(document).ready(function () {
    //Peticion a API
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: urlBase + '/GeneralFederation',
        error: function () {
            alert("Ocurrio un error al consultar los datos");
        },
        success: function (data) {
            reternAll(data);
        }
    })
});
function reternAll(Mname, ChartId, typeN, LableT) {

    let cardColor, headingColor, axisColor, borderColor, shadeColor;

    if (isDarkStyle) {
        cardColor = config.colors_dark.cardColor;
        headingColor = config.colors_dark.headingColor;
        axisColor = config.colors_dark.axisColor;
        borderColor = config.colors_dark.borderColor;
        shadeColor = 'dark';
    } else {
        cardColor = config.colors.white;
        headingColor = config.colors.headingColor;
        axisColor = config.colors.axisColor;
        borderColor = config.colors.borderColor;
        shadeColor = 'light';
    }

    // Report Chart
    // -------------------------------------------------------------------- 



    var a = 0;
    var b = 0;
    var c = 0;
    var d = 0;
    var Aa = 0;
    var Bb = 0;
    var Cc = 0;
    var Dd = 0;

    $.ajax({

        type: "GET",

        //url: 'Url.Action("", "Investigation")',
        url: '/Home/' + Mname + '',
        //url:'/Investigation/headSumitionjson',
        data: { type: typeN },
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (i) {

            a = i.a;
            b = i.b;
            c = i.c;
            d = i.d;
            Aa = i.Aa;
            Bb = i.Bb;
            Cc = i.Cc;
            Dd = i.Dd;
            PrCount = i.PrCount;
            ReCount = i.ReCount;
            $(".PrCount").html(i.PrCount);
            $(".ReCount").html(i.ReCount);
            // Visits - Multi Radial Bar Chart
            // --------------------------------------------------------------------
            const visitsRadialChartEl = document.querySelector(ChartId),


                visitsRadialChartConfig = {


                    chart: {
                        height: 260,


                        type: 'radialBar'
                    },
                    colors: [config.colors.primary, config.colors.danger, config.colors.warning, config.colors.success],
                    series: [Aa, Bb, Cc, Dd],
                    plotOptions: {
                        radialBar: {
                            offsetY: -17,

                            hollow: {
                                size: '43%'
                            },
                            track: {
                                margin: 7,

                                background: cardColor
                            },
                            dataLabels: {
                                name: {

                                    fontSize: '15px',
                                    colors: [config.colors.secondary],
                                    fontFamily: 'IBM Plex Sans',
                                    offsetY: 25
                                },
                                value: {
                                    fontSize: '2rem',
                                    fontFamily: 'Rubik',
                                    fontWeight: 500,
                                    color: headingColor,
                                    offsetY: -15

                                },
                                total: {

                                    show: true,
                                    label: ' أجمالي  ' + LableT,
                                    formatter: function (data) {

                                        return a + b + d + c;
                                    },
                                    fontSize: '15px',
                                    fontWeight: 400,
                                    fontFamily: 'IBM Plex Sans',
                                    color: config.colors.secondary
                                }
                            }
                        }
                    },
                    grid: {
                        padding: {
                            top: -1,
                            bottom: -1
                        }
                    },
                    stroke: {
                        lineCap: 'round'
                    },
                    labels: [a + '   ' + 'واردة', b + '   ' + 'مقيدة', c + '   ' + 'محالة', d + '   ' + 'منجزة'],
                    legend: {
                        show: true,
                        position: 'bottom',
                        horizontalAlign: 'center',
                        labels: {
                            colors: axisColor,
                            useSeriesColors: false
                        },
                        itemMargin: {
                            horizontal: 5
                        },
                        markers: {
                            width: 10,
                            height: 10,
                            offsetX: -3
                        }
                    }
                };




            if (typeof visitsRadialChartEl !== undefined && visitsRadialChartEl !== null) {
                const visitsRadialChart = new ApexCharts(visitsRadialChartEl, visitsRadialChartConfig);
                visitsRadialChart.render();
            }
        }//نهاية نجاح الاجاكس

    });//نهاية الاجاكس
}

'use strict';
(function () {


    radialChart();
    reternAll("headSumitionjson", "#visitsRadialChart", 1, "الشكاوى");
    reternAll("headSumitionjson", "#visitsRadialChart2", 2, "التحقيق");
    reternAll("headSumitionjson", "#visitsRadialChart3", 3, "الدعاوى");
    reternAll("headSumitionjson", "#visitsRadialChart4", 4, "الدعاوى");


})();

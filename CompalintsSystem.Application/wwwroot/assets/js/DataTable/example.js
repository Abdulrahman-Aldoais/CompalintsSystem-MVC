$(document).ready(function () {
    'use strict';

    //----------------------------------------------
    //note that this is the old yadcf API for init the filters 
    //new init function should be used when working with new Datatable (capital "D" API)
    //for new init function see: http://yadcf-showcase.appspot.com/DOM_Ajax_Multiple_1.10.html
    //----------------------------------------------

    var firstTable = $('#example1').dataTable({
        "bJQueryUI": true
    }).yadcf([{
        column_number: 0
    }, {
        column_number: 1,
        filter_type: "range_number",
        filter_container_id: "external_filter_container"
    }, {
        column_number: 2,
        data: [{
            value: 'Yes',
            label: 'Yessss :)'
        }, {
            value: 'No',
            label: 'Noooo :('
        }],
        filter_default_label: "Select Yes/No"
    }, {
        column_number: 3,
        filter_type: "text",
        text_data_delimiter: ",",
        filter_delay: 1500,
        filter_default_label: 'Filter delay is enabled!'
    }, {
        column_number: 4,
        column_data_type: "html",
        html_data_type: "text",
        filter_default_label: "Select tag"
    }]);

    yadcf.exFilterColumn(firstTable, [
        [1, {
            from: 1,
            to: 40
        }],
        [3, "a_value"]
    ]);

    $('#example2').dataTable({
        "bJQueryUI": true
    }).yadcf([{
        column_number: 0,
        filter_type: "range_number_slider",
        ignore_char: ","
    }, {
        column_number: 2,
        filter_type: "auto_complete",
        text_data_delimiter: ",",
        filter_default_label: "Enter a value"
    }, {
        column_number: 3,
        column_data_type: "html",
        html_data_type: "text",
        filter_default_label: "Choose label"
    }],
        'footer');


    $('#example3').dataTable({
        "bJQueryUI": true
    }).yadcf([{
        column_number: 0
    }, {
        column_number: 1,
        filter_default_label: "Pick some"
    }, {
        column_number: 2,
        text_data_delimiter: ",",
        enable_auto_complete: true
    }]);

});
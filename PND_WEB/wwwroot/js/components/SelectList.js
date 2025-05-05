const { select } = require("d3-selection");

$(document).ready(function () {
    // Select2 for Cport
    select2_cport();
    // Select2 for two columns
    select2_two_columns();

    // Select2 for invoice charge
    select2_invoice_charge();
   

})
// Select2 for invoice charge
function select2_invoice_charge() {

} 

// select2_two_columns code _ name 
function select2_two_columns() {
    let header = null;
    function formatState2(state) {
        if (!state.id) {
            return state.text;
        }
        if (state.id == '-1') {
            console.log('kien');
            var $state = $(
                '<div class="row px-2 py-1" style="background-color:#d1e7dd; color:#0f5132; font-weight:bold; border-radius:4px;">' +
                '<div class="col-6">' + header.header_code + '</div>' +
                '<div class="col-6">' + header.header_name + '</div>' +
                '</div>'
            );
            return $state;
        }
        var $state = $(
            '<div class="row">' +
            '<div class="col-6">' + state.id + '</div>' +
            '<div class="col-6">' + state.text + '</div>' +
            '</div>'
        );
        return $state;
    }

    function formatState(state) {

        if (!state.id) {
            return state.text;
        }
        var $state = $(
            '<span>' + state.text + '</span>'

        );
        return $state;
    }

    // General select2 not tag 
    $('.select2-not-tag').each(function () {
        const $select = $(this);
        const url = $select.data('url');

        $select.select2({
            ajax: {
                url: url,
                dataType: 'json',
                data: function (params) {
                    return {
                        q: params.term || '',
                        page: params.page
                    };
                },
                processResults: function (data, params) {
                    params.page = params.page || 1;
                    header = data.header;
                    console.log(header);
                   
                    return {
                        results: data.items,
                        pagination: {
                            more: (params.page * 10) < data.total_count
                        }
                    };
                },
                cache: true
            },
            minimumInputLength: 0,
            templateResult: formatState2,
            templateSelection: formatState,
           
            allowClear: true,
            theme: 'bootstrap4',
            width: '100%',
        });

    });



}

// Select2 for Cport
function select2_cport() {
    let header = null;
    function formatPort(state) {
        if (!state.code) {
            return state.text;
        }
        if (state.code == '-1') {
            var $state = $(
                '<div class="row px-2 py-1" style="background-color:#d1e7dd; color:#0f5132; font-weight:bold; border-radius:4px;">' +
                '<div class="col-6">' + header.header_code + '</div>' +
                '<div class="col-6">' + header.header_name + '</div>' +
                '</div>'
            );
            return $state;
        }
        var $state = $(
            '<div class="row px-2 py-1">' +
            '<div class="col-6">' + state.code + '</div>' +
            '<div class="col-6">' + state.text + '</div>' +
            '</div>'
        );
        return $state;
    }

    function SelectPort(state) {

        if (!state.code) {
            return state.text;
        }
        var $state = $(
            '<span>' + state.text + '</span>'

        );
        return $state;
    }

    // Select in port by NguyenKien
    $('.select-port').each(function () {
        const $select = $(this);
        const url = $select.data('url');

        $select.select2({
            ajax: {
                url: url,
                dataType: 'json',
                data: function (params) {
                    return {
                        q: params.term || '',
                        page: params.page
                    };
                },
                processResults: function (data, params) {
                    params.page = params.page || 1;
                    header = data.header;
                    return {
                        results: data.items,
                        pagination: {
                            more: (params.page * 10) < data.total_count
                        }
                    };
                },
                cache: true
            },

            minimumInputLength: 0,
            templateResult: formatPort,
            templateSelection: SelectPort,
            placeholder: 'Select Port',
            allowClear: true,
            theme: 'bootstrap4',
            width: '100%',
        });
    });

}

// Select2 for Invoice Charge
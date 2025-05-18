
$(document).ready(function () {
    // Select2 for Cport
    select2_cport();
    // Select2 for two columns
    select2_two_columns();

    // Select2 for invoice charge
    select2_fee();

    //
    select2_two_columns_code();
   

})
// Select2 for Fee
function select2_fee() {
    let header = null;
    function formatFee(state) {
        if (!state.id) {
            return state.text;
        }
        if (state.id == '-1') {
            var $state = $(
                '<div class="row px-2 py-1" style="background-color:#d1e7dd; color:#0f5132; font-weight:bold; border-radius:4px;">' +
                '<div class="col-4">' + header.header_code + '</div>' +
                '<div class="col-4">' + header.header_name + '</div>' +
                '<div class="col-4">' + header.header_unit + '</div>' +
                '</div>'
            );
            return $state;
        }
        var $state = $(
            '<div class="row px-2 py-1">' +
            '<div class="col-4">' + state.id + '</div>' +
            '<div class="col-4">' + state.text + '</div>' +
            '<div class="col-4">' + state.unit + '</div>' +
            '</div>'
        );
        return $state;
    }
    function SelectFee(state) {
        if (!state.id) {
            return state.text;
        }
        var $state = $(
            '<span>' + state.id + '</span>'
        );
        return $state;
    }
    // Select in Fee by NguyenKien
    $('.select-fee').each(function () {
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
            tags: true,
            minimumInputLength: 0,
            templateResult: formatFee,
            templateSelection: SelectFee,
            dropdownAutoWidth: true,
            placeholder: 'Select Fee',
           
            theme: 'bootstrap4',
            width: '100%',
        });
    });


    //auto type in unit and quantity
    $('.select-fee').on('select2:select', function (e) {
        var data = e.params.data;
        var cur_unit = $('#Charge_SerUnit').val();
        var cur_quantity = $('#Charge_SerQuantity').val();
        $('#Charge_SerUnit').val(data.unit);
        if (cur_quantity == null || cur_quantity == '') {
            $('#Charge_SerQuantity').val(1);
        } 
    });
} 

// select2_two_columns code _ name 
function select2_two_columns() {
    let header = null;
    function formatState2(state) {
        if (!state.id) {
            return state.text;
        }
        if (state.id == '-1') {
           
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

function select2_two_columns_code() {
    let header = null;
    function formatState2(state) {
        if (!state.id) {
            return state.text;
        }
        if (state.id == '-1') {

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
            '<span>' + state.id + '</span>'

        );
        return $state;
    }

    // General select2 not tag 
    $('.select2-code').each(function () {
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

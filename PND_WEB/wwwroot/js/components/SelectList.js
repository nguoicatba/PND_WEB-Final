function formatState2(state) {
    if (!state.id) {
        return state.text;
    }
    var $state = $(
        '<div class="row">' +
        '<div class="col-6">' + state.id + '</div>' +
        '<div class="col-6">' + state.text + '</div>' +
        '</div>'
    );
    return $state;
}
// Function to format the state


function formatState(state) {

    if (!state.id) {
        return state.text;
    }
    var $state = $(
        '<span>' + state.text + '</span>'

    );
    return $state;
}
// Initialize Select2
$('.select2-not-tag').each(function () {
    const $select = $(this);
    const url = $select.data('url');

    $select.select2({
        ajax: {
            url: url,
            dataType: 'json',
            data: function (params) {
                return {
                    q: params.term,
                    page: params.page
                };
            },
            processResults: function (data, params) {
                params.page = params.page || 1;

                return {
                    results: data.items,
                    pagination: {
                        more: (params.page * 10) < data.total_count
                    }
                };
            },
            cache: true
        },
        minimumInputLength: 1,
        templateResult: formatState2,
        templateSelection: formatState,
        placeholder: 'Select an option Code - Name',
        allowClear: true,
        theme: 'bootstrap4',
    });
});

$('.select2-tag').each(function () {
    const $select = $(this);
    const url = $select.data('url');

    $select.select2({
        ajax: {
            url: url,
            dataType: 'json',
            data: function (params) {
                return {
                    q: params.term,
                    page: params.page
                };
            },
            processResults: function (data, params) {
                params.page = params.page || 1;

                return {
                    results: data.items,
                    pagination: {
                        more: (params.page * 10) < data.total_count
                    }
                };
            },
            cache: true
        },
        minimumInputLength: 1,
        templateResult: formatState2,
        templateSelection: formatState,
        placeholder: 'Select an option Code - Name',
        allowClear: true,
        theme: 'bootstrap4',
    });
});
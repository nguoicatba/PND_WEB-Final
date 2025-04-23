newFunction();

function newFunction() {
    (function() {
        $(document).on('click', '#create', function() {
            $('#myModalLarge').modal('show');

        });
        

        $(document).on('click', '.edit-btn', function () {
            var id = $(this).data('id');
            var url = '/Kindofpackage/Edit/' + id;
            $.ajax({
                type: 'GET',
                url: url,
                success: function (response) {

                    $('#get_modal').html(response);
                 

                    $('#myModalLargeEdit').modal('show');
                    
                    
                },
                error: function (xhr, status, error) {
                    // Handle error
                    console.error(error);
                }
            });
        })


        $(document).on('submit', '#createform', function (e) {

            e.preventDefault();
            var form = $(this);
            var url = form.attr('action');
            var data = form.serialize();
            $.ajax({
                type: 'POST',
                url: url,
                data: data,
                success: function (response) {
                    if (response.success) {
                        $('#myModalLarge').modal('hide');
                        // Reload the page or update the UI as needed
                        location.reload();
                    } else {
                        // Handle validation errors
                        $('#errorMessage').text(response.message).show();
                    }
                },
                error: function (xhr, status, error) {
                    // Handle server errors
                    $('#errorMessage').text('An error occurred. Please try again.').show();
                }
            });


        })

        $(document).on('submit', '#editform', function (e) {
            e.preventDefault();
            var form = $(this);
            var url = form.attr('action');
            var data = form.serialize();
            $.ajax({
                type: 'POST',
                url: url,
                data: data,
                success: function (response) {
                    if (response.success) {
                        $('#myModalLargeEdit').modal('hide');
                        // Reload the page or update the UI as needed
                        location.reload();
                    } else {
                        // Handle validation errors
                        $('#errorMessage').text(response.message).show();
                    }
                },
                error: function (xhr, status, error) {
                    // Handle server errors
                    $('#errorMessage').text('An error occurred. Please try again.').show();
                }
            });
        })
    })();
}

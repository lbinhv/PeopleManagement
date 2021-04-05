var HOMEPAGE = {
    key_words: '',
    url_list: '',
    url_create_csv: '',
    url_search: '',
    url_detail_index: '',
    datatable: {},
    init_page: function () { //Only init when load page
        HOMEPAGE.init_list();
    },
    init_list: function () {
        HOMEPAGE.datatable = $("#table-data").on('error.dt', function (e, settings, techNote, message) {
            toastr.error(message);
        }).DataTable({
            "pagingType": "full_numbers",
            "processing": true,
            "serverSide": true,            
            "ajax": {
                "url": HOMEPAGE.url_list,
                "type": "POST",
                "complete": function () {
                    $(".btn-tooltip").tooltip();
                },
                "error": function (err) {
                    toastr.error(err.responseJSON.error);
                }
            },
            //"columnDefs": [
            //    {
            //        "targets": [0, 1, 2, 3, 4, 5],
            //        "orderable": false,
            //    }
            //],
            "columns": [
                { "data": "SN" },
                {
                    "data": "NRIC",
                    "render": function (data, type, full, meta) {
                        return '<a href="' + window.location.href +'Home/Register?key='+ data +'">' + data + '</a>';
                    }
                },
                { "data": "Name" },
                { "data": "Gender" },
                { "data": "Age" },
                { "data": "NumberOfSubjects" },
            ],
            "bDestroy": true
        });

        
    },
    init_action_list: function () {
        $('.btn-view-detail-item').on('click', function () {
            var Id = $(this).data('id');

            window.location = HOMEPAGE.url_detail_index + "/" + Id;
        });
    }
}
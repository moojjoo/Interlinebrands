const uri = 'https://localhost:44309/api/movie';
let movies = null;
//function getCount(data) {
//    const el = $('#counter');
//    let Title = 'Title';
//    if (data) {
//        if (data > 1) {
//            id = 'ID';
//            title = 'Title';
//            ReleaseDate = 'ReleaseDate';
//            Genre = 'Genre';
//            Price = 'Price'
//        }
//        el.text(data + ' ' + title);
//    } else {
//        el.html('Title ' + title);
//    }
//}

$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: 'GET',
        url: uri,
        dataType: 'json',       
        success: function (data) {
            $('#movies').empty();
            //getCount(data.length);

            $.each(data, function (index, item) {
                $('<tr><td>' + item.title + '</td>' +
                    '<td>' + item.releaseDate + '</td>' +
                    '<td>' + item.genre + '</td>' +
                    '<td>' + item.price + '</td>' +
                    '</tr>').appendTo($('#movies'));
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("some error");
        }
    })
}

function addItem() {
    const item = {
        'name': $('#add-name').val(),
        'isComplete': false
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: uri,
        contentType: 'application/json',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) {
            getData();
            $('#add-name').val('');
        }
    });
}

//function deleteItem(id) {
//    $.ajax({
//        url: uri + '/' + id,
//        type: 'DELETE',
//        success: function (result) {
//            getData();
//        }
//    });
//}

//function editItem(id) {
//    $.each(todos, function (key, item) {
//        if (item.id === id) {
//            $('#edit-name').val(item.name);
//            $('#edit-id').val(item.id);
//            $('#edit-isComplete')[0].checked = item.isComplete;
//        }
//    });
//    $('#spoiler').css({ 'display': 'block' });
//}

//$('.my-form').on('submit', function () {
//    const item = {
//        'name': $('#edit-name').val(),
//        'isComplete': $('#edit-isComplete').is(':checked'),
//        'id': $('#edit-id').val()
//    };

//    $.ajax({
//        url: uri + '/' + $('#edit-id').val(),
//        type: 'PUT',
//        accepts: 'application/json',
//        contentType: 'application/json',
//        data: JSON.stringify(item),
//        success: function (result) {
//            getData();
//        }
//    });

//    closeInput();
//    return false;
//});

//function closeInput() {
//    $('#spoiler').css({ 'display': 'none' });
//}
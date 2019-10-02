// Script for upload images

    $(document).ready(function () {
        $("#fileButton").click(function () {
            var files = $("#fileInput").get(0).files;
            var fileData = new FormData();

            var newUrl = '@Url.Action("Gallery","Home")';

            fileData.append("__RequestVerificationToken", $('[name=__RequestVerificationToken]').val());

            for (var i = 0; i < files.length; i++) {
                fileData.append("fileInput", files[i]);
            }
            //var form = $('#__AjaxAntiForgeryForm');
            //var token = $('input[name="__RequestVerificationToken"]', form).val();
            //var url = 'Gallery", "Home")';
            $.ajax({
                type: "POST",
                url: "/Home/UploadFiles",
                dataType: "json",
                contentType: false, // Not to set any content header
                processData: false, // Not to process data
                //data: fileData,
                data: fileData,
                success: function (result, status, xhr) {
                    alert(result);
                    window.location.href = "/Home/Gallery"
                },
                error: function (xhr, status, error) {
                    alert(status);
                }
            });
        });

        $(document).ajaxStart(function () {
        $("#loadingImg").show();
    $("#fileButton").prop('disabled', true);
});

        $(document).ajaxStop(function () {
        $("#loadingImg").hide();
    $("#fileButton").prop('disabled', false);
    $("#fileInput").val("");
});

});







//script for remove files

$(document).on("click", "#FileButtonId", function (e) {
            var primaryValue = $(this).val();
    //var fileId = $('#imgId').val();
            if (confirm('Are you sure?')) {
        $.ajax({
            type: 'POST',
            data: { 'primary': primaryValue, /*'id': fileId */ },
            url: "/Home/DeleteFiles/",
            context: this,
            success: function () {
                $('.img').remove();
                $("#Files").load(location.href + " #Files");
                //$("#main-artpic").load(location.href + " #main-artpic");
                //$("#deleteImageConfirm").css("display", "block");
                alert("File has been deleted");

            }
        });
}
return false;
});
  